using NUnit.Framework;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public List<AudioClip> BounceSounds;

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

    public void PlaySoundByName(string name)
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
        _audioSource.clip = clip;
        _audioSource.Play();
    }

    public void PlayRandomSoundFromCategory(SoundCategory soundCategory)
    {
        switch (soundCategory)
        {
            case SoundCategory.Bounce:
                AudioClip randomBoucingClip = BounceSounds[Random.Range(0, BounceSounds.Count)];
                PlaySound(randomBoucingClip);
                break;
        }
    }




    public enum SoundCategory
    {
        Bounce,
    }

}
