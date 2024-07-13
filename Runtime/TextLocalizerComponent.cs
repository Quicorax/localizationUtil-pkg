using System;
using TMPro;
using UnityEngine;
using Zenject;

namespace Services.Runtime.Localization
{
    [RequireComponent(typeof(TMP_Text))]
    public class TextLocalizerComponent : MonoBehaviour
    {
        [SerializeField] private string _textKey;

        private ILocalizationService _localizationService;
        private TMP_Text _text;

        [Inject]
        public void Construct(ILocalizationService localizationService)
        {
            _localizationService = localizationService;
        }

        private void Awake()
        {
            _text = GetComponent<TMP_Text>();

            _localizationService.OnLanguageSet += ForceUpdate;
        }

        private void Start()
        {
            if (!string.IsNullOrEmpty(_textKey))
            {
                Print(_textKey);
            }
        }

        private void OnDestroy()
        {
            _localizationService.OnLanguageSet -= ForceUpdate;
        }

        private void ForceUpdate()
        {
            if (!string.IsNullOrEmpty(_textKey))
            {
                Print(_textKey);
            }
        }

        private void Print(string textKey)
        {
            _textKey = textKey;
            _text.text = _localizationService.Localize(_textKey);
        }
    }
}