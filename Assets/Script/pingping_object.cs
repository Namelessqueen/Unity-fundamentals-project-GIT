using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pingping_object : MonoBehaviour
{
    float oldPosY;
    float newPosY;
    [SerializeField] float length = 8f;
    [SerializeField] float speed = 2; // when it goes up, teh speed goes down.

    private void Start()
    {
        oldPosY = transform.position.y;
    }

    void Update()
    {
        newPosY = Mathf.PingPong(Time.time/speed, length) - length/2 + oldPosY;
        transform.position= new Vector3(transform.position.x, newPosY, transform.position.z);
    }
}
