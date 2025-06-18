using UnityEngine;

public class Stone : MonoBehaviour
{
    private WebCounter counter;

    private void Start()
    {
        counter = FindAnyObjectByType<WebCounter>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Web"))
        {
            counter.isDestroying = true;
            Destroy(other.gameObject);
        }
        DestroyObject();
    }
    private void DestroyObject()
    {
        Destroy(this.gameObject, 3f);
    }
}
