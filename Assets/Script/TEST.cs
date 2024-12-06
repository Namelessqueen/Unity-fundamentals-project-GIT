using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.HID;

public class TEST : MonoBehaviour
{
    
    void Start()
    {
        
        
        
    }

    // Update is called once per frame
    void Update()
    {Vector3 eulerRotation = new Vector3(0, 0, 0);
        transform.Rotate(eulerRotation);
        //Debug.Log(transform.eulerAngles.x);
    }
}
