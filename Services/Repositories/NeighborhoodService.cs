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
    public class NeighborhoodService : INeighborhoodService
    {
        private readonly List<Neighborhood> _neighborhoods = new();
        public NeighborhoodService()
        {
            // Adding a few neighborhoods from Anápolis, Goiás, Brazil
            _neighborhoods.AddRange(new List<Neighborhood>
            {
                new Neighborhood { NeighborhoodId = 1, NeighborhoodName = "Jardim Alexandrina", NeighborhoodNameAscii = "jardim_alexandrina", Longitude = -48.9487, Latitude = -16.3289, CityId = 1, CreatedBy = 1, CreatedOn = DateTime.Now, ModifiedBy = 1, ModifiedOn = DateTime.Now },
                new Neighborhood { NeighborhoodId = 2, NeighborhoodName = "Centro", NeighborhoodNameAscii = "centro", Longitude = -48.9473, Latitude = -16.3264, CityId = 1, CreatedBy = 1, CreatedOn = DateTime.Now, ModifiedBy = 1, ModifiedOn = DateTime.Now },
                new Neighborhood { NeighborhoodId = 3, NeighborhoodName = "Vila Jaiara", NeighborhoodNameAscii = "vila_jaiara", Longitude = -48.9562, Latitude = -16.3218, CityId = 1, CreatedBy = 1, CreatedOn = DateTime.Now, ModifiedBy = 1, ModifiedOn = DateTime.Now },
                new Neighborhood { NeighborhoodId = 4, NeighborhoodName = "Setor Central", NeighborhoodNameAscii = "setor_central", Longitude = -48.9465, Latitude = -16.3287, CityId = 1, CreatedBy = 1, CreatedOn = DateTime.Now, ModifiedBy = 1, ModifiedOn = DateTime.Now },
                new Neighborhood { NeighborhoodId = 5, NeighborhoodName = "Jundiaí", NeighborhoodNameAscii = "jundiai", Longitude = -48.9365, Latitude = -16.3261, CityId = 1, CreatedBy = 1, CreatedOn = DateTime.Now, ModifiedBy = 1, ModifiedOn = DateTime.Now }
            });
        }

        public async Task<IEnumerable<Neighborhood>> GetAllAsync()
        {
            return await Task.FromResult(_neighborhoods.AsEnumerable());
        }

        public async Task<Neighborhood?> GetByIdAsync(int id)
        {
            var neighborhood = _neighborhoods.FirstOrDefault(n => n.NeighborhoodId == id);
            return await Task.FromResult(neighborhood);
        }

        public async Task AddAsync(Neighborhood entity)
        {
            await Task.Run(() =>
            {
                entity.NeighborhoodId = _neighborhoods.Any() ? _neighborhoods.Max(n => n.NeighborhoodId) + 1 : 1;
                entity.CreatedOn = DateTime.Now;
                entity.ModifiedOn = DateTime.Now;
                _neighborhoods.Add(entity);
            });
        }

        public async Task UpdateAsync(Neighborhood entity)
        {
            await Task.Run(() =>
            {
                var existingNeighborhood = _neighborhoods.FirstOrDefault(n => n.NeighborhoodId == entity.NeighborhoodId);
                if (existingNeighborhood != null)
                {
                    existingNeighborhood.NeighborhoodName = entity.NeighborhoodName;
                    existingNeighborhood.NeighborhoodNameAscii = entity.NeighborhoodNameAscii;
                    existingNeighborhood.Longitude = entity.Longitude;
                    existingNeighborhood.Latitude = entity.Latitude;
                    existingNeighborhood.CityId = entity.CityId;
                    existingNeighborhood.ModifiedBy = entity.ModifiedBy;
                    existingNeighborhood.ModifiedOn = DateTime.Now;
                }
            });
        }

        public async Task DeleteAsync(int id)
        {
            await Task.Run(() =>
            {
                var neighborhood = _neighborhoods.FirstOrDefault(n => n.NeighborhoodId == id);
                if (neighborhood != null)
                {
                    _neighborhoods.Remove(neighborhood);
                }
            });
        }

        

        

        Task<Result<Neighborhood>> IService<Neighborhood>.AddAsync(Neighborhood entity)
        {
            throw new NotImplementedException();
        }

        Task<Result<Neighborhood>> IService<Neighborhood>.GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<Result<Neighborhood>> IService<Neighborhood>.UpdateAsync(Neighborhood entity)
        {
            throw new NotImplementedException();
        }

        Task<Result<IEnumerable<StoreType>>> IService<Neighborhood>.GetAllAsync()
        {
            throw new NotImplementedException();
        }
    }
}
