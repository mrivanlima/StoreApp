using AutoMapper;
using Economizze.Library;
using StoreApp.Model;


namespace StoreApp.Profiles
{
    public class QuoteProfile : Profile
    {
        public QuoteProfile()
        {
            CreateMap<QuoteModel, Quote>().ReverseMap();
        }
    }
}
