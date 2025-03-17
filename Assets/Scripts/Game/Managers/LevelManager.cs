using Player;
using TMPro;
using UnityEngine;

namespace Game.Managers
{
    public class LevelManager : MonoBehaviour
    {
        [field: SerializeField]
        public RectTransform GameOverPanel { get; private set; }
        
        [field: SerializeField]
        public Counter Counter { get; private set; }
        [field: SerializeField]
        public PlayerController Player { get; private set; }
        [field: SerializeField]
        public TMP_Text TimerText {get; private set;}
        public float Timer { get; set; } = 60.00f;

        private void Awake()
        {
            GameManager.LevelManager = this;
        }

        public void UpdateTimerText()
        {
            TimerText.text = Timer.ToString("00.00");
        }
    }
}
