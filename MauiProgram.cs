using Microsoft.Extensions.Logging;
using StoreApp.Profiles;
using StoreApp.Services.Interfaces;
using StoreApp.Services.Repositories;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace StoreApp
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                });

            builder.Services.AddSingleton(new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                WriteIndented = true,
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
            });

            builder.Services.AddSingleton<SettingsService>();
            builder.Services.AddSingleton<IUserLoginService, UserLoginService>();
            builder.Services.AddSingleton<IStoreService, StoreService>();
            builder.Services.AddSingleton<IStoreAddressService, StoreAddressService>();
            builder.Services.AddSingleton<IStreetService, StreetService>();
            builder.Services.AddSingleton<IStreetDetailService, StreetDetailService>();
            builder.Services.AddSingleton<IStorePhoneService, StorePhoneService>();
            builder.Services.AddSingleton<IStateService, StateService>();
            builder.Services.AddSingleton<ICityService, CityService>();
            builder.Services.AddSingleton<INeighborhoodService, NeighborhoodService>();
            builder.Services.AddSingleton<IStoreNeighborhoodSubscriptionService, StoreNeighborhoodSubscriptionService>();
            builder.Services.AddSingleton<IStoreCitySubscriptionService, StoreCitySubscriptionService>();
            builder.Services.AddSingleton<IQuoteService, QuoteService>();
            builder.Services.AddSingleton<IStoreQuoteService, StoreQuoteService>();
            builder.Services.AddSingleton<IPrescriptionService, PrescriptionService>();
            builder.Services.AddSingleton<IStoreTypeService, StoreTypeService>();

            builder.Services.AddHttpClient("economizze", config =>
            {
                config.BaseAddress = new Uri("https://localhost:7255/api/");
            });
            //builder.Services.AddHttpClient("economizze", config =>
            //{
            //    config.BaseAddress = new Uri("https://localhost:7255/api/");
            //});
            //http://localhost:5240
            //http://economizze.app/api/



            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            //builder.Services.AddAutoMapper(typeof(UserLoginProfile));
            //builder.Services.AddAutoMapper(typeof(StoreProfile));
            //builder.Services.AddAutoMapper(typeof(StoreAddressProfile));
            //builder.Services.AddAutoMapper(typeof(StreetProfile));
            //builder.Services.AddAutoMapper(typeof(StreetViewProfile));

            builder.Services.AddMauiBlazorWebView();

#if DEBUG
    		builder.Services.AddBlazorWebViewDeveloperTools();
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
