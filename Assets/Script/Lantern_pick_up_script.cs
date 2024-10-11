using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lantern_pick_up_script : MonoBehaviour
{
    public GameObject groundLantern;
    public GameObject playerLantern;
    public Collider  player;

    private void OnTriggerStay(Collider other)
    {
        if(other == player && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("Pick up");
            groundLantern.SetActive(false);
            playerLantern.SetActive(true);
            Destroy(this);
        }
    }
}
