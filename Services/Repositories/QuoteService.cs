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
    public class QuoteService : IQuoteService
    {
        private readonly List<Quote> _quotes;

        public QuoteService()
        {
            // Initializing with some default quotes
            _quotes = new List<Quote>
        {
            new Quote
            {
                QuoteId = 1,
                UserId = 101,
                NeighborhoodId = 1001,
                IsExpired = false,
                IsFullfiled = false,
                CreatedBy = 101,
                CreatedOn = DateTime.Now.AddDays(-10),
                ExpiresOn = DateTime.Now.AddDays(10),
                ModifiedBy = 101,
                ModifiedOn = DateTime.Now.AddDays(-5)
            },
            new Quote
            {
                QuoteId = 2,
                UserId = 102,
                NeighborhoodId = 1002,
                IsExpired = true,
                IsFullfiled = true,
                CreatedBy = 102,
                CreatedOn = DateTime.Now.AddDays(-30),
                ExpiresOn = DateTime.Now.AddDays(-5),
                ModifiedBy = 102,
                ModifiedOn = DateTime.Now.AddDays(-15)
            },
            new Quote
            {
                QuoteId = 3,
                UserId = 103,
                NeighborhoodId = 1003,
                IsExpired = false,
                IsFullfiled = false,
                CreatedBy = 103,
                CreatedOn = DateTime.Now.AddDays(-7),
                ExpiresOn = DateTime.Now.AddDays(3),
                ModifiedBy = 103,
                ModifiedOn = DateTime.Now.AddDays(-2)
            }
        };
        }

        public async Task<IEnumerable<Quote>> GetAllAsync()
        {
            return await Task.FromResult(_quotes);
        }

        public async Task<Quote?> GetByIdAsync(int id)
        {
            return await Task.FromResult(_quotes.FirstOrDefault(q => q.QuoteId == id));
        }

        public async Task AddAsync(Quote quote)
        {
            _quotes.Add(quote);
            await Task.CompletedTask;
        }

        public async Task UpdateAsync(Quote quote)
        {
            var existingQuote = _quotes.FirstOrDefault(q => q.QuoteId == quote.QuoteId);
            if (existingQuote != null)
            {
                existingQuote.UserId = quote.UserId;
                existingQuote.NeighborhoodId = quote.NeighborhoodId;
                existingQuote.IsExpired = quote.IsExpired;
                existingQuote.IsFullfiled = quote.IsFullfiled;
                existingQuote.CreatedBy = quote.CreatedBy;
                existingQuote.CreatedOn = quote.CreatedOn;
                existingQuote.ExpiresOn = quote.ExpiresOn;
                existingQuote.ModifiedBy = quote.ModifiedBy;
                existingQuote.ModifiedOn = quote.ModifiedOn;
            }
            await Task.CompletedTask;
        }

        public async Task DeleteAsync(int id)
        {
            var quote = _quotes.FirstOrDefault(q => q.QuoteId == id);
            if (quote != null)
            {
                _quotes.Remove(quote);
            }
            await Task.CompletedTask;
        }

        

       

        Task<Result<Quote>> IService<Quote>.AddAsync(Quote entity)
        {
            throw new NotImplementedException();
        }

        Task<Result<Quote>> IService<Quote>.GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<Result<Quote>> IService<Quote>.UpdateAsync(Quote entity)
        {
            throw new NotImplementedException();
        }
    }
}
