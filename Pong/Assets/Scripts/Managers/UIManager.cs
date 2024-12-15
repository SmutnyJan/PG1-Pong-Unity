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
    public TextMeshProUGUI InitialCountdownText;
    public GameObject PostGoalPanel;
    public GameObject InitialPanel;

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

    public void InitScreen()
    {
        InitialPanel.SetActive(true);
        StartCoroutine(InitCountdownCoroutine(3));
    }

    public void HandleGoal(Player scorer)
    {
        PostGoalPanel.SetActive(true);
        PlayerHasScoredText.text = (scorer == Player.Player1) ? "Player 1 has scored": "Player 2 has scored";


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
        CountdownText.text = "Play!";
        yield return new WaitForSeconds(1);

        PostGoalPanel.SetActive(false);

        GameManager.OnCountdownFinished();

    }

    private IEnumerator InitCountdownCoroutine(int seconds)
    {
        InitialCountdownText.text = seconds.ToString();
        for (int i = seconds; i > 0; i--)
        {
            InitialCountdownText.text = i.ToString();
            yield return new WaitForSeconds(1);
        }
        InitialCountdownText.text = "Play!";
        yield return new WaitForSeconds(1);

        InitialPanel.SetActive(false);

        GameManager.OnCountdownFinished();

    }
}
