using UnityEngine;
using UnityEngine.InputSystem;

namespace Game.States
{
    public class GameWonState : GameState
    {
        public override void Enter()
        {
            Game.OnGameEnd?.Invoke();
            Game.AudioHandler.AudioSource.Stop();
            Level.AudioHandler.Play(3);
            UI.GameWonPanel.gameObject.SetActive(true);
        }

        public override void Exit()
        {
            Level.AudioHandler.AudioSource.Stop();
            UI.GameWonPanel.gameObject.SetActive(false);
            Game.ResetGame();
        }
    }
}
