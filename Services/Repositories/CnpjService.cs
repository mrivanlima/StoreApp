

using StoreApp.Services.Interfaces;

namespace StoreApp.Services.Repositories
{
    public class CnpjService : ICnpjService
    {
        private readonly HttpClient _httpClient;

        public CnpjService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string?> GetCnpjDataAsync(string cnpj)
        {
            try
            {
                string sanitizedCnpj = new string(cnpj.Where(char.IsDigit).ToArray());
                var url = $"https://publica.cnpj.ws/cnpj/{sanitizedCnpj}";
                var response = await _httpClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsStringAsync();
                }
                else
                {
                    return $"Error: {response.ReasonPhrase}";
                }
            }
            catch (Exception ex)
            {
                return $"An error occurred: {ex.Message}";
            }
        }
    }
}
