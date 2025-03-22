using UnityEngine;
using UnityEngine.InputSystem;

namespace Player.States
{
    public class JumpState : MoveState
    {
        private float _jumpTimer;
        public JumpState(PlayerController player) : base(player) { }

        public override void Enter()
        {
            Player.RigidBody.AddForceY(12f, ForceMode2D.Impulse);
            Player.Animator.Play("Jump");
            Player.AudioHandler.Play(0);
            Player.JumpCount--;
        }

        public override void Exit()
        {
            Player.RigidBody.linearVelocity = Vector2.down;
        }

        public override void Update()
        {
            if (OnGround() && Player.RigidBody.linearVelocity.y <= 0f)
                StateMachine.TransitionTo(Player.IdleState);
            if (!__jumpAction.IsInProgress())
                StateMachine.TransitionTo(Player.IdleState);
            if (__dashAction.WasPerformedThisFrame())
                StateMachine.TransitionTo(Player.DashState);
            UpdateDirection();
        }

        public override void FixedUpdate()
        {
            Player.RigidBody.linearVelocityX = InputSystem.actions.FindAction("Move").ReadValue<Vector2>().x * Player.MoveSpeed;
        }
    }
}