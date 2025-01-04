using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingParticleScript : MonoBehaviour
{
    public FirstPersonController _ControllerScript;
    ParticleSystem _particleSystem;
    void Start()
    {
        _particleSystem = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    
    void Update()
    {
        var em = _particleSystem.emission;
        if (_ControllerScript.isWalking) 
        {
            em.enabled = true;
        }
        else em.enabled = false;
    }
}
