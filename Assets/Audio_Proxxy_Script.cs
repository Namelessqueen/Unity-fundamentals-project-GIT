using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio_Proxxy_Script : MonoBehaviour
{
    AudioSource audioSource;
    GameObject Player;
    float dist;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        Player = GameObject.FindGameObjectWithTag("Player");
        audioSource.volume = 0;
    }

    void Update()
    {
        dist = Vector3.Distance(transform.position, Player.transform.position);

        if(dist < 40) audioSource.volume =   (100/ dist)/10;
        else audioSource.volume = 0;
    }
}
