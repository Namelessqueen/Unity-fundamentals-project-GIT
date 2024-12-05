using Cinemachine;
using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Rendering;

public class Look_At : MonoBehaviour
{
    public Transform target;
    public float speed = 1f;

    private Coroutine LookCoroutine;


    public void StartRotation()
    {
        if(LookCoroutine != null)
        {
            StopCoroutine(LookCoroutine);
        }

        LookCoroutine = StartCoroutine(LookAt());

        //gameObject.GetComponent<CinemachineBrain>().enabled = false;
    }


    private IEnumerator LookAt()
    {
        Quaternion LookRotation = Quaternion.LookRotation(target.position - transform.position);

        float time = 0f;
        while (time < 1)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, LookRotation, time);

            time = Time.deltaTime * speed;

            yield return null;
        }
    }

    //public GameObject camerap;
    //public GameObject player;

    void Update()
    {
        //camerap.transform.position = player.transform.position;

        //Camera.main.transform.position = transform.position;

        if (Input.GetKeyDown(KeyCode.P))
        {
            StartRotation();
        }
    }
}
