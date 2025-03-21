using UnityEngine;
using UnityEngine.InputSystem;

namespace Player.States
{
    public class IdleState : PlayerState
    {
        protected InputAction __dashAction;
        protected InputAction __jumpAction;
        protected InputAction __moveAction;

        protected void RestoreJumps()
        {
            Player.JumpCount = 1;
        }
        
        public IdleState(PlayerController player) : base(player)
        {
            __dashAction = InputSystem.actions.FindAction("Dash");
            __jumpAction = InputSystem.actions.FindAction("Jump");
            __moveAction = InputSystem.actions.FindAction("Move");
        }

        public override void Enter()
        {
            Player.RigidBody.linearVelocityX = 0;
        }

        public override void Update()
        {
            if (__dashAction.WasPerformedThisFrame())
                StateMachine.TransitionTo(Player.DashState);
            if (OnGround())
            {
                Player.Animator.Play("Idle");
                RestoreJumps();
            }
            else Player.Animator.Play("Fall");
            
            if (__jumpAction.WasPerformedThisFrame() && Player.JumpCount > 0)
                StateMachine.TransitionTo(Player.JumpState);
            if (__moveAction.IsInProgress())
                StateMachine.TransitionTo(Player.MoveState);
        }

        protected void UpdateDirection()
        {
            if (__moveAction.ReadValue<Vector2>().x != 0)
                Player.LookDirection = Mathf.Round(__moveAction.ReadValue<Vector2>().x);
        }
    }
}