using UnityEngine;

namespace Game.States
{
    public class CountingState : GameState
    {
        public override void Enter()
        {
            Level.Counter.gameObject.SetActive(true);
            Level.Counter.Animator.Play("Counting");
        }

        public override void Exit()
        {
            Level.Counter.Animator.Play("Empty");
            Level.Counter.gameObject.SetActive(false);
        }
    }
}
