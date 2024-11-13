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
    public class StoreCitySubscriptionService : IStoreCitySubscriptionService
    {
        private readonly List<StoreCitySubscription> _subscriptions = new();

        public StoreCitySubscriptionService()
        {
            // Initialize with some sample data
            _subscriptions.AddRange(new List<StoreCitySubscription>
            {
                new StoreCitySubscription
                {
                    StoreCitySubscriptionId = 1,
                    StoreId = 1,
                    CityId = 101,
                    IsActive = true,
                    CreatedBy = 1,
                    CreatedOn = DateTime.Now.AddDays(-10),
                    ModifiedBy = 1,
                    ModifiedOn = DateTime.Now
                },
                new StoreCitySubscription
                {
                    StoreCitySubscriptionId = 2,
                    StoreId = 2,
                    CityId = 102,
                    IsActive = true,
                    CreatedBy = 1,
                    CreatedOn = DateTime.Now.AddDays(-5),
                    ModifiedBy = 1,
                    ModifiedOn = DateTime.Now
                }
            });
        }

        public async Task<IEnumerable<StoreCitySubscription>> GetAllAsync()
        {
            return await Task.Run(() => _subscriptions.AsEnumerable());
        }

        public async Task<StoreCitySubscription?> GetByIdAsync(int id)
        {
            return await Task.Run(() => _subscriptions.FirstOrDefault(s => s.StoreCitySubscriptionId == id));
        }

        public async Task AddAsync(StoreCitySubscription entity)
        {
            await Task.Run(() =>
            {
                entity.StoreCitySubscriptionId = _subscriptions.Any() ? _subscriptions.Max(s => s.StoreCitySubscriptionId) + 1 : 1;
                entity.CreatedOn = DateTime.Now;
                entity.ModifiedOn = DateTime.Now;
                _subscriptions.Add(entity);
            });
        }

        public async Task UpdateAsync(StoreCitySubscription entity)
        {
            await Task.Run(() =>
            {
                var existingSubscription = _subscriptions.FirstOrDefault(s => s.StoreCitySubscriptionId == entity.StoreCitySubscriptionId);
                if (existingSubscription != null)
                {
                    existingSubscription.StoreId = entity.StoreId;
                    existingSubscription.CityId = entity.CityId;
                    existingSubscription.IsActive = entity.IsActive;
                    existingSubscription.ModifiedBy = entity.ModifiedBy;
                    existingSubscription.ModifiedOn = DateTime.Now;
                }
            });
        }

        public async Task DeleteAsync(int id)
        {
            await Task.Run(() =>
            {
                var subscription = _subscriptions.FirstOrDefault(s => s.StoreCitySubscriptionId == id);
                if (subscription != null)
                {
                    _subscriptions.Remove(subscription);
                }
            });
        }

        

        Task<Result<StoreCitySubscription>> IService<StoreCitySubscription>.AddAsync(StoreCitySubscription entity)
        {
            throw new NotImplementedException();
        }

        Task<Result<StoreCitySubscription>> IService<StoreCitySubscription>.GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<Result<StoreCitySubscription>> IService<StoreCitySubscription>.UpdateAsync(StoreCitySubscription entity)
        {
            throw new NotImplementedException();
        }

        Task<Result<IEnumerable<StoreType>>> IService<StoreCitySubscription>.GetAllAsync()
        {
            throw new NotImplementedException();
        }
    }
}
