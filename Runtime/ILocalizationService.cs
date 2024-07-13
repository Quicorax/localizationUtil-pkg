using System;

namespace Services.Runtime.Localization
{
    public interface ILocalizationService
    {
        Action OnLanguageSet { set; get; }
        void SetLanguage(Language language);
        string Localize(string key);
    }
}