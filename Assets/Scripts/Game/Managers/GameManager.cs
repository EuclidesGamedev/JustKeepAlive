using AI.State;
using Game.States;
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
        
        
        #region MonoBehaviour
        private void Start()
        {
            SetupStatemachine();
        }
        #endregion
        
        #region Public Methods
        public void StartGameplay()
        {
            StateMachine.TransitionTo(GameplayState);
        }
        #endregion
        
        #region State
        public CountingState CountingState { get; private set; }
        public GameoverState GameoverState { get; private set; }
        public GameplayState GameplayState { get; private set; }
        public PausingState PausingState { get; private set; }
        public StateMachine StateMachine { get; private set; }
        private void SetupStatemachine()
        {
            CountingState = new CountingState();
            GameoverState = new GameoverState();
            GameplayState = new GameplayState();
            PausingState = new PausingState();

            StateMachine = GetComponent<StateMachine>();
            StateMachine.Initialize(CountingState);
        }
        #endregion
    }
}
