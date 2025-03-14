using AI.State;
using Player.States;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Player
{
    public class PlayerController : MonoBehaviour
    {
        #region State
        public StateMachine StateMachine { get; private set; }
        public IdleState IdleState { get; private set; }
        public MoveState MoveState { get; private set; }
        #endregion
        
        #region Components
        public Rigidbody2D RigidBody { get; private set; }
        #endregion
        
        #region Propeties

        [field: SerializeField] public float MoveSpeed { get; private set; } = 5f;
        #endregion

        private void Awake()
        {
            RigidBody = GetComponent<Rigidbody2D>();
            StateMachine = GetComponent<StateMachine>();
        }

        private void Start()
        {
            IdleState = new IdleState(this);
            MoveState = new MoveState(this);
            StateMachine.Initialize(IdleState);
        }
    }
}
