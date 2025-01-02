using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SetActive_Swapper : MonoBehaviour
{
    public bool NoImputNeeded = false;
    public GameObject[] Objects;
    public TextUpdater TextUpdaterScript;
    bool isActive = true;

    private void OnTriggerStay(Collider other)
    {
        
        if (other.CompareTag("Player") && (Input.GetKey(KeyCode.E) || NoImputNeeded))
        {
            changeInt();
            Activate();
        }
    }

    public void Activate()
    {
        for (int i = 0; i < Objects.Length; i++)
        {
            isActive ^= Objects[i].activeSelf;
            Objects[i].SetActive(isActive);
            isActive = true;
        }
    }

    public void changeInt()
    {
        if(TextUpdaterScript!= null)TextUpdaterScript.ChangeObjectiveInt(1);
    }
}
