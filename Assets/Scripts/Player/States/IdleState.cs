using UnityEngine.InputSystem;

namespace Player.States
{
    public class IdleState : PlayerState
    {
        protected InputAction __moveAction;
        
        public IdleState(PlayerController player) : base(player)
        {
            __moveAction = InputSystem.actions.FindAction("Move");
        }
        
        public override void Update()
        {
            if  (__moveAction.IsInProgress())
                StateMachine.TransitionTo(Player.MoveState);
        }
    }
}