using AutoMapper;
using Economizze.Library;
using StoreApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreApp.Profiles
{
    public class StoreJsonProfile : Profile
    {
        public StoreJsonProfile()
        {
            CreateMap<StoreJsonModel, StoreJson>().ReverseMap();
        }
    }
}
