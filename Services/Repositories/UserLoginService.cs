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
    {
        // Initialize with 3 users, setting CreatedBy during initialization
        _userLogins = new List<UserLogin>
        {
            new UserLogin
            {
                UserId = 1,
                UserUniqueId = Guid.NewGuid(),
                Username = "mrivanlima",
                PasswordHash = "123456",
                PasswordSalt = "salt1",
                IsVerified = true,
                IsActive = true,
                IsLocked = false,
                PasswordAttempts = 0,
                ChangedInitialPassword = true,
               // CreatedBy = 1,  // Set during initialization
                CreatedOn = DateTime.Now.AddDays(-30),
                ModifiedBy = null,
                ModifiedOn = DateTime.Now
            },
            new UserLogin
            {
                UserId = 2,
                UserUniqueId = Guid.NewGuid(),
                Username = "janedoe",
                PasswordHash = "hashedpassword2",
                PasswordSalt = "salt2",
                IsVerified = true,
                IsActive = true,
                IsLocked = false,
                PasswordAttempts = 0,
                ChangedInitialPassword = false,
                //CreatedBy = 1,  // Set during initialization
                CreatedOn = DateTime.Now.AddDays(-25),
                ModifiedBy = null,
                ModifiedOn = DateTime.Now
            },
            new UserLogin
            {
                UserId = 3,
                UserUniqueId = Guid.NewGuid(),
                Username = "alicejohnson",
                PasswordHash = "hashedpassword3",
                PasswordSalt = "salt3",
                IsVerified = false,
                IsActive = false,
                IsLocked = true,
                PasswordAttempts = 3,
                ChangedInitialPassword = false,
                LockedTime = DateTime.Now.AddDays(-1),
                //CreatedBy = 2,  // Set during initialization
                CreatedOn = DateTime.Now.AddDays(-20),
                ModifiedBy = null,
                ModifiedOn = DateTime.Now
            }
        };
    }

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
}
