using TMPro;
using UnityEngine;

namespace Game.Managers
{
    public class LevelManager : MonoBehaviour
    {
        [field: SerializeField]
        public Counter Counter { get; private set; }
        [field: SerializeField]
        public TMP_Text TimerText {get; private set;}
        public float Timer { get; set; } = 60.00f;

        private void Awake()
        {
            GameManager.LevelManager = this;
        }
    }
}
