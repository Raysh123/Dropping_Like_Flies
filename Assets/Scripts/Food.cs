using System.Collections;
using UnityEngine;

public class Food : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 2f;
    private bool isCaught = false;
    private ScoreManager scoreManager;
    private AudioSource AudioSource;

    [SerializeField]
    private AudioClip ateSFX;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private void Start()
    {
        AudioSource = GetComponent<AudioSource>();

    }

    private void Update()
    {
        if (scoreManager == null)
        {
            scoreManager = FindAnyObjectByType<ScoreManager>();
        }
        transform.Translate(Vector3.down * moveSpeed * Time.deltaTime, Space.World);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (isCaught) { return; }

        if (other.gameObject.CompareTag("Web"))
        {
            isCaught = true;            
            scoreManager.AddScore();
            transform.Translate(Vector3.zero);
            StartCoroutine(Caught());
            //gameObject.SetActive(false);
        }
    }

    IEnumerator Caught()
    {
        AudioSource.PlayOneShot(ateSFX);
        moveSpeed = 0f;
        float clipLength = ateSFX.length;
        yield return new WaitForSeconds(clipLength);
        isCaught = false;
        moveSpeed = 5f;
        gameObject.SetActive(false);
    }
}
