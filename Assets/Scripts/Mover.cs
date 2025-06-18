using UnityEngine;
using UnityEngine.AI;

public class Mover : MonoBehaviour
{
    public Transform target;
    private NavMeshAgent agent;
    public bool moving;
    public Animator animator;




    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        if(agent == null )
        {
            return;
        }
            
    }

    // Update is called once per frame
    void Update()
    {        
        if (target != null)
        {
            agent.SetDestination(target.position);
        }
    }
}
