using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartRoutiine : MonoBehaviour
{
    public GameObject Target;
    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.G))
        {
            Target.GetComponent<Look_At>().StartRotation();
        }
    }
    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Target.GetComponent<Look_At>().StartRotation();
        }
    }
}
