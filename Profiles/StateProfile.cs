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
    public class StateProfile : Profile
    {
        public StateProfile()
        {
            CreateMap<StateModel, State>().ReverseMap();
        }
    }
}
