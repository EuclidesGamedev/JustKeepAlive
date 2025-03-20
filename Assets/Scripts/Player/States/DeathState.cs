namespace Player.States
{
    public class DeathState : PlayerState
    {
        public DeathState(PlayerController player) : base(player) {}

        public override void Enter()
        {
            Player.Animator.Play("Death");
        }
    }
}