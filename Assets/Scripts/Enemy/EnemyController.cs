using System;
using AI.State;
using Enemy.States;
using Game.Managers;
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
        public Collider2D Collider { get; private set; }
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
        public HurtState HurtState { get; private set; }
        public IdleState IdleState { get; private set; }
        #endregion

        private void Awake()
        {
            Animator = GetComponent<Animator>();
            Collider = GetComponent<Collider2D>();
            Rigidbody = GetComponent<Rigidbody2D>();
            StateMachine = GetComponent<StateMachine>();
            FollowState = new FollowState(this);
            HurtState = new HurtState(this);
            IdleState = new IdleState(this);
        }

        private void Start()
        {
            StateMachine.Initialize(IdleState);
        }

        private void Update()
        {
            Animator.SetFloat(Blend, MoveDirection);
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.collider.CompareTag(InvertOnTouchTag))
            {
                MoveDirection = -MoveDirection;
                GameManager.LevelManager.ShakeScreen();
            }

            if (collision.collider.CompareTag(DestroyOnTouchTag))
            {
                GameManager.LevelManager.ShakeScreen();
                StateMachine.TransitionTo(HurtState);
            }

            if (collision.collider.CompareTag("Player"))
                collision.gameObject.GetComponent<PlayerController>().TakeDamage();
        }

        private void OnEnable()
        {
            gameObject.layer = LayerMask.NameToLayer("Default");
            StateMachine.Initialize(IdleState);
        }
        
        public void Release()
        {
            Destroy(gameObject);
        }
    }
}
