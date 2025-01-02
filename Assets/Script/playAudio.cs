using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playAudio : MonoBehaviour
{
    public bool PlayOnAwake;
    public AudioSource _Audio;


    public void PlayAudio()
    {
        _Audio.Play();
    }

    private void Start()
    {
        if (PlayOnAwake)
        {
            _Audio.playOnAwake = true;
        }
    }
}
