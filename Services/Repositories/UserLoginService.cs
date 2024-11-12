using Economizze.Library;
using StoreApp.Services.Interfaces;
using StoreApp.Services.Repositories;
using System.Net.Http.Json;
using System.Net.Http;
using System.Text.Json;
using StoreApp.Model;
using StoreApp.Wrapper;


public class UserLoginService : BaseService, IUserLoginService
{
    private readonly List<UserLogin> _userLogins;
    private UserLogin? _currentUser;

    public UserLoginService(IHttpClientFactory httpClientFactory, 
                            JsonSerializerOptions jsonSerializerOptions)
        : base(httpClientFactory, jsonSerializerOptions)
    {}

    public Task<IEnumerable<UserLogin>> GetAllAsync()
    {
        return Task.FromResult(_userLogins.AsEnumerable());
    }

    public Task<UserLogin?> GetByIdAsync(int id)
    {
        var userLogin = _userLogins.FirstOrDefault(u => u.UserId == id);
        return Task.FromResult(userLogin);
    }

    public Task AddAsync(UserLogin entity)
    {
        entity.UserId = _userLogins.Max(u => u.UserId) + 1; // Auto-increment ID
        entity.UserUniqueId = Guid.NewGuid(); // Assign a new unique ID
        entity.CreatedOn = DateTime.Now;
        _userLogins.Add(entity);
        return Task.CompletedTask;
    }

    public Task UpdateAsync(UserLogin entity)
    {
        var existingUserLogin = _userLogins.FirstOrDefault(u => u.UserId == entity.UserId);
        if (existingUserLogin != null)
        {
            existingUserLogin.Username = entity.Username;
            existingUserLogin.PasswordHash = entity.PasswordHash;
            existingUserLogin.PasswordSalt = entity.PasswordSalt;
            existingUserLogin.IsVerified = entity.IsVerified;
            existingUserLogin.IsActive = entity.IsActive;
            existingUserLogin.IsLocked = entity.IsLocked;
            existingUserLogin.PasswordAttempts = entity.PasswordAttempts;
            existingUserLogin.ChangedInitialPassword = entity.ChangedInitialPassword;
            existingUserLogin.LockedTime = entity.LockedTime;
            existingUserLogin.ModifiedBy = entity.ModifiedBy;
            existingUserLogin.ModifiedOn = DateTime.Now;
        }
        return Task.CompletedTask;
    }

    public Task DeleteAsync(int id)
    {
        var userLogin = _userLogins.FirstOrDefault(u => u.UserId == id);
        if (userLogin != null)
        {
            _userLogins.Remove(userLogin);
        }
        return Task.CompletedTask;
    }

    public async Task<Result<UserLogin>> GetByUserNameAsync(UserLogin user)
    {
        var url = "conta/autenticar";
        try
        {
            var httpClient = _httpClientFactory.CreateClient("economizze");
            var response = await httpClient.PostAsJsonAsync(url, user);
            var jsonResponse = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                user = JsonSerializer.Deserialize<UserLogin>(jsonResponse, _jsonSerializerOptions)!;
                _currentUser = user;
                return Result<UserLogin>.Success(user);
            }
            else
            {
                return Result<UserLogin>.Failure(jsonResponse);
            }

        }
        catch (Exception ex)
        {
            return Result<UserLogin>.Failure($"Erro: {ex.Message}");
        }
    }

    Task<Result<Store>> IService<UserLogin>.AddAsync(UserLogin entity)
    {
        throw new NotImplementedException();
    }

    Task<Result<Store>> IService<UserLogin>.GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }
}
