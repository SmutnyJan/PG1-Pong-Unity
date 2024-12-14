using NUnit.Framework;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public List<AudioClip> BounceSounds;
    public List<AudioClip> LoseSounds;

    private AudioSource _audioSource;


    public static SoundManager SoundManagerInstance;

    void Awake()
    {
        SoundManagerInstance = this;
        _audioSource = GetComponent<AudioSource>();

    }
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void PlaySoundByName(string name, AudioSource audioSource)
    {
        AudioClip clip = BounceSounds.Where(x => x.name == name).FirstOrDefault();
        if (clip == null)
        {
            throw new FileNotFoundException();
        }
        PlaySound(clip);


    }

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
        }
    }




    public enum SoundCategory
    {
        Bounce,
        Lose
    }

}
