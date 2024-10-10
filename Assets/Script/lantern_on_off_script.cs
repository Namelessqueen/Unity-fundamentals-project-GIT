using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lantern_on_off_script : MonoBehaviour
{
    public GameObject LanternOn;
    public GameObject LanternOff;
    public Collider Player;

    private void OnTriggerEnter(Collider other)
    {
        if (other == Player)
        {
            Debug.Log("Light on");
            LanternOff.SetActive(false);
            LanternOn.SetActive(true);
        }
    }
}
