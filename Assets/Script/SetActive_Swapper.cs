using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SetActive_Swapper : MonoBehaviour
{
    public bool NoImputNeeded = false;
    public GameObject[] Objects;
    bool Bool = true;

    private void OnTriggerStay(Collider other)
    {
        
        if (other.CompareTag("Player") && (Input.GetKey(KeyCode.E) || NoImputNeeded))
        {
            Activate();
        }
    }

    public void Activate()
    {
        for (int i = 0; i < Objects.Length; i++)
        {
            Bool ^= Objects[i].activeSelf;
            Objects[i].SetActive(Bool);
            Bool = true;
        }
    }
}
