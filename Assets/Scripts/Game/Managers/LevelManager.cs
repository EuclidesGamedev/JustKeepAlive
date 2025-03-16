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
            _timer -= Time.deltaTime;
            _timerText.text = _timer.ToString().Substring(0, _timer.ToString().IndexOf('.') + 3);
        }
    }
}
