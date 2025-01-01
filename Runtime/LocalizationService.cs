using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Services.Runtime.Localization
{
    public class LocalizationService : ILocalizationService
    {
        public Action OnLanguageSet { get; set; } = delegate { };

        private string _language = "English";
        private readonly Dictionary<string, Dictionary<string, string>> _localizationData = new();

        public LocalizationService()
        {
            var serializedData = JsonUtility.FromJson<RemoteLocale>(FetchDependencies());

            foreach (var remoteLocalization in serializedData.data)
            {
                _localizationData.Add(remoteLocalization.TextKey,
                    remoteLocalization.LocalizedBundle.ToDictionary(x => x.LanguageKey, x => x.Text));
            }
        }

        public void SetLanguage(string language)
        {
            _language = language;

            OnLanguageSet();
        }

        public string Localize(string textKey)
        {
            var localizedText = string.Empty;

            if (!_localizationData.TryGetValue(textKey, out var languagesBundle))
            {
                Debug.LogError($"Localization Error: '{textKey}' Key is not present at LocalizedTexts!");
            }

            if (!languagesBundle.TryGetValue(_language, out localizedText))
            {
                Debug.LogError($"Localization Error: '{_language}' Language for '{textKey}' Key is not present at LocalizedTexts!");
            }

            return localizedText;
        }

        private string FetchDependencies()
        {
            var dependencies = Resources.Load("Localization/LocalizedText").ToString();

            if (dependencies == null)
            {
                Debug.LogError("No LocalizedText defined in the Resources folder!");
            }

            return dependencies;
        }
    }
}
