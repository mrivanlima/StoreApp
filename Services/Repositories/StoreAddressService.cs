using Economizze.Library;
using StoreApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreApp.Services.Repositories
{
    public class StoreAddressService : IStoreAddressService
    {
        private readonly List<StoreAddress> _storeAddresses = new();
        public StoreAddress storeAddress { get; set; }

        public StoreAddressService()
        {
            // Optional: Initialize with sample data
            _storeAddresses.Add(new StoreAddress
            {
                StoreAddressId = 1,
                StoreId = 1,
                StreetId = 101,
                Complement = "Near Park",
                ComplementAscii = "near_park",
                Longitude = 45.6789,
                Latitude = -73.4567,
                CreatedBy = 1,
                CreatedOn = DateTime.Now.AddDays(-30),
                ModifiedBy = 1,
                ModifiedOn = DateTime.Now
            });
        }

        public async Task<IEnumerable<StoreAddress>> GetAllAsync()
        {
            return await Task.Run(() => _storeAddresses.AsEnumerable());
        }

        public async Task<StoreAddress?> GetByIdAsync(int id)
        {
            return await Task.Run(() => _storeAddresses.FirstOrDefault(sa => sa.StoreAddressId == id));
        }

        public async Task AddAsync(StoreAddress entity)
        {
            await Task.Run(() =>
            {
                entity.StoreAddressId = _storeAddresses.Any() ? _storeAddresses.Max(sa => sa.StoreAddressId) + 1 : 1;
                entity.CreatedOn = DateTime.Now;
                entity.ModifiedOn = DateTime.Now;
                _storeAddresses.Add(entity);
            });
        }

        public async Task UpdateAsync(StoreAddress entity)
        {
            await Task.Run(() =>
            {
                var existingAddress = _storeAddresses.FirstOrDefault(sa => sa.StoreAddressId == entity.StoreAddressId);
                if (existingAddress != null)
                {
                    existingAddress.StreetId = entity.StreetId;
                    existingAddress.Complement = entity.Complement;
                    existingAddress.ComplementAscii = entity.ComplementAscii;
                    existingAddress.Longitude = entity.Longitude;
                    existingAddress.Latitude = entity.Latitude;
                    existingAddress.ModifiedBy = entity.ModifiedBy;
                    existingAddress.ModifiedOn = DateTime.Now;
                }
            });
        }

        public async Task DeleteAsync(int id)
        {
            await Task.Run(() =>
            {
                var storeAddress = _storeAddresses.FirstOrDefault(sa => sa.StoreAddressId == id);
                if (storeAddress != null)
                {
                    _storeAddresses.Remove(storeAddress);
                }
            });
        }
    }
}
