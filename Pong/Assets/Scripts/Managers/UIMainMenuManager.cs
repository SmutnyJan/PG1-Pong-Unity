using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIMainMenuManager : MonoBehaviour
{
    void Start()
    {
        
    }
    void Update()
    {
        
    }

    void ClickSound()
    {
        SoundManager.Instance.PlayRandomSoundFromCategory(SoundManager.SoundCategory.Click);
    }

    public void QuitGame()
    {
        ClickSound();
        StartCoroutine(WaitAndQuit());
        #if UNITY_STANDALONE
        Application.Quit();
        #endif
        #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
        #endif

        
    }


    private IEnumerator WaitAndQuit()
    {
        yield return new WaitForSeconds(0.5f);
        #if UNITY_STANDALONE
                Application.Quit();
        #endif
        #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(1);
        ClickSound();
    }

    public void DisplaySettings()
    {
        SceneManager.LoadScene(2);
        ClickSound();
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
        ClickSound();
        SettingsManager.Instance.SetGameSettingsDependencies();
    }
}
