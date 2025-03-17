using AI.State;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Game.States
{
    public class GameoverState : GameState
    {
        public override void Enter()
        {
            Level.GameOverPanel.gameObject.SetActive(true);
        }
        
        public override void Exit()
        {
            Level.GameOverPanel.gameObject.SetActive(false);
        }

        public override void Update()
        {
            if (InputSystem.actions.FindAction("Submit").WasPressedThisFrame())
                Game.StateMachine.TransitionTo(Game.CountingState);
        }
    }
}
