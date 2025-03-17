using UnityEngine;

namespace Game.States
{
    public class GameplayState : GameState
    {
        public override void Update()
        {
            Level.Timer = Mathf.Max(Level.Timer - Time.deltaTime * 8, 0);
        }
    }
}
