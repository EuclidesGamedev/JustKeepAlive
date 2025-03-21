using AI.State.Interfaces;
using AI.State;
using UnityEngine;

namespace Player
{
    public abstract class PlayerState : IState
    {
        protected readonly PlayerController Player;
        protected StateMachine StateMachine => Player.StateMachine;
        protected bool OnGround()
        {
            return Physics2D.OverlapArea(
                Player.transform.position + Vector3.down * .49f + Vector3.left * .5f,
                Player.transform.position + Vector3.down * .51f + Vector3.right * .5f,
                LayerMask.GetMask("Ground")
            );
        }
        protected PlayerState(PlayerController player)
        {
            Player = player;
        }
        
        public virtual void Enter() {} 
        public virtual void Exit() {}
        public virtual void Update() {} 
        public virtual void FixedUpdate() {} 
    }
}