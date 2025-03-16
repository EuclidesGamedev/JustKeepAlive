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
            Player.RigidBody.linearVelocity = Vector2.right * (Player.LookDirection * Player.DashSpeed);
            _dashTimer = .125f;
        }

        public override void Update()
        {
            _dashTimer -= Time.deltaTime;
            
            if (_dashTimer <= 0)
                StateMachine.TransitionTo(Player.IdleState);
        }
    }
}