using UnityEngine;
using UnityEngine.InputSystem;

namespace Game.States
{
    public class GameWonState : GameState
    {
        public override void Enter()
        {
            UI.GameWonPanel.gameObject.SetActive(true);
        }

        public override void Exit()
        {
            UI.GameWonPanel.gameObject.SetActive(false);
        }
    }
}
