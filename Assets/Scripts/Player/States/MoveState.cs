using UnityEngine;

namespace Player.States
{
    public class MoveState : IdleState
    {
        public MoveState(PlayerController player) : base(player) {}

        public override void Update()
        {
            if (!__moveAction.IsInProgress())
                StateMachine.TransitionTo(Player.IdleState);    
        }

        public override void FixedUpdate()
        {
            Vector2 velocity = Vector2.right * (Player.MoveSpeed * __moveAction.ReadValue<Vector2>().x);
            Player.RigidBody.MovePosition(
                Player.RigidBody.position + velocity * Time.fixedDeltaTime
            );
        }
    }
}