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
    public class StoreNeighborhoodSubscriptionService : IStoreNeighborhoodSubscriptionService
    {
        private readonly List<StoreNeighborhoodSubscription> _subscriptions = new();
        public StoreNeighborhoodSubscription StoreNeighborhoodSubscription { get; set; }

        public StoreNeighborhoodSubscriptionService()
        {
            // Initialize with sample data
            _subscriptions.AddRange(new List<StoreNeighborhoodSubscription>
            {
                new StoreNeighborhoodSubscription
                {
                    StoreNeighborhoodSubscriptionId = 1,
                    StoreId = 1,
                    NeighborhoodId = 101,
                    IsActive = true,
                    CreatedBy = 1,
                    CreatedOn = DateTime.Now.AddMonths(-2),
                    ModifiedBy = 1,
                    ModifiedOn = DateTime.Now.AddMonths(-1)
                },
                new StoreNeighborhoodSubscription
                {
                    StoreNeighborhoodSubscriptionId = 2,
                    StoreId = 2,
                    NeighborhoodId = 102,
                    IsActive = false,
                    CreatedBy = 1,
                    CreatedOn = DateTime.Now.AddMonths(-3),
                    ModifiedBy = 1,
                    ModifiedOn = DateTime.Now.AddMonths(-1)
                },
                new StoreNeighborhoodSubscription
                {
                    StoreNeighborhoodSubscriptionId = 3,
                    StoreId = 1,
                    NeighborhoodId = 103,
                    IsActive = true,
                    CreatedBy = 2,
                    CreatedOn = DateTime.Now.AddMonths(-4),
                    ModifiedBy = 2,
                    ModifiedOn = DateTime.Now
                }
            });
        }

        public async Task<IEnumerable<StoreNeighborhoodSubscription>> GetAllAsync()
        {
            return await Task.Run(() => _subscriptions.AsEnumerable());
        }

        public async Task<StoreNeighborhoodSubscription?> GetByIdAsync(int id)
        {
            return await Task.Run(() => _subscriptions.FirstOrDefault(s => s.StoreNeighborhoodSubscriptionId == id));
        }

        public async Task AddAsync(StoreNeighborhoodSubscription entity)
        {
            await Task.Run(() =>
            {
                entity.StoreNeighborhoodSubscriptionId = _subscriptions.Any() ? _subscriptions.Max(s => s.StoreNeighborhoodSubscriptionId) + 1 : 1;
                entity.CreatedOn = DateTime.Now;
                entity.ModifiedOn = DateTime.Now;
                _subscriptions.Add(entity);
            });
        }

        public async Task UpdateAsync(StoreNeighborhoodSubscription entity)
        {
            await Task.Run(() =>
            {
                var existingSubscription = _subscriptions.FirstOrDefault(s => s.StoreNeighborhoodSubscriptionId == entity.StoreNeighborhoodSubscriptionId);
                if (existingSubscription != null)
                {
                    existingSubscription.StoreId = entity.StoreId;
                    existingSubscription.NeighborhoodId = entity.NeighborhoodId;
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
                var subscription = _subscriptions.FirstOrDefault(s => s.StoreNeighborhoodSubscriptionId == id);
                if (subscription != null)
                {
                    _subscriptions.Remove(subscription);
                }
            });
        }

        Task<Result<Store>> IService<StoreNeighborhoodSubscription>.AddAsync(StoreNeighborhoodSubscription entity)
        {
            throw new NotImplementedException();
        }

        Task<Result<Store>> IService<StoreNeighborhoodSubscription>.GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
