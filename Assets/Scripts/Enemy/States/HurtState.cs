using UnityEngine;

namespace Enemy.States
{
    public class HurtState : EnemyState
    {
        public HurtState(EnemyController enemy) : base(enemy) {}

        public override void Enter()
        {
            Enemy.gameObject.layer = LayerMask.NameToLayer("Unplayer");
            Enemy.Rigidbody.AddForceX(-Enemy.MoveDirection, ForceMode2D.Impulse);
            Enemy.Animator.Play("Hit");
        }
    }
}