using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockCurson : MonoBehaviour
{
    // Start is called before the first frame update
    private void Awake()
    {
        Cursor.lockState = CursorLockMode.None;
    }
}
