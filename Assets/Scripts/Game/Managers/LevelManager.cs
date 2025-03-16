using TMPro;
using UnityEngine;

namespace Game.Managers
{
    public class LevelManager : MonoBehaviour
    {
        [SerializeField]
        private TMP_Text _timerText;
        private float _timer = 60.00f;

        private void Awake()
        {
            GameManager.LevelManager = this;
        }

        private void Update()
        {
            _timer = Mathf.Max(_timer - Time.deltaTime * 8, 0);
            _timerText.text = _timer.ToString("00.00");
        }
    }
}
