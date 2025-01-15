using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    // Music
    public AudioSource musicSource;

    public AudioClip mainThemeMusic;

    // SFX
    public AudioSource sfxSource;
    public AudioClip lose;
    public AudioClip win;
    public AudioClip enemyHurt;
    public AudioClip playerHurt;
    public AudioClip playerShoot;
    public AudioClip enemyShoot;

    public static AudioManager Instance {get; private set;}

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }        
    }

    void Start()
    {
        musicSource.clip = mainThemeMusic;
        musicSource.loop = true;
        musicSource.Play();
    }

    public void PlayPlayerHurt()
    {
        sfxSource.PlayOneShot(playerHurt);
    }

    public void PlayShoot()
    {
        sfxSource.PlayOneShot(playerShoot);
    }
    public void PlayEnemyShoot()
    {
        sfxSource.PlayOneShot(enemyShoot);
    }

    public void PlayDestroyEnemy()
    {
        sfxSource.PlayOneShot(enemyHurt);
    }

    public void PlayLoseSFX()
    {
        sfxSource.PlayOneShot(lose);
    }
    
    public void PlayWinSFX()
    {
        sfxSource.PlayOneShot(win);
    }
}
