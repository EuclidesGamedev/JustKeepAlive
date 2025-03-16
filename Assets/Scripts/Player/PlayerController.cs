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
        public DashState DashState { get; private set; }
        public IdleState IdleState { get; private set; }
        public JumpState JumpState { get; private set; }
        public MoveState MoveState { get; private set; }
        #endregion
        
        #region Components
        public Rigidbody2D RigidBody { get; private set; }
        #endregion
        
        #region Propeties
        [field: SerializeField] public float DashSpeed { get; private set; } = 8f;
        [field: SerializeField] public float MoveSpeed { get; private set; } = 5f;
        [field: SerializeField] public float JumpForce { get; private set; } = 2f;
        public float LookDirection { get; set; } = 1f;
        public uint JumpCount { get; set; } = 1;
        #endregion

        private void Awake()
        {
            RigidBody = GetComponent<Rigidbody2D>();
            StateMachine = GetComponent<StateMachine>();
        }

        private void Start()
        {
            DashState = new DashState(this);
            IdleState = new IdleState(this);
            JumpState = new JumpState(this);
            MoveState = new MoveState(this);
            StateMachine.Initialize(IdleState);
        }
    }
}
