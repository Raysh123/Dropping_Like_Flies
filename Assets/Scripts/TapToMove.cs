using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class TapToMove : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] private Transform moveTarget;
    private Mover spider;
    [SerializeField]
    private ParticleSystem touchParticle;

    private Vector3 targetPosition;

    private AudioSource audioSource;
    [SerializeField]
    private AudioClip catchSFX;
    [SerializeField]
    private AudioClip webShootSFX;


    private void Start()
    {
        touchParticle.gameObject.SetActive(false);
        spider = FindAnyObjectByType<Mover>();
        audioSource = GetComponent<AudioSource>();
    }


    //private void OnMouseDown()
    //{
    //    if (moveTarget == null)
    //    {
    //        Debug.LogError($"You forgot to set moveTarget on {gameObject.name} - {nameof(TapToMove)}");
    //        return;
    //    }

    //    Vector3 mousePosition = Input.mousePosition;
    //    Ray ray = Camera.main.ScreenPointToRay(mousePosition);
    //    if (!Physics.Raycast(ray, out RaycastHit hit))
    //    {
    //        return;
    //    }

    //    Vector3 worldPosition = hit.point;
    //    if (!spider.moving)
    //    {
    //        moveTarget.transform.position = worldPosition;
    //        spider.GetComponent<Webber>().CreateLine(spider.transform.position);
    //    }
    //}



    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Spider"))
        {
            spider.moving = false;
            spider.animator.Play("Idle");
            spider.PlayWebParticle();
            if (!audioSource.isPlaying)
            {
                audioSource.PlayOneShot(catchSFX, audioSource.pitch = Random.Range(0.8f, 1.2f));
            }

        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Spider"))
        {
            spider.moving = false;
            spider.animator.Play("Idle");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Spider"))
        {
            spider.moving = true;
            spider.animator.Play("Walk");
            if (!audioSource.isPlaying)
            {
                audioSource.PlayOneShot(webShootSFX, audioSource.pitch = Random.Range(0.8f, 1.2f));
            }
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (moveTarget == null)
        {
            Debug.LogError($"You forgot to set moveTarget on {gameObject.name} - {nameof(TapToMove)}");
            return;
        }

        Vector3 mousePosition = eventData.position;
        Ray ray = Camera.main.ScreenPointToRay(mousePosition);
        if (!Physics.Raycast(ray, out RaycastHit hit))
        {
            return;
        }

        Vector3 worldPosition = hit.point;
        Debug.Log("Clicked");
        if (!spider.moving)
        {
            moveTarget.transform.position = worldPosition;
            touchParticle.transform.position = worldPosition;
            StartCoroutine(TouchParticle());
            spider.GetComponent<Webber>().CreateLine(spider.transform.position);
        }
    }
    IEnumerator TouchParticle()
    {
        touchParticle.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.8f);
        touchParticle.gameObject.SetActive(false);
    }

}