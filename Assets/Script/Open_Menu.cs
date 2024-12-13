using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class Open_Menu : MonoBehaviour
{
    public bool isPauzed = false;
    GameObject pPlayer;
    FirstPersonController script;

    void Awake()
    {
        pPlayer = GameObject.FindGameObjectWithTag("Player");
        if(pPlayer != null)script = pPlayer.GetComponent<FirstPersonController>();
    }
    void Update()
    {
        Debug.Log(pPlayer);

        if (Input.GetKeyDown(KeyCode.U))
        {
            isPauzed ^= true;
        }

        if (isPauzed)
        {
            Time.timeScale = 0.0f;
            if (pPlayer != null) script.LockCamera = true;
        }
        else if(!isPauzed)
        {
            Time.timeScale = 1.0f;
            if (pPlayer != null) script.LockCamera = false;
        }
    }
}
