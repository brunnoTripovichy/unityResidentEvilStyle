using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieAnimatorScript : MonoBehaviour
{

    public SimpleZombieMove szm;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FinishAnimation()
    {
        Debug.Log("1");
        szm.FinishStealthDeath();
    }
}
