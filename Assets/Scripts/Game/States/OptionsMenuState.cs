namespace Game.States
{
    public class OptionsMenuState : GameState
    {
        public override void Enter()
        {
            UI.OptionsMenu.gameObject.SetActive(true);
        }

        public override void Exit()
        {
            UI.OptionsMenu.gameObject.SetActive(false);
        }
    }
}