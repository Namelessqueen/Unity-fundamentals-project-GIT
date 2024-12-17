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
        if (pPlayer != null) script = pPlayer.GetComponent<FirstPersonController>();
    }

    public void Pauzing()
    {
        isPauzed ^= true;

        if (isPauzed)
        {
            Time.timeScale = 0.0f;
            script.lockCursor = false;
            script.cameraCanMove = false;
            pauzeMenu.SetActive(true);
        }
        else if (!isPauzed)
        {
            Time.timeScale = 1.0f;
            script.lockCursor = true;
            script.cameraCanMove = true;
            pauzeMenu.SetActive(false);
        }
    }
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pauzing();
        }

       
    }
}
