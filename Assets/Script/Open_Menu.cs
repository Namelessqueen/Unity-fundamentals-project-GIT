using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class Open_Menu : MonoBehaviour
{
    public bool isPauzed = false;
    public GameObject pauzeMenu;


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
            script.lockCursor = false;
            script.cameraCanMove = false;
        }
        else if(!isPauzed)
        {
            Time.timeScale = 1.0f;
            script.lockCursor = true;
            script.cameraCanMove = true;
        }
        pauzeMenu.SetActive(isPauzed);
    }
}
