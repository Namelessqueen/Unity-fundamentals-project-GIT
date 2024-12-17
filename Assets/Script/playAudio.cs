using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playAudio : MonoBehaviour
{
    public AudioSource _Audio;

    public void PlayAudio()
    {
        _Audio.Play();
    }
}
