using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    public UIManager UIManager;
    public BallController BallController;
    public PaddleMovementController MenuControllingPlayer;
    public Renderer BallRender;

    private int _player1Score = 0;
    private int _player2Score = 0;

    private Player _recentPlayerScorer = Player.None;

    private void Awake()
    {
        Time.timeScale = 1;

    }
    void Start()
    {
        Cursor.visible = false;
        UIManager.SetPlayerScore(Player.Player1, _player1Score);
        UIManager.SetPlayerScore(Player.Player2, _player2Score);
        UIManager.InitScreen();
    }

    void Update()
    {

    }


    public void PlayerScored(Player player)
    {
        switch (player)
        {
            case Player.Player1:
                _player1Score++;
                UIManager.SetPlayerScore(Player.Player1, _player1Score);
                _recentPlayerScorer = Player.Player1;
                break;
            case Player.Player2:
                _player2Score++;
                UIManager.SetPlayerScore(Player.Player2, _player2Score);
                _recentPlayerScorer = Player.Player2;
                break;
        }
    }

    public void PostGoalScreen()
    {
        UIManager.HandleGoal(_recentPlayerScorer);
    }

    public void OnCountdownFinished()
    {
        BallController.LaunchBall(_recentPlayerScorer);
    }

    public void PauseMenu(bool shouldBeOpened)
    {
        if(shouldBeOpened)
        {
            Cursor.visible = true;
            BallRender.enabled = false;

            Vector3 ballCameraPosition = Camera.main.WorldToScreenPoint(BallController.transform.position);

            Mouse.current.WarpCursorPosition(new Vector2(ballCameraPosition.x, ballCameraPosition.y));


            UIManager.ShowPauseMenu();
            Time.timeScale = 0;        
        }
        else
        {
            Cursor.visible = false;
            BallRender.enabled = true;
            UIManager.HidePauseMenu();
            Time.timeScale = 1;
        }
        MenuControllingPlayer.IsPaused = !MenuControllingPlayer.IsPaused;
    }


    public enum Player
    {
        None,
        Player1,
        Player2
    }
}
