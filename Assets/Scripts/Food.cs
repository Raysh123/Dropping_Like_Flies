using System.Collections;
using UnityEngine;

public class Food : MonoBehaviour
{
    private Rigidbody foodRB;
    public bool isCaught = false;
    private ScoreManager scoreManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        scoreManager = FindAnyObjectByType<ScoreManager>();
        foodRB = GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {
        scoreManager.food = this.gameObject.GetComponent<Food>();
        if (other.gameObject.CompareTag("Web"))
        {
            isCaught = true;            
        }
    }

    // Update is called once per frame
    private void Update()
    {
        if (isCaught)
        {
            foodRB.constraints = RigidbodyConstraints.FreezePositionY;
            Foods();
            isCaught=false;
        }
        DestroyObject();
    }
    private void Foods()
    {
        scoreManager.food = null;
        Destroy(this.gameObject, 0.01f);
    }

    private void DestroyObject()
    {
        Destroy(this.gameObject, 3f);
    }
}
