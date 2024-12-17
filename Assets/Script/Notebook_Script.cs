using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.LowLevel;

public class Notebook_Script : MonoBehaviour
{
    public GameObject Notebook;

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Tab))
        {
            OpenNotebook(true);
        }
        else OpenNotebook(false);
    }

    public void OpenNotebook(bool IsOpen)
    {
        Notebook.gameObject.SetActive(IsOpen);
    }
}
