using UnityEngine;
using UnityEngine.SceneManagement;

public class UIPauseMenuManager : MonoBehaviour
{
    public GameManager GameManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BackToMenu()
    {
        SoundManager.Instance.PlayRandomSoundFromCategory(SoundManager.SoundCategory.Click);
        SceneManager.LoadScene(0);
    }

    public void Continue()
    {
        SoundManager.Instance.PlayRandomSoundFromCategory(SoundManager.SoundCategory.Click);
        GameManager.PauseMenu(false);
    }
}
