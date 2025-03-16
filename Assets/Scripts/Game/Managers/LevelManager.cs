using UnityEngine;

namespace Game.Managers
{
    public class LevelManager : MonoBehaviour
    {
        private void Awake()
        {
            GameManager.LevelManager = this;
        }
    }
}
