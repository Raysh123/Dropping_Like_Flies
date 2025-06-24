using System.Collections;
using UnityEngine;

public class Food : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 2f;
    private bool isCaught = false;
    private ScoreManager scoreManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

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
        yield return new WaitForSeconds(0.03f);
        isCaught = false;
        gameObject.SetActive(false);
    }
}
