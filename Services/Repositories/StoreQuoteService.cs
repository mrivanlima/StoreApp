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
    public class StoreQuoteService : IStoreQuoteService
    {
        private readonly List<StoreQuote> _storeQuotes;

        public StoreQuoteService()
        {
            // Initializing with some default store quotes
            _storeQuotes = new List<StoreQuote>
        {
            new StoreQuote
            {
                StoreQuoteId = 1,
                StoreId = 1,
                QuoteId = 1,
                IsActive = true,
                IsVisualized = false,
                IsSubmitted = true,
                IsAccepted = false,
                IsFinalized = false
            },
            new StoreQuote
            {
                StoreQuoteId = 2,
                StoreId = 1,
                QuoteId = 2,
                IsActive = false,
                IsVisualized = true,
                IsSubmitted = true,
                IsAccepted = true,
                IsFinalized = false
            },
            new StoreQuote
            {
                StoreQuoteId = 3,
                StoreId = 103,
                QuoteId = 1003,
                IsActive = true,
                IsVisualized = true,
                IsSubmitted = false,
                IsAccepted = false,
                IsFinalized = true
            }
        };
        }

        public async Task<IEnumerable<StoreQuote>> GetAllAsync()
        {
            return await Task.FromResult(_storeQuotes);
        }

        public async Task<IEnumerable<StoreQuote>> GetQuoteByStoreIdAsync(int storeId)
        {
            var storeQuotes = _storeQuotes.Where(sq => sq.StoreId == storeId);
            return await Task.FromResult(storeQuotes);
        }

        public async Task<StoreQuote?> GetByIdAsync(int id)
        {
            return await Task.FromResult(_storeQuotes.FirstOrDefault(sq => sq.StoreQuoteId == id));
        }

        public async Task AddAsync(StoreQuote storeQuote)
        {
            _storeQuotes.Add(storeQuote);
            await Task.CompletedTask;
        }

        public async Task UpdateAsync(StoreQuote storeQuote)
        {
            var existingStoreQuote = _storeQuotes.FirstOrDefault(sq => sq.StoreQuoteId == storeQuote.StoreQuoteId);
            if (existingStoreQuote != null)
            {
                existingStoreQuote.StoreId = storeQuote.StoreId;
                existingStoreQuote.QuoteId = storeQuote.QuoteId;
                existingStoreQuote.IsActive = storeQuote.IsActive;
                existingStoreQuote.IsVisualized = storeQuote.IsVisualized;
                existingStoreQuote.IsSubmitted = storeQuote.IsSubmitted;
                existingStoreQuote.IsAccepted = storeQuote.IsAccepted;
                existingStoreQuote.IsFinalized = storeQuote.IsFinalized;
            }
            await Task.CompletedTask;
        }

        public async Task DeleteAsync(int id)
        {
            var storeQuote = _storeQuotes.FirstOrDefault(sq => sq.StoreQuoteId == id);
            if (storeQuote != null)
            {
                _storeQuotes.Remove(storeQuote);
            }
            await Task.CompletedTask;
        }

        Task<Result<Store>> IService<StoreQuote>.AddAsync(StoreQuote entity)
        {
            throw new NotImplementedException();
        }

        Task<Result<Store>> IService<StoreQuote>.GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }

}
