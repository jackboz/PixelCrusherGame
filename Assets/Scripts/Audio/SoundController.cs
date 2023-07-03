using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SoundController : MonoBehaviour
{
    public AudioSource AudioSource { get; private set; }

    float soundTimerWithoutRepeat = 0f;
    float MaxTimeWithoutRepeat = 0.5f;

    void Awake()
    {
        AudioSource = gameObject.GetComponent<AudioSource>();
        if (AudioSource == null)
        {
            Debug.LogError("AudioSource is not set");
        }
    }

    public void PlaySoundWithoutRepeat(AudioClip audio)
    {
        if (soundTimerWithoutRepeat > MaxTimeWithoutRepeat)
        {
            
            AudioSource.PlayOneShot(audio);
            soundTimerWithoutRepeat = 0;
        }
    }

    void Update()
    {
        soundTimerWithoutRepeat += Time.deltaTime;
    }

    public void Reset()
    {
        soundTimerWithoutRepeat = 0f;
    }
}
