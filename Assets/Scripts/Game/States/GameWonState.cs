using UnityEngine;
using UnityEngine.InputSystem;

namespace Game.States
{
    public class GameWonState : GameState
    {
        public override void Enter()
        {
            Game.OnGameEnd?.Invoke();
            UI.GameWonPanel.gameObject.SetActive(true);
        }

        public override void Exit()
        {
            UI.GameWonPanel.gameObject.SetActive(false);
        }
    }
}
