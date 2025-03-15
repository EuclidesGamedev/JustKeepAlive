using UnityEngine;
using UnityEngine.InputSystem;

namespace Player.States
{
    public class IdleState : PlayerState
    {
        protected InputAction __jumpAction;
        protected InputAction __moveAction;

        protected void RestoreJumps()
        {
            Collider2D collider = Physics2D.OverlapPoint(Player.transform.position + Vector3.down);
            if (collider && collider.CompareTag("Ground"))
                Player.JumpCount = 1;
        }
        
        public IdleState(PlayerController player) : base(player)
        {
            __jumpAction = InputSystem.actions.FindAction("Jump");
            __moveAction = InputSystem.actions.FindAction("Move");
        }

        public override void Enter()
        {
            Player.RigidBody.linearVelocityX = 0;
        }

        public override void Update()
        {
            RestoreJumps();
            if (__jumpAction.WasPerformedThisFrame() && Player.JumpCount > 0)
                StateMachine.TransitionTo(Player.JumpState);
            if (__moveAction.IsInProgress())
                StateMachine.TransitionTo(Player.MoveState);
        }
    }
}