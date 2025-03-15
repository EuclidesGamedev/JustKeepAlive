using UnityEngine;

namespace Player.States
{
    public class MoveState : IdleState
    {
        public MoveState(PlayerController player) : base(player) {}

        public override void Update()
        {
            RestoreJumps();
            if (__jumpAction.WasPerformedThisFrame() && Player.JumpCount > 0)
                StateMachine.TransitionTo(Player.JumpState);
            if (!__moveAction.IsInProgress())
                StateMachine.TransitionTo(Player.IdleState);    
        }

        public override void FixedUpdate()
        {
            Player.RigidBody.linearVelocityX = Player.MoveSpeed * __moveAction.ReadValue<Vector2>().x;
        }
    }
}