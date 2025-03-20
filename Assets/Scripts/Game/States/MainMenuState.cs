using Enemy;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Game.States
{
    public class MainMenuState : GameState
    {
        public override void Enter()
        {
            UI.MainMenu.gameObject.SetActive(true);
        }

        public override void Exit()
        {
            UI.MainMenu.gameObject.SetActive(false);
        }

        public override void Update()
        {
            if (InputSystem.actions.FindActionMap("Player").enabled)
                InputSystem.actions.FindActionMap("Player").Disable();
        }
    }
}
