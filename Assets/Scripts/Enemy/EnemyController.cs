using AI.State;
using Enemy.States;
using Player;
using UnityEngine;
using Utils;

namespace Enemy
{
    public class EnemyController : PooledObject
    {
        private static readonly int Blend = Animator.StringToHash("Blend");

        #region Components
        public Animator Animator { get; private set; }
        public Rigidbody2D Rigidbody { get; private set; }
        public StateMachine StateMachine { get; private set; }
        #endregion
        
        #region Propeties
        public float MoveDirection { get; set; }
        [field: Header("Attributes")]
        [field: SerializeField] public float MoveSpeed { get; set; } = 8f;
        
        [field: Header("On Touching")]
        [field: SerializeField] private string DestroyOnTouchTag { get; set; }
        [field: SerializeField] private string InvertOnTouchTag { get; set; }
        #endregion
        
        #region States
        public FollowState FollowState { get; private set; }
        public IdleState IdleState { get; private set; }
        #endregion

        private void Awake()
        {
            Animator = GetComponent<Animator>();
            Rigidbody = GetComponent<Rigidbody2D>();
            StateMachine = GetComponent<StateMachine>();
        }

        private void Start()
        {
            FollowState = new FollowState(this);
            IdleState = new IdleState(this);
            StateMachine.Initialize(IdleState);
        }

        private void Update()
        {
            Animator.SetFloat(Blend, MoveDirection);
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.collider.CompareTag(InvertOnTouchTag))
                MoveDirection = -MoveDirection;

            if (collision.collider.CompareTag(DestroyOnTouchTag))
                __objectPool.Release(this);
            
            if (collision.collider.CompareTag("Player"))
                collision.gameObject.GetComponent<PlayerController>().TakeDamage();
        }
    }
}
