using UnityEngine;
using UnityEngine.InputSystem;

namespace Game.States
{
    public class PausingState : GameState
    {
        public override void Enter()
        {
            UI.PausingPanel.gameObject.SetActive(true);
            Time.timeScale = 0;
        }

        public override void Update()
        {
            if (InputSystem.actions.FindAction("UI/Cancel").WasPressedThisFrame())
                Game.StateMachine.TransitionTo(Game.GameplayState);
        }

        public override void Exit()
        {
            UI.PausingPanel.gameObject.SetActive(false);
            Time.timeScale = 1;
        }
    }
}
