using AutoMapper;
using Economizze.Library;
using StoreApp.Model;


namespace StoreApp.Profiles
{
    public class StoreNeighborhoodSubscriptionProfile : Profile
    {
        public StoreNeighborhoodSubscriptionProfile()
        {
            CreateMap<StoreNeighborhoodSubscriptionModel, StoreNeighborhoodSubscription>().ReverseMap();
        }
    }
}
