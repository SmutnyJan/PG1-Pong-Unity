using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class BallController : MonoBehaviour
{
    public GameManager GameManager;
    public float BallForce;

    private Rigidbody2D _rigidbody2D;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        _rigidbody2D.AddForce(new Vector2(0.5f, 0.5f) * BallForce, ForceMode2D.Impulse);
    }

    void Update()
    {
        //Keep the ball at constant speed
        Vector2 unit = _rigidbody2D.linearVelocity.normalized;
        _rigidbody2D.linearVelocity = unit * 10;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Border Right") //Player 1 scored point
        {
            GameManager.PlayerScored(GameManager.Player.Player1);
            ResetAndLaunchBall(new Vector2(0, 0), Vector2.right);
        }
        else if (collision.gameObject.name == "Border Left") //Player 2 scored point
        {
            GameManager.PlayerScored(GameManager.Player.Player2);
            ResetAndLaunchBall(new Vector2(0, 0), Vector2.left);

        }
    }

    private void ResetAndLaunchBall(Vector2 resetTo, Vector2 launchTo)
    {
        transform.position = resetTo;
        _rigidbody2D.linearVelocity = Vector2.zero;

        StartCoroutine(WaitAndDo(3, () =>
        {
            _rigidbody2D.AddForce(launchTo * BallForce, ForceMode2D.Impulse);
        }));
    }

    private IEnumerator WaitAndDo(float seconds, Action action)
    {
        yield return new WaitForSeconds(seconds);
        action?.Invoke();
    }




}
