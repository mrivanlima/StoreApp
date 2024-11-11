using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace StoreApp.Services.Repositories
{
    public class BaseService
    {
        protected readonly IHttpClientFactory _httpClientFactory;
        protected readonly JsonSerializerOptions _jsonSerializerOptions;

        public BaseService(IHttpClientFactory httpClientFactory, 
                            JsonSerializerOptions jsonSerializerOptions)
        {
            _httpClientFactory = httpClientFactory;
            _jsonSerializerOptions = jsonSerializerOptions;
        }

    }
}
