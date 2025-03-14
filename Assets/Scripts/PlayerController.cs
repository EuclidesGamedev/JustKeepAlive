using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private InputAction _jumpAction;
    private InputAction _moveAction;
    private uint _jumpCounter = 1;
    [SerializeField]
    [Range(1f, 10f)]
    private float _jumpForce = 5f;
    [SerializeField]
    [Range(1f, 20f)]
    private float _moveSpeed = 5f;
    private Rigidbody2D _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }
    
    private void Start()
    {
        _jumpAction = InputSystem.actions["Jump"];
        _moveAction = InputSystem.actions["Move"];
    }

    private void Update()
    {
        if (_jumpAction.WasPerformedThisFrame() && _jumpCounter > 0) {
            _jumpCounter--;
            _rb.AddForceY(_jumpForce,  ForceMode2D.Impulse);
        }
        _rb.linearVelocityX = _moveAction.ReadValue<Vector2>().x * _moveSpeed;

        if (_jumpCounter == 0 && _rb.linearVelocityY < .5)
        {
            if (Physics2D.OverlapPoint(
                transform.position + Vector3.down
            )) _jumpCounter = 1;
        }
    }
}
