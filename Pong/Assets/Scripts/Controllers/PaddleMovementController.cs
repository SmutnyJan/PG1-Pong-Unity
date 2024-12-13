using UnityEngine;
using UnityEngine.InputSystem;

public class PaddleMovementController : MonoBehaviour
{
    public float Speed = 5f;
    public bool IsPlayerOne = true;

    private PongInputSystem _inputSystem;
    private InputAction _moveAction;
    private Rigidbody2D _rigidbody;

    private void Awake()
    {
        _inputSystem = new PongInputSystem();
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {

        _moveAction = IsPlayerOne ? _inputSystem.Player1.Move : _inputSystem.Player2.Move;
        _moveAction.Enable();
    }


    private void FixedUpdate()
    {
        float moveDir = _moveAction.ReadValue<float>();

        if (moveDir != 0)
        {
            _rigidbody.AddForce(new Vector2(0, moveDir * Speed), ForceMode2D.Impulse);
        }
        else
        {
            _rigidbody.linearVelocity = Vector2.zero;
        }
    }

    private void OnDisable()
    {
        _moveAction?.Disable();
    }
}
