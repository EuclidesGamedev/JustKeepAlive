using Player;
using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

namespace Game.Managers
{
    public class LevelManager : MonoBehaviour
    {
        public AudioHandler AudioHandler { get; private set; }
        [field: SerializeField]
        public UIAnimator Counter { get; private set; }
        [field: SerializeField]
        public CinemachineImpulseSource Impulse { get; private set; }
        [field: SerializeField]
        public PlayerController Player { get; private set; }

        private bool _isToShake = true;
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

        public void ShakeScreen()
        {
            if (!_isToShake) return;
            Impulse.GenerateImpulse();
        }
    }
}
