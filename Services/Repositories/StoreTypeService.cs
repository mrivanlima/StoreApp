using Economizze.Library;
using StoreApp.Services.Interfaces;
using StoreApp.Wrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace StoreApp.Services.Repositories
{
    public class StoreTypeService : BaseService, IStoreTypeService
    {
        public List<StoreType> _storeTypes {get; set;}
        public StoreTypeService(IHttpClientFactory httpClientFactory, 
                                JsonSerializerOptions jsonSerializerOptions) : base(httpClientFactory, jsonSerializerOptions){}

        public Task<Result<StoreType>> AddAsync(StoreType entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Result<IEnumerable<StoreType>>> GetAllAsync()
        {
            var url = "StoreType";
            List<StoreType> storeTypes = new();
            try
            {
                var httpClient = _httpClientFactory.CreateClient("economizze");
                var response = await httpClient.GetAsync(url);
                var jsonResponse = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode)
                {
                    storeTypes = JsonSerializer.Deserialize<List<StoreType>>(jsonResponse, _jsonSerializerOptions)!;
                    _storeTypes = storeTypes;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return Result<IEnumerable<StoreType>>.Success(storeTypes); 
        }

        public Task<Result<StoreType>> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Result<StoreType>> UpdateAsync(StoreType entity)
        {
            throw new NotImplementedException();
        }
    }
}
