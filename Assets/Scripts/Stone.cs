using UnityEngine;

public class Stone : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 5f;
    [SerializeField]
    private WebCounter counter;

    private void Update()
    {
        if(counter == null)
        {
            counter = FindAnyObjectByType<WebCounter>();
        }
            transform.Translate(Vector3.down * moveSpeed * Time.deltaTime, Space.World);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Web"))
        {
            counter.isDestroying = true;
            Destroy(other.gameObject);
        }
    }
}
