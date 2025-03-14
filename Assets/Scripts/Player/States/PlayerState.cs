using AI.State.Interfaces;
using AI.State;

namespace Player.States
{
    public abstract class PlayerState : IState
    {
        protected readonly PlayerController Player;
        protected StateMachine StateMachine => Player.StateMachine;
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