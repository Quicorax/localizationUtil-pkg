using System;
using System.Collections.Generic;

namespace Services.Runtime.Localization
{
    [Serializable]
    public class RemoteLocale
    {
        [Serializable]
        public class LocalizedEntry
        {
            public string LanguageKey;
            public string Text;
        }

        [Serializable]
        public class LocalizationElement
        {
            public string TextKey;
            public List<LocalizedEntry> LocalizedBundle;
        }

        public List<LocalizationElement> data = new();
    }
}