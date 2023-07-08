using UnityEngine;

namespace LocalizationUtil.Runtime
{
    public class LocalizationSampleCaller : MonoBehaviour
    {
        [SerializeField] private SimpleEventBus _refreshText;
        [SerializeField] private Localizations _localizationsData;
        [SerializeField] private TextLocalizer _text;
        [SerializeField] private string _textKey;

        private void Awake()
        {
            Localizer.Initialize(_localizationsData);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                Localizer.SetLanguage(Language.English);
                _refreshText.NotifyEvent();
            }

            if (Input.GetKeyDown(KeyCode.W))
            {
                Localizer.SetLanguage(Language.Spanish);
                _refreshText.NotifyEvent();
            }

            if (Input.GetKeyDown(KeyCode.E))
            {
                Localizer.SetLanguage(Language.Catalan);
                _refreshText.NotifyEvent();
            }

            if (Input.GetKeyDown(KeyCode.A))
            {
                _text.Print(_textKey);
            }
        }
    }
}