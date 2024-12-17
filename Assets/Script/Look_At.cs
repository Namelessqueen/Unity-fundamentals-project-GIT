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
    public bool RotateToPlayer = true;
    public float speed = 1f;


    public Animator anim;
    public float timeWait = 5f;
    float Timer = 0;
    bool startTimer = false;

    Quaternion LookRotation;
    public float angle = 6f;
    FirstPersonController Script;
    bool isCoroutineRunning;
    private Coroutine LookCoroutine;

    private void Start()
    {
        Script = pPlayer.GetComponent<FirstPersonController>();
    }

    public void StartRotation()
    {
        isCoroutineRunning = true;
        if (LookCoroutine != null)
        {
            StopCoroutine(LookCoroutine);
        }

        LookCoroutine = StartCoroutine(LookAt());
    }



    private IEnumerator LookAt()
    {
        LookRotation = Quaternion.LookRotation(transform.position - pCamera.transform.position);
        Script.LockCamera = true;
        startTimer = true;
        float time = 0f;

        while (time < 1)
        {

            pCamera.transform.rotation = Quaternion.Slerp(pCamera.transform.rotation, LookRotation, time);

            time += Time.deltaTime * speed;

            angle = Quaternion.Angle(pCamera.transform.rotation, LookRotation);

            yield return null;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            StartRotation();
            isCoroutineRunning = true;
        }
    }
    void Update()
    {
        if(RotateToPlayer)transform.rotation = Quaternion.LookRotation(transform.position - pCamera.transform.position);

        if (startTimer) Timer += Time.deltaTime;
        if (Timer > timeWait)
        {
            anim.SetTrigger("TriggerOut");
            Timer = 0f;
            startTimer = false;
        }

        if ( isCoroutineRunning)
        {
            //Debug.Log("!!!!!!   (" + transform.position +")   ("+ pCamera.transform.rotation);
            if(angle < 0.5)
            {
                StopCoroutine(LookCoroutine);
                pPlayer.transform.localEulerAngles = new Vector3(0, LookRotation.eulerAngles.y, 0);
                if (LookRotation.eulerAngles.x > 80) Script.pitch = LookRotation.eulerAngles.x - 360f;
                else Script.pitch = LookRotation.eulerAngles.x;

                Script.LockCamera = false;
                isCoroutineRunning = false;
            }

        }
    }
}
