using System.Collections;
using TMPro;
using UnityEngine;
using static GameManager;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI Player1ScoreUIText;
    public TextMeshProUGUI Player2ScoreUIText;
    public TextMeshProUGUI PlayerHasScoredText;
    public TextMeshProUGUI CountdownText;
    public GameObject PostGoalPanel;

    public GameManager GameManager;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void SetPlayerScore(GameManager.Player player, int score)
    {
        TextMeshProUGUI textToChange = player == GameManager.Player.Player1? Player1ScoreUIText: Player2ScoreUIText;

        textToChange.text = score.ToString();
    }

    public void HandleGoal(Player scorer)
    {
        PostGoalPanel.SetActive(true);
        PlayerHasScoredText.text = scorer == Player.Player1? "Player 1 has scored": "Player 2 has scored";
        StartCoroutine(CountdownCoroutine(3));

    }


    private IEnumerator CountdownCoroutine(int seconds)
    {
        CountdownText.text = seconds.ToString();
        for (int i = seconds; i > 0; i--)
        {
            CountdownText.text = i.ToString();
            yield return new WaitForSeconds(1);
        }

        PostGoalPanel.SetActive(false);

        GameManager.OnCountdownFinished();

    }
}
