using Economizze.Library;
using StoreApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreApp.Services.Repositories
{
    public class StoreService : IStoreService
    {
        private readonly List<Store> _stores = new();
        private readonly Store? _store;
        public Store Store { get; set; }

        public StoreService()
        {
            // Optional: Initialize with some sample data
            _stores.Add(new Store
            {
                StoreId = 1,
                StoreUniqueId = Guid.NewGuid(),
                StoreName = "Sample Store",
                StoreNameAscii = "sample_store",
                //StoreAddressId = 101,
                CreatedBy = 1,
                CreatedOn = DateTime.Now.AddDays(-30),
                ModifiedBy = 1,
                ModifiedOn = DateTime.Now
            });
        }

        public async Task<IEnumerable<Store>> GetAllAsync()
        {
            return await Task.Run(() => _stores.AsEnumerable());
        }

        public async Task<Store?> GetByIdAsync(int id)
        {
            return await Task.Run(() => _stores.FirstOrDefault(s => s.StoreId == id));
        }

        public async Task AddAsync(Store entity)
        {
            await Task.Run(() =>
            {
                entity.StoreId = _stores.Any() ? _stores.Max(s => s.StoreId) + 1 : 1;
                entity.StoreUniqueId = Guid.NewGuid();
                entity.CreatedOn = DateTime.Now;
                entity.ModifiedOn = DateTime.Now;
                _stores.Add(entity);
                Store = entity;
            });
        }

        public async Task UpdateAsync(Store entity)
        {
            await Task.Run(() =>
            {
                var existingStore = _stores.FirstOrDefault(s => s.StoreId == entity.StoreId);
                if (existingStore != null)
                {
                    existingStore.StoreName = entity.StoreName;
                    existingStore.StoreNameAscii = entity.StoreNameAscii;
                   // existingStore.StoreAddressId = entity.StoreAddressId;
                    existingStore.ModifiedBy = entity.ModifiedBy;
                    existingStore.ModifiedOn = DateTime.Now;
                }
            });
        }

        public async Task DeleteAsync(int id)
        {
            await Task.Run(() =>
            {
                var store = _stores.FirstOrDefault(s => s.StoreId == id);
                if (store != null)
                {
                    _stores.Remove(store);
                }
            });
        }
    }
}
