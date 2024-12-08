using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Plank_interaction : MonoBehaviour
{
    public bool NoImputNeeded = false;
    public GameObject[] Objects;
    bool Bool = true;

    private void OnTriggerStay(Collider other)
    {
        
        if (other.tag == "Player" && (Input.GetKey(KeyCode.E) || NoImputNeeded))
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
