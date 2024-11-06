using Economizze.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreApp.Services.Interfaces
{
    public interface IStreetDetailService
    {
        Task<StreetDetailView?> GetStreetDetailByIdAsync(int streetId);
        Task<StreetDetailView> GetStreetDetailByZipCodeAsync(string zipCode);
        StreetDetailView StreetDetailView { get; set; }
    }
}
