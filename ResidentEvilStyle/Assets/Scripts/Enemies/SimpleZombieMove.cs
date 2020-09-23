using UnityEngine;
using UnityEngine.AI;

public class SimpleZombieMove : MonoBehaviour
{
    public GameObject destination;
    public GameObject zombie;
    NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        zombie.GetComponent<Animator>().Play("Walking");
        agent.SetDestination(destination.transform.position);
    }
}
