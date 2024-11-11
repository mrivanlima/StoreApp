using Economizze.Library;
using StoreApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreApp.Services.Repositories
{
    public class QuoteStorePrescriptionService :IQuoteStorePrescriptionService
    {
        private static List<QuoteStorePrescription> _prescriptions = new List<QuoteStorePrescription>
    {
        new QuoteStorePrescription
        {
            PrescriptionId = 1,
            QuoteId = 1001,
            StoreId = 101,
            IsComplete = true,
            CreatedBy = 1,
            CreatedOn = DateTime.UtcNow.AddDays(-10),
            ModifiedBy = 1,
            ModifiedOn = DateTime.UtcNow.AddDays(-5)
        },
        new QuoteStorePrescription
        {
            PrescriptionId = 2,
            QuoteId = 1002,
            StoreId = 102,
            IsComplete = false,
            CreatedBy = 2,
            CreatedOn = DateTime.UtcNow.AddDays(-7),
            ModifiedBy = 2,
            ModifiedOn = DateTime.UtcNow.AddDays(-3)
        }
    };

        // Get all prescriptions
        public async Task<IEnumerable<QuoteStorePrescription>> GetAllAsync()
        {
            return await Task.FromResult(_prescriptions);
        }

        // Get a prescription by ID
        public async Task<QuoteStorePrescription?> GetByIdAsync(int id)
        {
            var prescription = _prescriptions.FirstOrDefault(p => p.PrescriptionId == id);
            return await Task.FromResult(prescription);
        }

        // Add a new prescription
        public async Task AddAsync(QuoteStorePrescription entity)
        {
            entity.PrescriptionId = _prescriptions.Any() ? _prescriptions.Max(p => p.PrescriptionId) + 1 : 1;
            entity.CreatedOn = DateTime.UtcNow;
            entity.ModifiedOn = DateTime.UtcNow;
            _prescriptions.Add(entity);
            await Task.CompletedTask;
        }

        // Update an existing prescription
        public async Task UpdateAsync(QuoteStorePrescription entity)
        {
            var existing = _prescriptions.FirstOrDefault(p => p.PrescriptionId == entity.PrescriptionId);
            if (existing != null)
            {
                existing.QuoteId = entity.QuoteId;
                existing.StoreId = entity.StoreId;
                existing.IsComplete = entity.IsComplete;
                existing.CreatedBy = entity.CreatedBy;
                existing.ModifiedBy = entity.ModifiedBy;
                existing.ModifiedOn = DateTime.UtcNow;
            }
            await Task.CompletedTask;
        }

        // Delete a prescription by ID
        public async Task DeleteAsync(int id)
        {
            var prescription = _prescriptions.FirstOrDefault(p => p.PrescriptionId == id);
            if (prescription != null)
            {
                _prescriptions.Remove(prescription);
            }
            await Task.CompletedTask;
        }
    }
}
