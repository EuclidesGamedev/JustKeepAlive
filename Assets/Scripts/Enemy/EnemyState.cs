using AI.State;
using AI.State.Interfaces;
using UnityEngine;

namespace Enemy
{
    public abstract class EnemyState : IState
    {
        protected readonly EnemyController Enemy;
        protected StateMachine StateMachine => Enemy.StateMachine;
        protected EnemyState(EnemyController enemy)
        {
            Enemy = enemy;
        }
        
        public virtual void Enter() {}
        public virtual void Exit() {}
        public virtual void Update() {}
        public virtual void FixedUpdate() {}

        protected bool OnGround()
        {
            return Physics2D.OverlapArea(
                Enemy.transform.position + Vector3.down * .251f + Vector3.left * .25f,
                Enemy.transform.position + Vector3.down * .251f + Vector3.right * .25f,
                LayerMask.GetMask("Ground")
            );
        }
    }
}
