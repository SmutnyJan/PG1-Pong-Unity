using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public UIManager UIManager;
    public BallController BallController;

    private int _player1Score = 0;
    private int _player2Score = 0;

    private Player _recentPlayerScorer;

    
    void Start()
    {
        UIManager.SetPlayerScore(Player.Player1, _player1Score);
        UIManager.SetPlayerScore(Player.Player2, _player2Score);
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


    public enum Player
    {
        Player1,
        Player2
    }
}
