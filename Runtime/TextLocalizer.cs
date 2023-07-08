using TMPro;
using UnityEngine;

namespace LocalizationUtil.Runtime
{
    [RequireComponent(typeof(TMP_Text))]
    public class TextLocalizer : MonoBehaviour
    {
        [SerializeField] private SimpleEventBus _refreshText;
        [SerializeField] private string _textKey;
    
        private TMP_Text _text;

        public void Print(string textKey)
        {
            _textKey = textKey;
            _text.text = Localizer.Localize(textKey);
        }

        private void Awake()
        {
            _text = GetComponent<TMP_Text>();
        
            _refreshText.Event += ForceUpdate;
        }

        private void OnDisable()
        {
            _refreshText.Event -= ForceUpdate;
        }

        private void Start()
        {
            if (!string.IsNullOrEmpty(_textKey))
            {
                Print(_textKey);
            }
        }
    
        private void ForceUpdate()
        {
            if (!string.IsNullOrEmpty(_textKey))
            {
                Print(_textKey);
            }
        }
    }
}