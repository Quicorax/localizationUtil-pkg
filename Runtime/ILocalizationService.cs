namespace Services.Runtime.Localization
{
    public interface ILocalizationService
    {
        void SetLanguage(Language language);
        string Localize(string key);
    }
}