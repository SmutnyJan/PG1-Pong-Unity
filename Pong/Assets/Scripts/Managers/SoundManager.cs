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

    private AudioSource _audioSource;
    private AudioSource _audioSourceMusic;


    public static SoundManager SoundManagerInstance;

    void Awake()
    {
        if (SoundManagerInstance == null)
        {
            SoundManagerInstance = this;
            _audioSource = GetComponent<AudioSource>();
            _audioSourceMusic = GetComponents<AudioSource>()[1];
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

    }
    void Start()
    {
        _audioSourceMusic.clip = Soundtrack;
        _audioSourceMusic.loop = true;
        _audioSourceMusic.Play();
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
        _audioSource.PlayOneShot(clip);
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
