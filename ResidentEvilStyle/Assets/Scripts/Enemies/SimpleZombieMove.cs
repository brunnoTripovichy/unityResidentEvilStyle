using UnityEngine;
using UnityEngine.AI;

public class SimpleZombieMove : MonoBehaviour
{
    public GameObject zombie;
    public GameObject target;
    public GameObject zombieVoice;
    NavMeshAgent agent;
    Animator animator;


    public bool canMove;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = zombie.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            if (!target.GetComponent<TankControls>().isCrouching)
            {
                ResetAnimations();
                animator.SetBool("Walking", true);
                agent.SetDestination(target.transform.position);
            }
            else
            {
                ResetAnimations();
                agent.SetDestination(zombie.transform.position);
            }
        } else
        {
            ResetAnimations();
            agent.SetDestination(zombie.transform.position);
        }
    }

    private void ResetAnimations()
    {
        animator.SetBool("Walking", false);
    }

    public void StartStealthDeath()
    {
        agent.SetDestination(zombie.transform.position);
        animator.SetTrigger("StealthDeath");
        zombieVoice.GetComponent<ZombieVoiceScript>().PlayDeathStrangled();
        zombieVoice.GetComponent<ZombieVoiceScript>().isBeingStrangled = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (canMove)
            target = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            target = null;
        }
    }

    public void FinishStealthDeath()
    {
        gameObject.GetComponent<CapsuleCollider>().enabled = false;
        zombieVoice.SetActive(false);
        zombieVoice.GetComponent<ZombieVoiceScript>().isBeingStrangled = false;
    }
}
