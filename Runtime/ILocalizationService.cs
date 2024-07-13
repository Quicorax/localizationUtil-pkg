using System;

namespace Services.Runtime.Localization
{
    public interface ILocalizationService
    {
        Action OnLanguageSet { set; get; }
        void SetLanguage(string language);
        string Localize(string textKey);
    }
}