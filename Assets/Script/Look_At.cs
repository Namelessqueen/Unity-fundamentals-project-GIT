using Cinemachine;
using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem.LowLevel;
using UnityEngine.ProBuilder.Shapes;
using UnityEngine.Rendering;
using UnityEngine.UIElements;
using static UnityEngine.ProBuilder.AutoUnwrapSettings;

public class Look_At : MonoBehaviour
{
    public GameObject pPlayer;
    public GameObject pCamera;
    public float speed = 1f;

    Quaternion LookRotation;
    float angle = 6f;
    FirstPersonController Script;
    bool isCoroutineRunning;
    private Coroutine LookCoroutine;

    private void Start()
    {
        Script = pPlayer.GetComponent<FirstPersonController>();
    }

    public void StartRotation()
    {
        if(LookCoroutine != null)
        {
            StopCoroutine(LookCoroutine);
        }

        LookCoroutine = StartCoroutine(LookAt());
    }

    

    private IEnumerator LookAt()
    {
        LookRotation = Quaternion.LookRotation(transform.position - pCamera.transform.position);    
        Script.LockCamera = true;
        float time = 0f;

        while (time < 1)
        {
            
            pCamera.transform.rotation = Quaternion.Slerp(pCamera.transform.rotation, LookRotation, time);

            time  += Time.deltaTime * speed;

            angle = Quaternion.Angle(pCamera.transform.rotation, LookRotation);

            yield return null; 
        }
    }

    
    void Update()
    {

        
        if (Input.GetKeyDown(KeyCode.I))
        {
            StartRotation();
            isCoroutineRunning = true;
            
        }
        if(Input.GetKeyDown(KeyCode.O))
        {
            Debug.Log("CLICKKKKKKKKKKKKKKKKKKKKKKKKKKKKK");
            Debug.Log("Look AT" + LookRotation.eulerAngles + "  camera: " + pCamera.transform.localEulerAngles.x + "player: " + pPlayer.transform.localEulerAngles.y);
            Script.pitch = LookRotation.eulerAngles.x- 360f;

            pPlayer.transform.localEulerAngles = new Vector3(0,LookRotation.eulerAngles.y,0);
           
            Debug.Log("Look AT" + LookRotation.eulerAngles + "  camera: " + pCamera.transform.localEulerAngles.x + "player: " + pPlayer.transform.localEulerAngles.y);
           
            StopCoroutine(LookCoroutine);
            Script.LockCamera = false;
            isCoroutineRunning = false;
            Debug.Log("Look AT" + LookRotation.eulerAngles + "  camera: " + pCamera.transform.localEulerAngles.x + "player: " + pPlayer.transform.localEulerAngles.y);
        }



        if (angle < 0.0001 && isCoroutineRunning)
        {
            StopCoroutine(LookCoroutine);
            Debug.Log("CLICKKKKKKKKKKKKKKKKKKKKKKKKKKKKK");
            pPlayer.transform.localEulerAngles = new Vector3(0, LookRotation.eulerAngles.y, 0);
            Script.pitch = LookRotation.eulerAngles.x - 360f;

            Debug.Log("Look AT" + LookRotation.eulerAngles + "  camera: " + pCamera.transform.localEulerAngles.x + "player: " + pPlayer.transform.localEulerAngles.y);


            
            
            Script.LockCamera = false;
            isCoroutineRunning = false;
        }
    }
}
