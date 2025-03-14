using AI.State.Interfaces;
using UnityEngine;

namespace AI.State
{
    public class StateMachine : MonoBehaviour
    {
        public IState CurrentState { get; private set; }

        #region State execution
        private void Update()
        {
            CurrentState.Update();
        }

        private void FixedUpdate()
        {
            CurrentState.FixedUpdate();
        }
        #endregion

        #region State management
        public void Initialize(IState state)
        {
            CurrentState = state;
            CurrentState.Enter();
        }

        public void TransitionTo(IState newState)
        {
            CurrentState.Exit();
            Initialize(newState);
        }
        #endregion
    }
}
