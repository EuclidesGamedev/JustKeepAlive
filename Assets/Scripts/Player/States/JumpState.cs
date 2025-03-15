using UnityEngine;

namespace Player.States
{
    public class JumpState : MoveState
    {
        private float _targetInY;
        public JumpState(PlayerController player) : base(player) { }

        public override void Enter()
        {
            _targetInY = Player.transform.position.y + Player.JumpForce;
            Player.JumpCount--;
        }

        public override void Exit()
        {
            Player.RigidBody.linearVelocity = Vector2.down;
        }

        public override void Update()
        {
            if (Mathf.Abs(Player.RigidBody.position.y - _targetInY) < .05f)
                StateMachine.TransitionTo(Player.IdleState);
            if (!__jumpAction.IsInProgress())
                StateMachine.TransitionTo(Player.IdleState);
        }

        public override void FixedUpdate()
        {
            Vector2 newPosition = new Vector2(
                Player.RigidBody.position.x + Player.MoveSpeed * __moveAction.ReadValue<Vector2>().x * Time.fixedDeltaTime,
                Mathf.Lerp(Player.RigidBody.position.y, _targetInY, .25f)
            );
            Player.RigidBody.MovePosition(newPosition);
        }
    }
}