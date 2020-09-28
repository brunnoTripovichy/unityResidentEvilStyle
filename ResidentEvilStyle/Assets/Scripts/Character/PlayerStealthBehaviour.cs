using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStealthBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    public TankControls tc;
    public GameObject target;
    public bool isStrangling;
    public Rigidbody rb;

    void Start()
    {
        isStrangling = false;   
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null && !isStrangling)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                isStrangling = true;
                Vector3 pos = target.GetComponent<ZombieBackScript>().owner.transform.position - (target.GetComponent<ZombieBackScript>().owner.transform.forward * 3);
                pos = new Vector3(pos.x, 0.5f, pos.z);
                rb.velocity = Vector3.zero;
                tc.transform.forward = target.GetComponent<ZombieBackScript>().owner.transform.forward;
                tc.transform.position = pos;
                tc.StartStealthKill(target);
                target.GetComponent<ZombieBackScript>().owner.GetComponent<SimpleZombieMove>().StartStealthDeath();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "ZombieBack")
        {
            target = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == target)
        {
            target = null;
        }
    }
}
