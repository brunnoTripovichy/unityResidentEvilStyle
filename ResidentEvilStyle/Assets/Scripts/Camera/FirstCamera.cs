using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstCamera : MonoBehaviour
{

    public GameObject on;
    public GameObject off;
    public bool cameraOn = false;
    public int cameraNumber;

    void Start()
    {
        cameraNumber = 1;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            on.SetActive(true);
            off.SetActive(false);
        }
    }
}
