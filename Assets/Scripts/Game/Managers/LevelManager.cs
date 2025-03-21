using Player;
using UnityEngine;
using UnityEngine.Events;

namespace Game.Managers
{
    public class LevelManager : MonoBehaviour
    {
        public AudioHandler AudioHandler { get; private set; }
        [field: SerializeField]
        public UIAnimator Counter { get; private set; }
        [field: SerializeField]
        public PlayerController Player { get; private set; }

        private float _timer = 60f;

        public float Timer
        {
            get => _timer;
            set
            {
                _timer = value;
                GameManager.UIManager.TimerText.text = Timer.ToString("00.00");
            }
        }

        private void Awake()
        {
            GameManager.LevelManager = this;
            AudioHandler = GetComponent<AudioHandler>();
        }
    }
}
