using System;
using UnityEngine;

namespace Services.Runtime.Localization
{
    public class LocalizationService : ILocalizationService
    {
        public Action OnLanguageSet { get; set; }

        private Language _language = Language.English;
        private readonly LocalizedText _localizedText;

        public LocalizationService()
        {
            _localizedText = FetchDependencies().Initialize();
        }

        public void SetLanguage(Language language)
        {
            _language = language;

            OnLanguageSet();
        }

        public string Localize(string key) => _localizedText.GetLocalizedText(key, _language);

        private LocalizedText FetchDependencies()
        {
            var dependencies = Resources.Load<LocalizedText>("Localization/LocalizedText");

            if (dependencies == null)
            {
                Debug.LogError("No LocalizedText defined in the Resources folder!");
            }
            
            return dependencies;
        }
    }
}