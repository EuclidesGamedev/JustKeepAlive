using TMPro;
using UnityEngine;

namespace Game.Managers
{
    public class UIManager : MonoBehaviour
    {
        [field: SerializeField]
        public RectTransform GameOverPanel { get; private set; }
        [field: SerializeField]
        public RectTransform PausingPanel { get; private set; }
        [field: SerializeField]
        public TMP_Text TimerText { get; private set; }

        private void Awake()
        {
            GameManager.UIManager = this;
        }
    }
}
