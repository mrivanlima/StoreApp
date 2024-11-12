using Economizze.Library;
using StoreApp.Services.Interfaces;
using StoreApp.Wrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;

namespace StoreApp.Services.Repositories
{
    public class StoreService : BaseService, IStoreService
    {
        private readonly List<Store>? _stores;
        public Store? currentStore { get; private set; }


        public StoreService(IHttpClientFactory httpClientFactory,
                            JsonSerializerOptions jsonSerializerOptions)
        : base(httpClientFactory, jsonSerializerOptions)
        { }

        public async Task<IEnumerable<Store>> GetAllAsync()
        {
            return await Task.Run(() => _stores.AsEnumerable());
        }

        public async Task<Result<Store>> GetByIdAsync(int id)
        {
            var url = $"store/{id}";
            try
            {
                var httpClient = _httpClientFactory.CreateClient("economizze");
                var response = await httpClient.GetAsync(url);
                var jsonResponse = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode)
                {
                    currentStore = JsonSerializer.Deserialize<Store>(jsonResponse, _jsonSerializerOptions)!;
                    return Result<Store>.Success(currentStore);
                }
                else
                {
                    return Result<Store>.Failure(jsonResponse);
                }

            }
            catch (Exception ex)
            {
                return Result<Store>.Failure($"Erro: {ex.Message}");
            }
        }

        public async Task<Result<Store>> AddAsync(Store entity)
        {
            var url = "store";
            try
            {
                var httpClient = _httpClientFactory.CreateClient("economizze");
                var response = await httpClient.PostAsJsonAsync(url, entity);
                var jsonResponse = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode)
                {
                    entity = JsonSerializer.Deserialize<Store>(jsonResponse, _jsonSerializerOptions)!;
                    currentStore = entity;
                    return Result<Store>.Success(entity);
                }
                else
                {
                    return Result<Store>.Failure(jsonResponse);
                }

            }
            catch (Exception ex)
            {
                return Result<Store>.Failure($"Erro: {ex.Message}");
            }
        }

        public async Task UpdateAsync(Store entity)
        {
            await Task.Run(() =>
            {
                var existingStore = _stores.FirstOrDefault(s => s.StoreId == entity.StoreId);
                if (existingStore != null)
                {
                    existingStore.StoreName = entity.StoreName;
                    existingStore.StoreNameAscii = entity.StoreNameAscii;
                   // existingStore.StoreAddressId = entity.StoreAddressId;
                    existingStore.ModifiedBy = entity.ModifiedBy;
                    existingStore.ModifiedOn = DateTime.Now;
                }
            });
        }

        public async Task DeleteAsync(int id)
        {
            await Task.Run(() =>
            {
                var store = _stores.FirstOrDefault(s => s.StoreId == id);
                if (store != null)
                {
                    _stores.Remove(store);
                }
            });
        }
    }
}
