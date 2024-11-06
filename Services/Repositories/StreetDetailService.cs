using Economizze.Library;
using StoreApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreApp.Services.Repositories
{
    public class StreetDetailService : IStreetDetailService
    {
        private readonly List<StreetDetailView> _streetDetails;
        public StreetDetailView StreetDetailView { get; set; }

        public StreetDetailService(List<StreetDetailView>? streetDetails = null)
        {
            // If no street details are provided, initialize with default values
            _streetDetails = streetDetails ?? new List<StreetDetailView>
            {
                new StreetDetailView
                {
                    StreetId = 1,
                    NeighborhoodId = 101,
                    StreetName = "Main Street",
                    StreetNameAscii = "Main Street",
                    Zipcode = "12345",
                    NeighborhoodName = "Downtown",
                    CityName = "Cityville",
                    StateName = "State"
                },
                new StreetDetailView
                {
                    StreetId = 2,
                    NeighborhoodId = 102,
                    StreetName = "Elm Street",
                    StreetNameAscii = "Elm Street",
                    Zipcode = "67890",
                    NeighborhoodName = "Uptown",
                    CityName = "Cityville",
                    StateName = "State"
                }
            };
        }

        public async Task<StreetDetailView> GetStreetDetailByIdAsync(int streetId)
        {
            // Simulate asynchronous behavior
            var result = _streetDetails.FirstOrDefault(sd => sd.StreetId == streetId);
            return await Task.FromResult(result);
        }

        public async Task<StreetDetailView> GetStreetDetailByZipCodeAsync(string zipCode)
        {
            // Simulate asynchronous behavior
            var result = _streetDetails.FirstOrDefault(sd => sd.Zipcode == zipCode);
            StreetDetailView = result;
            return await Task.FromResult(result);
        }
    }
}
