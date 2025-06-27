using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class Mover : MonoBehaviour
{
    public Transform target;
    private NavMeshAgent agent;
    public bool moving;
    public Animator animator;
    [SerializeField]
    private ParticleSystem webParticle;




    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        if(agent == null )
        {
            return;
        }
        webParticle.gameObject.SetActive( false );
            
    }

    // Update is called once per frame
    void Update()
    {        
        if (target != null)
        {
            agent.SetDestination(target.position);
        }
    }

    public void PlayWebParticle()
    {
        StartCoroutine(WebParticle());
    }

    IEnumerator WebParticle()
    {
        webParticle.gameObject.SetActive( true );
        yield return new WaitForSeconds(0.7f);
        webParticle.gameObject.SetActive( false );
    }
}
