using Economizze.Library;
using StoreApp.Services.Interfaces;
using StoreApp.Wrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreApp.Services.Repositories
{
    public class StreetService : IStreetService
    {
        private readonly List<Street> _streets = new();
        public Street Street { get; set; }

        public StreetService()
        {
            // Initialize with sample data for Anápolis, Goiás
            _streets.AddRange(new List<Street>
            {
                new Street
                {
                    StreetId = 1,
                    StreetName = "Avenida Brasil Sul",
                    StreetNameAscii = "avenida_brasil_sul",
                    Zipcode = "75074230",
                    Longitude = -48.9568,
                    Latitude = -16.3267,
                    NeighborhoodId = 101,
                    CreatedBy = 1,
                    CreatedOn = DateTime.Now.AddMonths(-2),
                    ModifiedBy = 1,
                    ModifiedOn = DateTime.Now
                },
                new Street
                {
                    StreetId = 2,
                    StreetName = "Rua Engenheiro Portela",
                    StreetNameAscii = "rua_engenheiro_portela",
                    Zipcode = "75074310",
                    Longitude = -48.9582,
                    Latitude = -16.3289,
                    NeighborhoodId = 102,
                    CreatedBy = 1,
                    CreatedOn = DateTime.Now.AddMonths(-2),
                    ModifiedBy = 1,
                    ModifiedOn = DateTime.Now
                },
                new Street
                {
                    StreetId = 3,
                    StreetName = "Avenida Goiás",
                    StreetNameAscii = "avenida_goias",
                    Zipcode = "75074010",
                    Longitude = -48.9537,
                    Latitude = -16.3245,
                    NeighborhoodId = 103,
                    CreatedBy = 1,
                    CreatedOn = DateTime.Now.AddMonths(-3),
                    ModifiedBy = 1,
                    ModifiedOn = DateTime.Now
                },
                new Street
                {
                    StreetId = 4,
                    StreetName = "Rua Coronel Batista",
                    StreetNameAscii = "rua_coronel_batista",
                    Zipcode = "75074180",
                    Longitude = -48.9571,
                    Latitude = -16.3270,
                    NeighborhoodId = 104,
                    CreatedBy = 1,
                    CreatedOn = DateTime.Now.AddMonths(-3),
                    ModifiedBy = 1,
                    ModifiedOn = DateTime.Now
                },
                new Street
                {
                    StreetId = 5,
                    StreetName = "Rua Padre Félix",
                    StreetNameAscii = "rua_padre_felix",
                    Zipcode = "75074220",
                    Longitude = -48.9546,
                    Latitude = -16.3261,
                    NeighborhoodId = 105,
                    CreatedBy = 1,
                    CreatedOn = DateTime.Now.AddMonths(-1),
                    ModifiedBy = 1,
                    ModifiedOn = DateTime.Now
                }
            });
        }

        public async Task<IEnumerable<Street>> GetAllAsync()
        {
            return await Task.Run(() => _streets.AsEnumerable());
        }

        public async Task<Street?> GetByIdAsync(int id)
        {
            return await Task.Run(() => _streets.FirstOrDefault(s => s.StreetId == id));
        }

        public async Task<Street?> GetByZipCodeAsync(string zipCode)
        {
            return await Task.Run(() => _streets.FirstOrDefault(s => s.Zipcode == zipCode));
        }

        public async Task AddAsync(Street entity)
        {
            await Task.Run(() =>
            {
                entity.StreetId = _streets.Any() ? _streets.Max(s => s.StreetId) + 1 : 1;
                entity.CreatedOn = DateTime.Now;
                entity.ModifiedOn = DateTime.Now;
                _streets.Add(entity);
            });
        }

        public async Task UpdateAsync(Street entity)
        {
            await Task.Run(() =>
            {
                var existingStreet = _streets.FirstOrDefault(s => s.StreetId == entity.StreetId);
                if (existingStreet != null)
                {
                    existingStreet.StreetName = entity.StreetName;
                    existingStreet.StreetNameAscii = entity.StreetNameAscii;
                    existingStreet.Zipcode = entity.Zipcode;
                    existingStreet.Longitude = entity.Longitude;
                    existingStreet.Latitude = entity.Latitude;
                    existingStreet.NeighborhoodId = entity.NeighborhoodId;
                    existingStreet.ModifiedBy = entity.ModifiedBy;
                    existingStreet.ModifiedOn = DateTime.Now;
                }
            });
        }

        public async Task DeleteAsync(int id)
        {
            await Task.Run(() =>
            {
                var street = _streets.FirstOrDefault(s => s.StreetId == id);
                if (street != null)
                {
                    _streets.Remove(street);
                }
            });
        }

        

        Task<Result<Street>> IService<Street>.AddAsync(Street entity)
        {
            throw new NotImplementedException();
        }

        Task<Result<Street>> IService<Street>.GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<Result<Street>> IService<Street>.UpdateAsync(Street entity)
        {
            throw new NotImplementedException();
        }
    }
}
