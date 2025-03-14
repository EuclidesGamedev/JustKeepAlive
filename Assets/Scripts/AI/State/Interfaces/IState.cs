using UnityEngine;

namespace AI.State.Interfaces
{
    public interface IState
    {
        void Enter();
        void Exit();
        void Update();
        void FixedUpdate();
    }
}