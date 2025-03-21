using UnityEngine;
using UnityEngine.InputSystem;

namespace Game.States
{
    public class GameplayState : GameState
    {
        public override void Enter()
        {
            Game.OnGameStart?.Invoke();
            InputSystem.actions.FindActionMap("Player").Enable();
        }
        
        public override void Update()
        {
            Level.Timer = Mathf.Max(Level.Timer - Time.deltaTime, 0);
            if (Level.Timer <= 0)
                Game.StateMachine.TransitionTo(Game.GameWonState);
            if (InputSystem.actions.FindAction("UI/Cancel").WasPressedThisFrame())
                Game.StateMachine.TransitionTo(Game.PausingState);
        }
    }
}
