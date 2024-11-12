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
    public class QuoteStorePrescriptionItemService : IQuoteStorePrescriptionItemService
    {
        // In-memory list to store prescription items
        private static List<QuoteStorePrescriptionItem> _items = new List<QuoteStorePrescriptionItem>
    {
        new QuoteStorePrescriptionItem
        {
            PrescriptionId = 1,
            QuoteId = 1001,
            StoreId = 101,
            ItemName = "Paracetamol",
            ItemConcentration = "500mg",
            ItemInformation = "Pain relief and fever reducer",
            ItemContainerQuantity = 20,
            ItemQuantity = 5,
            ItemPrice = 15.50m,
            ItemDiscount = 0.1m,
            IsGeneric = true,
            IsSimilar = false,
            IsBrand = false,
            CreatedBy = 1,
            CreatedOn = DateTime.UtcNow.AddDays(-5),
            ModifiedBy = 1,
            ModifiedOn = DateTime.UtcNow
        },
        new QuoteStorePrescriptionItem
        {
            PrescriptionId = 2,
            QuoteId = 1002,
            StoreId = 102,
            ItemName = "Ibuprofen",
            ItemConcentration = "200mg",
            ItemInformation = "Anti-inflammatory pain relief",
            ItemContainerQuantity = 10,
            ItemQuantity = 3,
            ItemPrice = 10.00m,
            ItemDiscount = 0.05m,
            IsGeneric = false,
            IsSimilar = true,
            IsBrand = false,
            CreatedBy = 2,
            CreatedOn = DateTime.UtcNow.AddDays(-3),
            ModifiedBy = 2,
            ModifiedOn = DateTime.UtcNow
        }
    };

        // Get all items
        public async Task<IEnumerable<QuoteStorePrescriptionItem>> GetAllAsync()
        {
            return await Task.FromResult(_items);
        }

        // Get item by Prescription ID
        public async Task<QuoteStorePrescriptionItem?> GetByIdAsync(int id)
        {
            var item = _items.FirstOrDefault(i => i.PrescriptionId == id);
            return await Task.FromResult(item);
        }

        // Add a new item
        public async Task AddAsync(QuoteStorePrescriptionItem entity)
        {
            entity.PrescriptionId = _items.Any() ? _items.Max(i => i.PrescriptionId) + 1 : 1;
            entity.CreatedOn = DateTime.UtcNow;
            entity.ModifiedOn = DateTime.UtcNow;
            _items.Add(entity);
            await Task.CompletedTask;
        }

        // Update an existing item
        public async Task UpdateAsync(QuoteStorePrescriptionItem entity)
        {
            var existingItem = _items.FirstOrDefault(i => i.PrescriptionId == entity.PrescriptionId);
            if (existingItem != null)
            {
                existingItem.QuoteId = entity.QuoteId;
                existingItem.StoreId = entity.StoreId;
                existingItem.ItemName = entity.ItemName;
                existingItem.ItemConcentration = entity.ItemConcentration;
                existingItem.ItemInformation = entity.ItemInformation;
                existingItem.ItemContainerQuantity = entity.ItemContainerQuantity;
                existingItem.ItemQuantity = entity.ItemQuantity;
                existingItem.ItemPrice = entity.ItemPrice;
                existingItem.ItemDiscount = entity.ItemDiscount;
                existingItem.IsGeneric = entity.IsGeneric;
                existingItem.IsSimilar = entity.IsSimilar;
                existingItem.IsBrand = entity.IsBrand;
                existingItem.ModifiedBy = entity.ModifiedBy;
                existingItem.ModifiedOn = DateTime.UtcNow;
            }
            await Task.CompletedTask;
        }

        // Delete an item by Prescription ID
        public async Task DeleteAsync(int id)
        {
            var item = _items.FirstOrDefault(i => i.PrescriptionId == id);
            if (item != null)
            {
                _items.Remove(item);
            }
            await Task.CompletedTask;
        }

        Task<IEnumerable<QuoteStorePrescription>> IService<QuoteStorePrescription>.GetAllAsync()
        {
            throw new NotImplementedException();
        }


        public Task AddAsync(QuoteStorePrescription entity)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(QuoteStorePrescription entity)
        {
            throw new NotImplementedException();
        }

        Task<Result<Store>> IService<QuoteStorePrescription>.AddAsync(QuoteStorePrescription entity)
        {
            throw new NotImplementedException();
        }

        Task<Result<Store>> IService<QuoteStorePrescription>.GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
