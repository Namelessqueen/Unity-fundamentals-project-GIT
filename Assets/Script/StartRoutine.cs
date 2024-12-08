using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;

public class StartRoutine : MonoBehaviour
{
    public GameObject Target;
    public Animator anim;

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Target.GetComponent<Look_At>().StartRotation();
            anim.SetTrigger("TriggerIn");
            gameObject.SetActive(false);
        }
    }
}
