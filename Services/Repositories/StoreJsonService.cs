using Economizze.Library;
using StoreApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace StoreApp.Services.Repositories
{
    public class StoreJsonService : BaseService, IStoreJsonService
    {
        public StoreJsonService(IHttpClientFactory httpClientFactory, JsonSerializerOptions jsonSerializerOptions) : base(httpClientFactory, jsonSerializerOptions)
        {
        }

        public async Task<StoreJson> AddAsync(StoreJson entity)
        {
            var url = "StoreJson";
            try
            {
                var httpClient = _httpClientFactory.CreateClient("economizze");
                var response = await httpClient.PostAsJsonAsync(url, entity);
                var jsonResponse = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode)
                {
                    entity = JsonSerializer.Deserialize<StoreJson>(jsonResponse, _jsonSerializerOptions)!;

                }
               

            }
            catch (Exception ex)
            {
                
            }
            return entity;
        }
    }
}
