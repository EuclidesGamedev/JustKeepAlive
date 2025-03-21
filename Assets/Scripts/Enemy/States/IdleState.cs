using Game.Managers;
using UnityEngine;

namespace Enemy.States
{
    public class IdleState : EnemyState
    {
        public IdleState(EnemyController enemy) : base(enemy) {}
        
        public override void Update()
        {
            Enemy.Animator.Play(OnGround() ? "Idle" : "Fall");

            if (GameManager.LevelManager.Player.RigidBody.bodyType == RigidbodyType2D.Dynamic && OnGround())
                StateMachine.TransitionTo(Enemy.FollowState);

            Enemy.MoveDirection = GameManager.LevelManager.Player.RigidBody.position.x < Enemy.Rigidbody.position.x ? -1 : 1;
        }
    }
}