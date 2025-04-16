using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audiomanager : MonoBehaviour
{
    [Header("-----------Audio Source--------")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource sfxSource;

    [Header("-----------Audio Clip----------")]
    public AudioClip Background;
    public AudioClip Bubble_Thrust;
    public AudioClip Cannon_Shoot;
    public AudioClip Punch_Pop;
    public AudioClip Launch;
    public AudioClip UI_Click;


    private void Start()
    {
        musicSource.clip = Background;
        musicSource.Play();
    }

    public void PlaySFX(AudioClip clip)
    {
        sfxSource.PlayOneShot(clip);
    }
}
