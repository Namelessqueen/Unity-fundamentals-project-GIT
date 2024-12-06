using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Plank_interaction : MonoBehaviour
{
    GameObject player;
    public bool NoImputNeeded = false;
    public GameObject[] Objects;
    bool Bool = true;


    private void Update()
    {
        if(player == null) player = GameObject.FindGameObjectWithTag("Player");
    }
    private void OnTriggerStay(Collider other)
    {
        
        if (other == player.GetComponent<CapsuleCollider>() && (Input.GetKey(KeyCode.E) || NoImputNeeded))
        {
            for (int i = 0; i < Objects.Length; i++)
            {
                Bool ^= Objects[i].activeSelf;
                Objects[i].SetActive(Bool);
                Bool = true;
                //Debug.Log("this is object: " + Objects[i].name + "| and the bool: " + Bool);
            }
        }
    }
}
