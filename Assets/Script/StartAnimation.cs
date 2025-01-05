using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartAnimation : MonoBehaviour
{
    public Animator animator;
    public string TriggerName;

    private void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("Player"))
        {   
            animator.SetTrigger(TriggerName);
            gameObject.SetActive(false);
        }
    }
}
