namespace LocalizationUtil.Runtime
{
    public static class Localizer
    {
        private static Language _language;
        private static Localizations _localizationData;

        public static void Initialize(Localizations localizationData) => _localizationData = localizationData.Initialize();
        public static void SetLanguage(Language language) => _language = language;
        public static string Localize(string key) => _localizationData.GetLocalizedText(key, _language);
    }
}