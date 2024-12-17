using NUnit.Framework;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEditor;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public List<AudioClip> BounceSounds;
    public List<AudioClip> LoseSounds;
    public List<AudioClip> ClickSounds;
    public AudioClip Soundtrack;



    public AudioSource AudioSourceSounds;
    public AudioSource AudioSourceSoundstrack;


    public static SoundManager Instance;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            AudioSourceSounds = GetComponents<AudioSource>()[0];
            AudioSourceSoundstrack = GetComponents<AudioSource>()[1];
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

    }
    void Start()
    {
        AudioSourceSoundstrack.clip = Soundtrack;
        AudioSourceSoundstrack.loop = true;
        AudioSourceSoundstrack.Play();
    }

    void Update()
    {
        
    }

    /*public void PlaySoundByName(string name, AudioSource audioSource)
    {
        AudioClip clip = BounceSounds.Where(x => x.name == name).FirstOrDefault();
        if (clip == null)
        {
            throw new FileNotFoundException();
        }
        PlaySound(clip);


    }*/

    private void PlaySound(AudioClip clip)
    {
        AudioSourceSounds.PlayOneShot(clip);
    }

    public void PlayRandomSoundFromCategory(SoundCategory soundCategory)
    {
        switch (soundCategory)
        {
            case SoundCategory.Bounce:
                AudioClip randomBoucingClip = BounceSounds[Random.Range(0, BounceSounds.Count)];
                PlaySound(randomBoucingClip);
                break;

            case SoundCategory.Lose:
                AudioClip randomLosingClip = LoseSounds[Random.Range(0, LoseSounds.Count)];
                PlaySound(randomLosingClip);
                break;

            case SoundCategory.Click:
                AudioClip randomClickingClip = ClickSounds[Random.Range(0, ClickSounds.Count)];
                PlaySound(randomClickingClip);
                break;
        }
    }




    public enum SoundCategory
    {
        Bounce,
        Lose,
        Click
    }

}
