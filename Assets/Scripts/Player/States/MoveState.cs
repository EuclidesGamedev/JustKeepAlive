using UnityEngine;

namespace Player.States
{
    public class MoveState : IdleState
    {
        public MoveState(PlayerController player) : base(player) {}

        public override void Update()
        {
            if (__dashAction.WasPerformedThisFrame())
                StateMachine.TransitionTo(Player.DashState);
            if (OnGround())
            {
                Player.Animator.Play("Run");
                RestoreJumps();
            }
            else Player.Animator.Play("Fall");
            
            UpdateDirection();
            if (__jumpAction.WasPerformedThisFrame() && Player.JumpCount > 0)
                StateMachine.TransitionTo(Player.JumpState);
            if (!__moveAction.IsInProgress())
                StateMachine.TransitionTo(Player.IdleState);    
        }

        public override void FixedUpdate()
        {
            Player.RigidBody.linearVelocityX = Player.MoveSpeed * __moveAction.ReadValue<Vector2>().x;
            if (__moveAction.ReadValue<Vector2>().x != 0)
                Player.LookDirection = __moveAction.ReadValue<Vector2>().x;
        }
    }
}