using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private PongInputSystem _inputSystem;
    private InputAction _moveAction;
    private Rigidbody2D _rigidbody;
    private int _count = 0;
    public float speed = 5f; 

    private void Awake()
    {
        _inputSystem = new PongInputSystem();
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {

        _moveAction = _inputSystem.Player.Move;
        _moveAction.Enable();
    }


    private void FixedUpdate()
    {
        float moveDir = _moveAction.ReadValue<float>();

        if(moveDir != 0)
        {
            _rigidbody.AddForce(new Vector2(0, moveDir * speed), ForceMode2D.Force);
        }
        else
        {
            _rigidbody.linearVelocity = Vector2.zero;
        }


        Debug.Log($"Move Direction: {moveDir}");
    }

    private void OnDisable()
    {
        _moveAction?.Disable();
    }
}
