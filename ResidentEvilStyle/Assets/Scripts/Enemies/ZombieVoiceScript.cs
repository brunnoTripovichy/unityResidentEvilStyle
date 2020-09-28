using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieVoiceScript : MonoBehaviour
{
    private AudioSource source;
    public float timer;
    public float waitTime;

    [SerializeField]
    private AudioClip[] voiceClips;

    [SerializeField]
    private AudioClip strangledClip;

    public bool isBeingStrangled = false;

    private void Awake()
    {
        source = GetComponent<AudioSource>();
    }

    void Start()
    {
        waitTime = Random.Range(10.0f, 15.0f);
    }

    void Update()
    {
        ProcessRandomNoises();
    }

    private void ProcessRandomNoises()
    {
        if (!isBeingStrangled)
        {
            timer += Time.deltaTime;

            if (timer >= waitTime)
            {
                waitTime = Random.Range(6.0f, 15.0f);
                timer = 0;
                AudioClip clip = GetRandomClip();
                source.PlayOneShot(clip);
            }
        }
    }

    public void PlayDeathStrangled()
    {
        source.PlayOneShot(strangledClip);
    }

    private AudioClip GetRandomClip()
    {
        return voiceClips[Random.Range(0, voiceClips.Length)];
    }
}
