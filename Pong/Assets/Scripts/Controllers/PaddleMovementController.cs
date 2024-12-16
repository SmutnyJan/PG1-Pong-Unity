using UnityEngine;
using UnityEngine.InputSystem;

public class PaddleMovementController : MonoBehaviour
{
    public float Speed = 5f;
    public bool IsPlayerOne = true;
    public GameManager GameManager;
    public bool IsPaused = false;

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
        if(IsPlayerOne)
        {
            _moveAction = _inputSystem.Player1.Move;
        }
        else
        {
            _moveAction = _inputSystem.Player2.Move;
        }

        _moveAction.Enable();
    }

    public void OnShowMenu()
    {
        if(!IsPlayerOne)
        {
            Debug.Log(IsPaused);
            if (!IsPaused) 
            {
                GameManager.PauseMenu(true);
            }
            else
            {
                GameManager.PauseMenu(false);
            }
        }
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
