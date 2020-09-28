using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieFootstepScript : MonoBehaviour
{

    [SerializeField]
    private AudioClip[] clips;

    private AudioSource source;

    private void Awake()
    {
        source = GetComponent<AudioSource>();
    }

    private void Step()
    {
        AudioClip clip = clips[0];
        source.PlayOneShot(clip);
    }

    private void StepDrag()
    {
        AudioClip clip = clips[1];
        source.PlayOneShot(clip);
    }
}
