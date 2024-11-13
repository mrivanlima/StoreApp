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
            builder.Services.AddScoped<IUserLoginService, UserLoginService>();
            builder.Services.AddScoped<IStoreService, StoreService>();
            builder.Services.AddScoped<IStoreAddressService, StoreAddressService>();
            builder.Services.AddScoped<IStreetService, StreetService>();
            builder.Services.AddScoped<IStreetDetailService, StreetDetailService>();
            builder.Services.AddScoped<IStorePhoneService, StorePhoneService>();
            builder.Services.AddScoped<IStateService, StateService>();
            builder.Services.AddScoped<ICityService, CityService>();
            builder.Services.AddScoped<INeighborhoodService, NeighborhoodService>();
            builder.Services.AddScoped<IStoreNeighborhoodSubscriptionService, StoreNeighborhoodSubscriptionService>();
            builder.Services.AddScoped<IStoreCitySubscriptionService, StoreCitySubscriptionService>();
            builder.Services.AddScoped<IQuoteService, QuoteService>();
            builder.Services.AddScoped<IStoreQuoteService, StoreQuoteService>();
            builder.Services.AddScoped<IPrescriptionService, PrescriptionService>();
            builder.Services.AddScoped<IStoreTypeService, StoreTypeService>();

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
