using Economizze.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreApp.Services.Interfaces
{
    public interface IUserLoginService : IService<UserLogin>
    {
        Task<UserLogin?> GetByUserNameAsync(UserLogin login);

    }
}
