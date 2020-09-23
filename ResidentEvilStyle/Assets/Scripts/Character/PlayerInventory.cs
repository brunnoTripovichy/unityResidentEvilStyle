using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory: MonoBehaviour
{

    public GameObject player;
    public GameObject inventory;
    public bool isOpen;

    void Start()
    {
        isOpen = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I) && !isOpen)
        {
            isOpen = true;
            Time.timeScale = 0;
        }
        else if (Input.GetKeyDown(KeyCode.I) && isOpen)
        {
            isOpen = false;
            Time.timeScale = 1;
        }

        inventory.SetActive(isOpen);
    }
}
