using TMPro;
using UnityEngine;

namespace Game.Managers
{
    public class UIManager : MonoBehaviour
    {
        [field: Header("Game menus")]
        [field: SerializeField]
        public RectTransform MainMenu { get; private set; }
        [field: SerializeField]
        public RectTransform OptionsMenu { get; private set; }
        [field: SerializeField]
        public RectTransform CreditsMenu { get; private set; }
        
        [field: Header("UI")]
        [field: SerializeField]
        public RectTransform GameOverPanel { get; private set; }
        [field: SerializeField]
        public RectTransform GameWonPanel { get; private set; }
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
