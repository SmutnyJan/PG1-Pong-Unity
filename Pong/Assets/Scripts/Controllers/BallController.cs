using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using static GameManager;

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
        if (collision.gameObject.name == "Border Right")
        {
            GameManager.PlayerScored(GameManager.Player.Player1);
            ResetBall();
            GameManager.PostGoalScreen();
        }
        else if (collision.gameObject.name == "Border Left")
        {
            GameManager.PlayerScored(GameManager.Player.Player2);
            ResetBall();
            GameManager.PostGoalScreen();
        }
        else if(collision.gameObject.tag == "Player")
        {
            SoundManager.SoundManagerInstance.PlayRandomSoundFromCategory(SoundManager.SoundCategory.Bounce);

        }
    }
    private void ResetBall()
    {
        transform.position = Vector2.zero;
        _rigidbody2D.linearVelocity = Vector2.zero;
    }

    public void LaunchBall(Player recentWinner)
    {
        switch (recentWinner)
        {
            case Player.Player1:
                _rigidbody2D.AddForce(new Vector2(-1, UnityEngine.Random.Range(-0.9f, 0.9f)) * BallForce, ForceMode2D.Impulse);
                break;
            case Player.Player2:
                _rigidbody2D.AddForce(new Vector2(1, UnityEngine.Random.Range(-0.9f, 0.9f)) * BallForce, ForceMode2D.Impulse);
                break;

        }
    }



}
