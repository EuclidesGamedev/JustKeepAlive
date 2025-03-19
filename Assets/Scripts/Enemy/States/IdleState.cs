using Game.Managers;
using UnityEngine;

namespace Enemy.States
{
    public class IdleState : EnemyState
    {
        public IdleState(EnemyController enemy) : base(enemy) {}

        public override void Update()
        {
            if (GameManager.LevelManager.Player.isActiveAndEnabled && OnGround())
                StateMachine.TransitionTo(Enemy.FollowState);

            Enemy.MoveDirection = GameManager.LevelManager.Player.RigidBody.position.x < Enemy.Rigidbody.position.x ? -1 : 1;
        }
    }
}