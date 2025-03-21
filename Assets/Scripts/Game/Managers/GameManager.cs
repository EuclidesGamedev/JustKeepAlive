using AI.State;
using Game.States;
using UnityEngine;
using UnityEngine.Events;

namespace Game.Managers
{
    public class GameManager : MonoBehaviour
    {
        public UnityEvent OnGameStart;
        public UnityEvent OnGameEnd;
        
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
        public static CameraManager CameraManager { get; set; }
        public static LevelManager LevelManager { get; set; }
        public static UIManager UIManager { get; set; }
        #endregion
        
        #region MonoBehaviour
        public AudioHandler AudioHandler { get; private set; }
        private void Start()
        {
            AudioHandler = GetComponent<AudioHandler>();
            SetupStatemachine();
        }
        #endregion
        
        #region Public Methods

        public void GoToMainMenu()
        {
            StateMachine.TransitionTo(MainMenuState);
        }

        public void GoToAboutMenu()
        {
            StateMachine.TransitionTo(AboutMenuState);
        }
        
        public void StartCounting()
        {
            StateMachine.TransitionTo(CountingState);
        }
        
        public void StartGameplay()
        {
            StateMachine.TransitionTo(GameplayState);
        }

        public void GameOver()
        {
            StateMachine.TransitionTo(GameoverState);
        }

        public void ResetGame()
        {
            LevelManager.Player.Reset();
            LevelManager.Timer = 60f;
        }

        public void QuitApplication()
        {
            UnityEditor.EditorApplication.isPlaying = false;
            Application.Quit();
        }
        #endregion
        
        #region State
        public CountingState CountingState { get; private set; }
        public GameoverState GameoverState { get; private set; }
        public GameplayState GameplayState { get; private set; }
        public GameWonState GameWonState { get; private set; }
        public MainMenuState MainMenuState { get; private set; }
        public AboutMenuState AboutMenuState { get; private set; }
        public PausingState PausingState { get; private set; }
        public StateMachine StateMachine { get; private set; }
        private void SetupStatemachine()
        {
            CountingState = new CountingState();
            GameoverState = new GameoverState();
            GameplayState = new GameplayState();
            GameWonState = new GameWonState();
            MainMenuState = new MainMenuState();
            AboutMenuState = new AboutMenuState();
            PausingState = new PausingState();

            StateMachine = GetComponent<StateMachine>();
            StateMachine.Initialize(MainMenuState);
        }
        #endregion
    }
}
