using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Services.Runtime.Localization
{
    [CreateAssetMenu(menuName = "Quicorax/LocalizationUtil/LocalizedText", fileName = "LocalizedText")]
    public class LocalizedText : ScriptableObject
    {
        [Serializable]
        public class LocalizedEntry
        {
            public string LanguageKey;
            public string Text;
        }

        [Serializable]
        public class LocalizationAsset
        {
            public string TextKey;
            public List<LocalizedEntry> LocalizedBundle;
        }

        public List<LocalizationAsset> LocalizationsData = new();
        private readonly Dictionary<string, Dictionary<string, string>> LocalizationData = new();

        public LocalizedText Initialize()
        {
            foreach (var localizationBundle in LocalizationsData)
            {
                var serializedLocalizationData = localizationBundle.LocalizedBundle
                    .ToDictionary(x => x.LanguageKey, x => x.Text);

                LocalizationData.Add(localizationBundle.TextKey, serializedLocalizationData);
            }

            return this;
        }

        public string GetLocalizedText(string textKey, string languageKey)
        {
            var localizedText = string.Empty;
            
            if (!LocalizationData.TryGetValue(textKey, out var languagesBundle))
            {
                Debug.LogError($"Localization Error: '{textKey}' Key is not present at LocalizedTexts!");
            }
            
            if (!languagesBundle.TryGetValue(languageKey, out localizedText))
            {
                Debug.LogError($"Localization Error: '{languageKey}' Language for '{textKey}' Key is not present at LocalizedTexts!");
            }

            return localizedText;
        }
    }
}