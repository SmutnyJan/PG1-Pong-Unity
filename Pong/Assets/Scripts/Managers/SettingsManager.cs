using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingsManager : MonoBehaviour
{
    public static SettingsManager Instance;
    public SaveSettings CurrentSettings;


    private const string _settingsFileName = "settings.json";

    public class SaveSettings
    {
        public float SoundVolume;
        public float SoundtrackVolume;
    }

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            Instance.CurrentSettings = null;
            DontDestroyOnLoad(gameObject);


        }
        else
        {
            Destroy(gameObject);
        }

    }

    void Start()
    {
        // Naèti nastavení pøi spuštìní
        Load();
        Debug.Log($"Loaded settings: SoundVolume={CurrentSettings.SoundVolume}, MusicVolume={CurrentSettings.SoundtrackVolume}");
        SetGameSettingsDependencies();
    }

    public void Save(SaveSettings saveSettings)
    {
        Debug.Log("Saving settings...");

        // Aktualizace aktuálních hodnot s omezením na rozsah 0-1
        CurrentSettings.SoundVolume = Mathf.Clamp(saveSettings.SoundVolume, 0f, 1f);
        CurrentSettings.SoundtrackVolume = Mathf.Clamp(saveSettings.SoundtrackVolume, 0f, 1f);

        // Serializace do JSON
        string json = JsonUtility.ToJson(CurrentSettings, true);

        // Uložení do souboru
        File.WriteAllText(GetSettingsFilePath(), json);
        Debug.Log($"Settings saved to {GetSettingsFilePath()}: SoundVolume={CurrentSettings.SoundVolume}, MusicVolume={CurrentSettings.SoundtrackVolume}");
    }

    public void Load()
    {
        Debug.Log("Loading settings...");
        string filePath = GetSettingsFilePath();

        if (File.Exists(filePath))
        {
            // Ètení JSON souboru a deserializace
            string json = File.ReadAllText(filePath);
            CurrentSettings = JsonUtility.FromJson<SaveSettings>(json);
            Debug.Log($"Settings loaded from file: SoundVolume={CurrentSettings.SoundVolume}, MusicVolume={CurrentSettings.SoundtrackVolume}");
        }
        else
        {
            // Pokud soubor neexistuje, použij výchozí nastavení
            Debug.LogWarning("Settings file not found. Using default values.");
            CurrentSettings = new SaveSettings
            {
                SoundVolume = SoundManager.Instance.AudioSourceSounds.volume,
                SoundtrackVolume = SoundManager.Instance.AudioSourceSoundstrack.volume
            };
            Debug.Log($"Default settings applied: SoundVolume={CurrentSettings.SoundVolume}, MusicVolume={CurrentSettings.SoundtrackVolume}");
        }
    }

    private string GetSettingsFilePath()
    {
        string filePath = Path.Combine(Application.persistentDataPath, _settingsFileName);
        Debug.Log($"Settings file path: {filePath}");
        return filePath;
    }

    void Update()
    {
    }

    public void SetGameSettingsDependencies()
    {
        SoundManager.Instance.AudioSourceSounds.volume = CurrentSettings.SoundVolume;
        SoundManager.Instance.AudioSourceSoundstrack.volume = CurrentSettings.SoundtrackVolume;
    }

}
