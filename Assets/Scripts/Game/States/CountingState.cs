using UnityEngine.InputSystem;

namespace Game.States
{
    public class CountingState : GameState
    {
        public override void Enter()
        {
            Game.ResetGame();
            Level.Counter.gameObject.SetActive(true);
            Level.Counter.Animator.Play("Counting");
            InputSystem.actions.FindActionMap("Player").Disable();
        }

        public override void Exit()
        {
            Game.AudioHandler.Play(0);
            Level.Counter.Animator.Play("Empty");
            Level.Counter.gameObject.SetActive(false);
        }
    }
}
