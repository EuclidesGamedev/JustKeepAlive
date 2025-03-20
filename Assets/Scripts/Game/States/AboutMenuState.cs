namespace Game.States
{
    public class AboutMenuState : GameState
    {
        public override void Enter()
        {
            UI.CreditsMenu.gameObject.SetActive(true);
        }

        public override void Exit()
        {
            UI.CreditsMenu.gameObject.SetActive(false);
        }
    }
}