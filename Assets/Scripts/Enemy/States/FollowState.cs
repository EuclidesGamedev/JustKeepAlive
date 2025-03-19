using Game.Managers;
using UnityEngine;

namespace Enemy.States
{
    public class FollowState : EnemyState
    {
        public FollowState(EnemyController enemy) : base(enemy) {}

        public override void Update()
        {
            if (!GameManager.LevelManager.Player.isActiveAndEnabled | !OnGround())
                StateMachine.TransitionTo(Enemy.IdleState);
        }

        public override void FixedUpdate()
        {
            Enemy.Rigidbody.MovePosition(
                Enemy.Rigidbody.position + Vector2.right * (Enemy.MoveDirection * Enemy.MoveSpeed * Time.fixedDeltaTime) 
            );
        }
    }
}