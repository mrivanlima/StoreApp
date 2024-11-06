using Economizze.Library;
using StoreApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreApp.Services.Repositories
{
    public class CityService : ICityService
    {
        private readonly List<City> _cities = new();
        public City City { get; set; }

        public CityService()
        {
            // Initialize with some cities from the state of Goiás
            _cities.AddRange(new List<City>
        {
            new City { CityId = 1, CityName = "Goiânia", CityNameAscii = "goiania", Longitude = -49.2643, Latitude = -16.6869, StateId = 9, CreatedBy = 1, CreatedOn = DateTime.Now, ModifiedBy = 1, ModifiedOn = DateTime.Now },
            new City { CityId = 2, CityName = "Aparecida de Goiânia", CityNameAscii = "aparecida_de_goiania", Longitude = -49.2468, Latitude = -16.8237, StateId = 9, CreatedBy = 1, CreatedOn = DateTime.Now, ModifiedBy = 1, ModifiedOn = DateTime.Now },
            new City { CityId = 3, CityName = "Anápolis", CityNameAscii = "anapolis", Longitude = -48.9534, Latitude = -16.3285, StateId = 9, CreatedBy = 1, CreatedOn = DateTime.Now, ModifiedBy = 1, ModifiedOn = DateTime.Now },
            new City { CityId = 4, CityName = "Rio Verde", CityNameAscii = "rio_verde", Longitude = -50.9192, Latitude = -17.7923, StateId = 9, CreatedBy = 1, CreatedOn = DateTime.Now, ModifiedBy = 1, ModifiedOn = DateTime.Now },
            new City { CityId = 5, CityName = "Luziânia", CityNameAscii = "luziania", Longitude = -47.9512, Latitude = -16.2525, StateId = 9, CreatedBy = 1, CreatedOn = DateTime.Now, ModifiedBy = 1, ModifiedOn = DateTime.Now }
        });
        }

        public async Task<IEnumerable<City>> GetAllAsync()
        {
            return await Task.FromResult(_cities.AsEnumerable());
        }

        public async Task<City?> GetByIdAsync(int id)
        {
            return await Task.FromResult(_cities.FirstOrDefault(c => c.CityId == id));
        }

        public async Task AddAsync(City entity)
        {
            await Task.Run(() =>
            {
                entity.CityId = (short)(_cities.Any() ? _cities.Max(c => c.CityId) + 1 : 1);
                entity.CreatedOn = DateTime.Now;
                entity.ModifiedOn = DateTime.Now;
                _cities.Add(entity);
            });
        }

        public async Task UpdateAsync(City entity)
        {
            await Task.Run(() =>
            {
                var existingCity = _cities.FirstOrDefault(c => c.CityId == entity.CityId);
                if (existingCity != null)
                {
                    existingCity.CityName = entity.CityName;
                    existingCity.CityNameAscii = entity.CityNameAscii;
                    existingCity.Longitude = entity.Longitude;
                    existingCity.Latitude = entity.Latitude;
                    existingCity.StateId = entity.StateId;
                    existingCity.ModifiedBy = entity.ModifiedBy;
                    existingCity.ModifiedOn = DateTime.Now;
                }
            });
        }

        public async Task DeleteAsync(int id)
        {
            await Task.Run(() =>
            {
                var city = _cities.FirstOrDefault(c => c.CityId == id);
                if (city != null)
                {
                    _cities.Remove(city);
                }
            });
        }
    }
}
