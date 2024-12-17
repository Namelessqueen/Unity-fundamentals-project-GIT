using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartAnimation : MonoBehaviour
{
    public Animator animator;
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {   
            animator.SetTrigger("Start");
        }
    }
}
