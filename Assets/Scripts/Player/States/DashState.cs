using UnityEngine;

namespace Player.States
{
    public class DashState : PlayerState
    {
        private float _dashDirection;
        private float _dashTimer;
        public DashState(PlayerController player) : base(player) {}
        public override void Enter()
        {
            Player.Animator.Play("Jump");
            Player.RigidBody.linearVelocityX = Player.LookDirection * Player.DashSpeed;
            Player.AudioHandler.Play(0);
            _dashTimer = .175f;
        }

        public override void Update()
        {
            _dashTimer -= Time.deltaTime;
            
            if (_dashTimer <= 0)
                StateMachine.TransitionTo(Player.IdleState);
        }

        public override void Exit()
        {
            _dashTimer = .5f;

        }
    }
}