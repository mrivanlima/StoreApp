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
    public class UserService : IService<User>
    {
        private readonly List<User> _users;

        public UserService()
        {
            // Initialize with 3 users
            _users = new List<User>
        {
            new User
            {
                UserId = 1,
                UserFirstName = "John",
                UserMiddleName = "A",
                UserLastName = "Doe",
                Cpf = "12345678900",
                Rg = "MG1234567",
                PhoneNumber = "123-456-7890",
                DateOfBirth = new DateTime(1990, 1, 1),
                CreatedBy = 1,
                CreatedOn = DateTime.Now,
                ModifiedBy = null,
                ModifiedOn = DateTime.Now
            },
            new User
            {
                UserId = 2,
                UserFirstName = "Jane",
                UserMiddleName = "B",
                UserLastName = "Smith",
                Cpf = "09876543211",
                Rg = "SP7654321",
                PhoneNumber = "098-765-4321",
                DateOfBirth = new DateTime(1985, 5, 15),
                CreatedBy = 1,
                CreatedOn = DateTime.Now,
                ModifiedBy = null,
                ModifiedOn = DateTime.Now
            },
            new User
            {
                UserId = 3,
                UserFirstName = "Alice",
                UserMiddleName = "C",
                UserLastName = "Johnson",
                Cpf = "11223344556",
                Rg = "RJ3344556",
                PhoneNumber = "111-222-3333",
                DateOfBirth = new DateTime(1992, 3, 22),
                CreatedBy = 2,
                CreatedOn = DateTime.Now,
                ModifiedBy = null,
                ModifiedOn = DateTime.Now
            }
        };
        }

        public Task<IEnumerable<User>> GetAllAsync()
        {
            return Task.FromResult(_users.AsEnumerable());
        }

        public Task<User?> GetByIdAsync(int id)
        {
            var user = _users.FirstOrDefault(u => u.UserId == id);
            return Task.FromResult(user);
        }

        public Task AddAsync(User entity)
        {
            entity.UserId = _users.Max(u => u.UserId) + 1; // Auto-increment ID
            _users.Add(entity);
            return Task.CompletedTask;
        }

        public Task UpdateAsync(User entity)
        {
            var existingUser = _users.FirstOrDefault(u => u.UserId == entity.UserId);
            if (existingUser != null)
            {
                // Update the existing user's properties
                existingUser.UserFirstName = entity.UserFirstName;
                existingUser.UserMiddleName = entity.UserMiddleName;
                existingUser.UserLastName = entity.UserLastName;
                existingUser.Cpf = entity.Cpf;
                existingUser.Rg = entity.Rg;
                existingUser.PhoneNumber = entity.PhoneNumber;
                existingUser.DateOfBirth = entity.DateOfBirth;
                existingUser.ModifiedBy = entity.ModifiedBy;
                existingUser.ModifiedOn = DateTime.Now;
            }
            return Task.CompletedTask;
        }

        public Task DeleteAsync(int id)
        {
            var user = _users.FirstOrDefault(u => u.UserId == id);
            if (user != null)
            {
                _users.Remove(user);
            }
            return Task.CompletedTask;
        }

        Task<Result<Store>> IService<User>.AddAsync(User entity)
        {
            throw new NotImplementedException();
        }

        Task<Result<Store>> IService<User>.GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }

}
