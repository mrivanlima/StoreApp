using Economizze.Library;
using StoreApp.Services.Interfaces;
using StoreApp.Wrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreApp.Services.Repositories
{
    public class StorePhoneService : IStorePhoneService
    {
        private readonly List<StorePhone> _storePhones = new();
        public StorePhone StorePhone { get; set; }

        public StorePhoneService()
        {
            // Optional: Initialize with some sample data
            _storePhones.Add(new StorePhone
            {
                StorePhoneId = 1,
                StoreId = 1,
                CountryCode = "1",
                StateCode = "555",
                PhoneNumber = "1234567890",
                IsMain = true,
                IsActive = true,
                IsWhatsApp = false
            });
        }

        public async Task<IEnumerable<StorePhone>> GetAllAsync()
        {
            return await Task.Run(() => _storePhones.AsEnumerable());
        }

        public async Task<StorePhone?> GetByIdAsync(int id)
        {
            return await Task.Run(() => _storePhones.FirstOrDefault(sp => sp.StorePhoneId == id));
        }

        public async Task AddAsync(StorePhone entity)
        {
            await Task.Run(() =>
            {
                entity.StorePhoneId = _storePhones.Any() ? _storePhones.Max(sp => sp.StorePhoneId) + 1 : 1;
                _storePhones.Add(entity);
                StorePhone = entity;    
            });
        }

        public async Task UpdateAsync(StorePhone entity)
        {
            await Task.Run(() =>
            {
                var existingPhone = _storePhones.FirstOrDefault(sp => sp.StorePhoneId == entity.StorePhoneId);
                if (existingPhone != null)
                {
                    existingPhone.StoreId = entity.StoreId;
                    existingPhone.CountryCode = entity.CountryCode;
                    existingPhone.StateCode = entity.StateCode;
                    existingPhone.PhoneNumber = entity.PhoneNumber;
                    existingPhone.IsMain = entity.IsMain;
                    existingPhone.IsActive = entity.IsActive;
                    existingPhone.IsWhatsApp = entity.IsWhatsApp;
                }
            });
        }

        public async Task DeleteAsync(int id)
        {
            await Task.Run(() =>
            {
                var storePhone = _storePhones.FirstOrDefault(sp => sp.StorePhoneId == id);
                if (storePhone != null)
                {
                    _storePhones.Remove(storePhone);
                }
            });
        }

        

        Task<Result<StorePhone>> IService<StorePhone>.AddAsync(StorePhone entity)
        {
            throw new NotImplementedException();
        }

        Task<Result<StorePhone>> IService<StorePhone>.GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<Result<StorePhone>> IService<StorePhone>.UpdateAsync(StorePhone entity)
        {
            throw new NotImplementedException();
        }
    }
}
