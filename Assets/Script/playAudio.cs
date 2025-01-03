using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playAudio : MonoBehaviour
{
    public bool PlayOnTrigger;
    public AudioSource _Audio;


    public void PlayAudio()
    {
        _Audio.Play();
    }
       
}
