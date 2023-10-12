using UnityEngine;

namespace Services.Runtime.Localization
{
    public class LocalizationService : ILocalizationService
    {
        private Language _language = Language.English;
        private readonly Localizations _localizationData;

        public LocalizationService()
        {
            _localizationData = FetchDependencies().LocalizationData.Initialize();
        }
        
        public void SetLanguage(Language language) => _language = language;
        public string Localize(string key) => _localizationData.GetLocalizedText(key, _language);

        private LocalizationDependencies FetchDependencies()
        {
            var dependencies = Resources.Load<LocalizationDependencies>("Localization/LocalizationDependencies");

            if (dependencies == null)
            {
                Debug.LogError("No Localization dependencies defined in the Resources folder!");
            }
            
            return dependencies;
        }
    }
}