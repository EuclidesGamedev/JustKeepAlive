using UnityEngine;

namespace Game.States
{
    public class CountingState : GameState
    {
        public override void Enter()
        {
            Level.Counter.Animator.Play("Counting");
        }
    }
}
