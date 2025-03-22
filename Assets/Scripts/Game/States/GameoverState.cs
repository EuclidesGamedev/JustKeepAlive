using AI.State;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Game.States
{
    public class GameoverState : GameState
    {
        public override void Enter()
        {
            Game.AudioHandler.AudioSource.Stop();
            Game.OnGameEnd?.Invoke();
            Level.AudioHandler.Play(2);
            UI.GameOverPanel.gameObject.SetActive(true);
        }
        
        public override void Exit()
        {
            Game.ResetGame();
            Level.AudioHandler.AudioSource.Pause();
            UI.GameOverPanel.gameObject.SetActive(false);
        }

        public override void Update()
        {
            if (InputSystem.actions.FindAction("Cancel").WasPressedThisFrame())
                Game.StateMachine.TransitionTo(Game.MainMenuState);
            if (InputSystem.actions.FindAction("Submit").WasPressedThisFrame())
                Game.StateMachine.TransitionTo(Game.CountingState);
        }
    }
}
