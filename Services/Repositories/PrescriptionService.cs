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
    public class PrescriptionService : IPrescriptionService
    {
        private readonly List<Prescription> _prescriptions;

        public PrescriptionService()
        {
            // Initialize with some default prescriptions
            _prescriptions = new List<Prescription>
        {
            new Prescription
            {
                PrescriptionId = 1,
                QuoteId = 1001,
                PrescriptionUnique = Guid.NewGuid(),
                //PrescriptionUrl = "https://example.com/prescriptions/1",
                CreatedBy = 101,
                CreatedOn = DateTime.Now.AddDays(-10),
                ModifiedBy = 101,
                ModifiedOn = DateTime.Now.AddDays(-5),
                FacilityId = 201,
                ProfessionalId = 301
            },
            new Prescription
            {
                PrescriptionId = 2,
                QuoteId = 1002,
                PrescriptionUnique = Guid.NewGuid(),
                //PrescriptionUrl = "https://example.com/prescriptions/2",
                CreatedBy = 102,
                CreatedOn = DateTime.Now.AddDays(-8),
                ModifiedBy = 102,
                ModifiedOn = DateTime.Now.AddDays(-3),
                FacilityId = 202,
                ProfessionalId = 302
            },
            new Prescription
            {
                PrescriptionId = 3,
                QuoteId = 1003,
                PrescriptionUnique = Guid.NewGuid(),
                //PrescriptionUrl = "https://example.com/prescriptions/3",
                CreatedBy = 103,
                CreatedOn = DateTime.Now.AddDays(-7),
                ModifiedBy = 103,
                ModifiedOn = DateTime.Now.AddDays(-2),
                FacilityId = 203,
                ProfessionalId = 303
            }
        };
        }

        public async Task<IEnumerable<Prescription>> GetAllAsync()
        {
            return await Task.FromResult(_prescriptions);
        }

        public async Task<Prescription?> GetByIdAsync(int id)
        {
            return await Task.FromResult(_prescriptions.FirstOrDefault(p => p.PrescriptionId == id));
        }

        public async Task AddAsync(Prescription prescription)
        {
            _prescriptions.Add(prescription);
            await Task.CompletedTask;
        }

        public async Task UpdateAsync(Prescription prescription)
        {
            var existingPrescription = _prescriptions.FirstOrDefault(p => p.PrescriptionId == prescription.PrescriptionId);
            if (existingPrescription != null)
            {
                existingPrescription.QuoteId = prescription.QuoteId;
                existingPrescription.PrescriptionUnique = prescription.PrescriptionUnique;
                //existingPrescription.PrescriptionUrl = prescription.PrescriptionUrl;
                existingPrescription.CreatedBy = prescription.CreatedBy;
                existingPrescription.CreatedOn = prescription.CreatedOn;
                existingPrescription.ModifiedBy = prescription.ModifiedBy;
                existingPrescription.ModifiedOn = prescription.ModifiedOn;
                existingPrescription.FacilityId = prescription.FacilityId;
                existingPrescription.ProfessionalId = prescription.ProfessionalId;
            }
            await Task.CompletedTask;
        }

        public async Task DeleteAsync(int id)
        {
            var prescription = _prescriptions.FirstOrDefault(p => p.PrescriptionId == id);
            if (prescription != null)
            {
                _prescriptions.Remove(prescription);
            }
            await Task.CompletedTask;
        }

        

       

        Task<Result<Prescription>> IService<Prescription>.AddAsync(Prescription entity)
        {
            throw new NotImplementedException();
        }

        Task<Result<Prescription>> IService<Prescription>.GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<Result<Prescription>> IService<Prescription>.UpdateAsync(Prescription entity)
        {
            throw new NotImplementedException();
        }
    }

}
