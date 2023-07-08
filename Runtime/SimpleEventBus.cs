using System;
using UnityEngine;

namespace LocalizationUtil.Runtime
{
    [CreateAssetMenu(menuName = "Quicorax/EventBus/Simple", fileName = "SimpleEventBus")]
    public class SimpleEventBus : ScriptableObject
    {
        public event Action Event = delegate () { };
        public void NotifyEvent() => Event?.Invoke();
    }
}