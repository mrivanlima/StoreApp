﻿using Economizze.Library;
using StoreApp.Wrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreApp.Services.Interfaces
{
    public interface IStoreService :IService<Store>
    {
        public Store? currentStore { get; }

    }
}
