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

    Animator anim;

    Quaternion LookRotation;
    float angle = 6f;
    FirstPersonController Script;
    bool isCoroutineRunning;
    private Coroutine LookCoroutine;

    private void Start()
    {
        Script = pPlayer.GetComponent<FirstPersonController>();
        anim = gameObject.GetComponentInChildren<Animator>();
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
        transform.rotation = Quaternion.LookRotation(transform.position - pCamera.transform.position);

        if ( isCoroutineRunning)
        {
            if(angle< 50)
            {
                anim.SetTrigger("Trigger");
            }
            if(angle < 0.0001)
            {
                StopCoroutine(LookCoroutine);
                pPlayer.transform.localEulerAngles = new Vector3(0, LookRotation.eulerAngles.y, 0);
                Script.pitch = LookRotation.eulerAngles.x - 360f;

                Script.LockCamera = false;
                isCoroutineRunning = false;
            }
            if (Input.GetKeyDown(KeyCode.O))
            {
                anim.SetTrigger("Trigger");

                Script.pitch = LookRotation.eulerAngles.x - 360f;

                pPlayer.transform.localEulerAngles = new Vector3(0, LookRotation.eulerAngles.y, 0);

                StopCoroutine(LookCoroutine);
                Script.LockCamera = false;
                isCoroutineRunning = false;

            }

        }
    }
}
