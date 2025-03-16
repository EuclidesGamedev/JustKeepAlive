using AI.State.Interfaces;
using Game.Managers;

namespace Game
{
    public abstract class GameState : IState
    {
        protected GameManager Game => GameManager.Instance;
        protected LevelManager Level => GameManager.LevelManager;
        
        public abstract void Enter();
        public abstract void Exit();
        public abstract void Update();
        public abstract void FixedUpdate();
    }
}