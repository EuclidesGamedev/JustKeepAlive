using UnityEngine;
using UnityEngine.InputSystem;

namespace Game.States
{
    public class GameplayState : GameState
    {
        public override void Enter()
        {
            Game.OnGameStart?.Invoke();
            Game.AudioHandler.AudioSource.UnPause();
            InputSystem.actions.FindActionMap("Player").Enable();
        }

        public override void Exit()
        {
            Game.AudioHandler.AudioSource.Pause();
        }

        public override void Update()
        {
            Level.Timer = Mathf.Max(Level.Timer - Time.deltaTime * 8, 0);
            if (Level.Timer <= 0)
                Game.StateMachine.TransitionTo(Game.GameWonState);
            if (InputSystem.actions.FindAction("UI/Cancel").WasPressedThisFrame())
                Game.StateMachine.TransitionTo(Game.PausingState);
        }
    }
}
