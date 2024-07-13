using System;
using System.Collections.Generic;
using UnityEngine;

namespace Services.Runtime.Localization
{
    [CreateAssetMenu(menuName = "Quicorax/LocalizationUtil/LocalizedText", fileName = "LocalizedText")]
    public class LocalizedText : ScriptableObject
    {
        [Serializable]
        public class LocalizationAsset
        {
            public string TextKey;
            public LocalizationBundle LocalizedBundle;
        }

        [Serializable]
        public class LocalizationBundle
        {
            public string EnglishText;
            public string SpanishText;
            public string CatalanText;
        }

        public List<LocalizationAsset> LocalizationsData = new();
        private readonly Dictionary<string, LocalizationBundle> LocalizationData = new();

        public LocalizedText Initialize()
        {
            foreach (var localizationBundle in LocalizationsData)
            {
                LocalizationData.Add(localizationBundle.TextKey, localizationBundle.LocalizedBundle);
            }

            return this;
        }

        public string GetLocalizedText(string textKey, Language language)
        {
            return language switch
            {
                Language.English => LocalizationData[textKey].EnglishText,
                Language.Catalan => LocalizationData[textKey].CatalanText,
                _ => LocalizationData[textKey].SpanishText,
            };
        }
    }
}