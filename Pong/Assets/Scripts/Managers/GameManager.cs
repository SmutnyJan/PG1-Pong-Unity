using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI Player1ScoreUIText;
    public TextMeshProUGUI Player2ScoreUIText;


    private int _player1Score = 0;
    private int _player2Score = 0;
    void Start()
    {
        Player1ScoreUIText.text = _player1Score.ToString();
        Player2ScoreUIText.text = _player2Score.ToString();
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
                Player1ScoreUIText.text = _player1Score.ToString();
                break;
            case Player.Player2:
                _player2Score++;
                Player2ScoreUIText.text = _player2Score.ToString();
                break;
        }
    }


    public enum Player
    {
        Player1,
        Player2
    }
}
