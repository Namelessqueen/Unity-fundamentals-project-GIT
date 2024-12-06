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
    public GameObject player;
    public GameObject Child;
    public float speed = 1f;

    float angle;
    FirstPersonController Script;
    bool isCoroutineRunning;
    private Coroutine LookCoroutine;

    private void Start()
    {
        Script = player.GetComponent<FirstPersonController>();
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
        Quaternion LookRotation = Quaternion.LookRotation(transform.position - player.transform.position);

        float time = 0f;
        Script.LockCamera = true;

        while (time < 1)
        {
            isCoroutineRunning = true;
            player.transform.rotation = Quaternion.Slerp(player.transform.rotation, LookRotation, time);

            time  += Time.deltaTime * speed;

            //angle = Quaternion.Angle(player.transform.rotation, LookRotation);

            yield return null;
        }
        
    }

    
    void Update()
    {
        Debug.Log(isCoroutineRunning+"   "+ angle);

        if (Input.GetKeyDown(KeyCode.I))
        {
            StartRotation();
        }
        
        if (angle < 5 && isCoroutineRunning)
        {    //Debug.Log(player.transform.eulerAngles.x+"   "+ Script.pitch);
            //if (player.transform.eulerAngles.x < 0) Script.pitch = player.transform.eulerAngles.x;
            //if (player.transform.eulerAngles.x >= 0) Script.pitch = player.transform.eulerAngles.x - 360f;
            //Debug.Log(Script.pitch);
            //Vector3 eulerRotation = (new Vector3)final;
            //Debug.Log(Quaternion.Euler(eulerRotation));
            //Child.transform.Rotate(eulerRotation);
            ////float rotationX = player.transform.rotation.x;
            //

            //Vector3 eulerRotation = new Vector3(player.transform.eulerAngles.x, Child.transform.eulerAngles.y,Child.transform.eulerAngles.z);
            //Child.transform.rotation = Quaternion.Euler(eulerRotation);

            angle = 0f;
            StopCoroutine(LookCoroutine);
            isCoroutineRunning = false;

            Script.LockCamera = false;
        }
    }
}
