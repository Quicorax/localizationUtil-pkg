using UnityEngine;

namespace Services.Runtime.Localization
{
    [CreateAssetMenu(menuName = "Quicorax/LocalizationUtil/LocalizationDependencies", fileName = "LocalizationDependencies")]
    public class LocalizationDependencies : ScriptableObject
    {
        public Localizations LocalizationData;
    }
}