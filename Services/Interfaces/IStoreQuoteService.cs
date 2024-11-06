using Economizze.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreApp.Services.Interfaces
{
    public interface IStoreQuoteService : IService<StoreQuote>
    {
        Task<IEnumerable<StoreQuote>> GetQuoteByStoreIdAsync(int storeId);
    }
}
