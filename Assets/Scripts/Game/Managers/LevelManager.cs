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
        public RectTransform PausingPanel { get; private set; }
        [field: SerializeField]
        public Counter Counter { get; private set; }
        [field: SerializeField]
        public PlayerController Player { get; private set; }
        [field: SerializeField]
        public TMP_Text TimerText {get; private set;}

        private float _timer = 60f;

        public float Timer
        {
            get => _timer;
            set
            {
                _timer = value;
                TimerText.text = _timer.ToString("00.00");
            }
        }

        private void Awake()
        {
            GameManager.LevelManager = this;
        }
    }
}
