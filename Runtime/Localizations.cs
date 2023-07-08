using System;
using System.Collections.Generic;
using UnityEngine;

namespace LocalizationUtil.Runtime
{
    [CreateAssetMenu(menuName = "Quicorax/Localization/LocalizationsData", fileName = "Localizations Data")]
    public class Localizations : ScriptableObject
    {
        [Serializable]
        public class LocalizationAsset
        {
            public string TextKey;
            public LocalizationBundle LocalizedText;
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

        public Localizations Initialize()
        {
            foreach (var localizationBundle in LocalizationsData)
            {
                LocalizationData.Add(localizationBundle.TextKey, localizationBundle.LocalizedText);
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