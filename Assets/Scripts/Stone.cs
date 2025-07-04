using UnityEngine;

public class Stone : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 5f;
    [SerializeField]
    private WebCounter counter;
    [SerializeField]
    private GameObject particle;

    private AudioSource audioSource;
    [SerializeField]
    private AudioClip clip;

    private void Start()
    {
        particle.gameObject.SetActive(false);
        audioSource = GetComponent<AudioSource>();
    }
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
            audioSource.PlayOneShot(clip, audioSource.pitch = Random.Range(0.7f, 1.3f));
            counter.isDestroying = true;
            particle.gameObject.SetActive(true);
            Destroy(other.gameObject);
        }
    }
}
