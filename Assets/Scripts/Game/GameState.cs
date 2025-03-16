using AI.State.Interfaces;
using Game.Managers;

namespace Game
{
    public abstract class GameState : IState
    {
        protected GameManager Game => GameManager.Instance;
        protected LevelManager Level => GameManager.LevelManager;
        
        public virtual void Enter() {}
        public virtual void Exit() {}
        public virtual void Update() {}
        public virtual void FixedUpdate() {}
    }
}