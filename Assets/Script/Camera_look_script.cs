using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_look_script : MonoBehaviour
{
    public Transform waypoint;
    Quaternion startRotation;
    Quaternion endRotation;
    void Start()
    {
        endRotation = Quaternion.LookRotation(transform.position + waypoint.position);
        startRotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, transform.rotation.z);

    }

    // Update is called once per frame
    float timer = 0;
    void Update()
    {
        Debug.Log(endRotation);
        timer += Time.deltaTime;

        if(timer > 3)transform.rotation = Quaternion.Lerp(startRotation, endRotation, timer * 0.1f);
        //endRotation = Quaternion.LookRotation(transform.position + waypoint.position);
        //transform.rotation = newRotation;
    }
}
