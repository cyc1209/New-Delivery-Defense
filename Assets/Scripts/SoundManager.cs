using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    AudioSource audioSource;

    public AudioClip glassCrash;
    public AudioClip updownCrash;
    public AudioClip correct;
    public AudioClip buttonClick;

    public AudioClip background;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        DontDestroyOnLoad(this);
    }
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayGlassCrashSound()
    {
        audioSource.PlayOneShot(glassCrash);
    }

    public void PlayUpDownCrashSound()
    {
        audioSource.PlayOneShot(updownCrash);
    }

    public void PlayCorrectSound()
    {
        audioSource.PlayOneShot(correct);
    }

    public void PlayButtonClickSound()
    {
        audioSource.PlayOneShot(buttonClick);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
