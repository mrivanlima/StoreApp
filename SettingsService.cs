using Economizze.Library;
using System.Text.Json;

namespace StoreApp
{
    public class SettingsService
    {
        private string appVersion { get; set; }
        private DateTime today { get; set; }
        private DateTime oneYearFromToday { get; set; }
        private DateTime VersionDate { get; set; }
        private DateTime StartDate { get; set; }
        private static readonly string _filePath = Path.Combine(AppContext.BaseDirectory, "Settings.json");
        public AppSettings appSettings;

        public SettingsService()
        {
            today = DateTime.Now;
            oneYearFromToday = today.AddYears(1);
            VersionDate = today;
            StartDate = today;
            appVersion = "1.0.0";
        }

        /// <summary>
        /// Loads the application settings from a JSON file.
        /// </summary>
        /// <returns>AppSettings object with configuration values.</returns>
        public async Task<AppSettings> LoadSettingsAsync()
        {
            if (File.Exists(_filePath))
            {
                try
                {
                    var json = await File.ReadAllTextAsync(_filePath);
                    appSettings = JsonSerializer.Deserialize<AppSettings>(json) ?? new AppSettings();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Unexpected error loading settings: {ex.Message}");
                    appSettings = new AppSettings();
                }
            }
            return appSettings;
        }

        /// <summary>
        /// Saves the application settings to a JSON file.
        /// </summary>
        public async Task SaveSettingsAsync()
        {
            var json = JsonSerializer.Serialize(appSettings, new JsonSerializerOptions { WriteIndented = true });
            await File.WriteAllTextAsync(_filePath, json);
        }

        public async Task SaveSettingsByStoreAsync(Store entity)
        {
            await Task.Delay(0);
            appSettings.AppVersion = appVersion;
            appSettings.StoreUniqueId = entity.StoreUniqueId;
            appSettings.StoreId = entity.StoreId;
            appSettings.EndDate = oneYearFromToday;
            appSettings.StoreName = entity.StoreName;
            appSettings.VersionDate = today;
            appSettings.StartDate = today;
            appSettings.IsActive = true;
        }

        /// <summary>
        /// Erases all information in the settings file by deleting it.
        /// </summary>
        public async Task ResetSettingsAsync()
        {
            try
            {
                // Check if the settings file exists
                if (File.Exists(_filePath))
                {
                    // Delete the settings file
                    File.Delete(_filePath);
                }

                // Reset the in-memory settings object to default
                appSettings = new AppSettings();

                // Optionally, save the default settings back to the file
                await SaveSettingsAsync();

                Console.WriteLine("Settings have been reset successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error resetting settings: {ex.Message}");
            }
        }
    }
}
