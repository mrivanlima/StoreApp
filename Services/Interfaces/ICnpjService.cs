﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreApp.Services.Interfaces
{
    public interface ICnpjService
    {
        Task<String> GetCnpjDataAsync(string cnpj);
    }
}
