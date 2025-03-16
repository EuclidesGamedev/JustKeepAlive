using UnityEngine;

namespace Game.Managers
{
    public class GameManager : MonoBehaviour
    {
        #region Singleton
        public static GameManager Instance { get; private set; }

        private void Awake()
        {
            if  (Instance == null)
                Instance = this;
            else Destroy(gameObject);
            DontDestroyOnLoad(gameObject);
        }
        #endregion
        
        #region Managers
        public static LevelManager LevelManager { get; set; }
        #endregion
    }
}
