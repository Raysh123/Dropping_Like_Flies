using UnityEngine;

public class TapToMove : MonoBehaviour
{
    [SerializeField] private Transform moveTarget;
    private Mover spider;


    private void Start()
    {
        spider = FindAnyObjectByType<Mover>();
    }

    private void OnMouseDown()
    {
        if (moveTarget == null)
        {
            Debug.LogError($"You forgot to set moveTarget on {gameObject.name} - {nameof(TapToMove)}");
            return;
        }

        Vector3 mousePosition = Input.mousePosition;
        Ray ray = Camera.main.ScreenPointToRay(mousePosition);
        if (!Physics.Raycast(ray, out RaycastHit hit))
        {
            return;
        }

        Vector3 worldPosition = hit.point;
        if (!spider.moving)
        {
            moveTarget.transform.position = worldPosition;
            spider.GetComponent<Webber>().CreateLine(spider.transform.position);
        }
    }

    private void Movement()
    {
            if (Input.GetMouseButtonDown(0)) // 0 = left mouse button
    {
        if (moveTarget == null)
        {
            Debug.LogError($"You forgot to set moveTarget on {gameObject.name} - {nameof(TapToMove)}");
            return;
        }
        Vector3 mousePosition = Input.mousePosition;
        Ray ray = Camera.main.ScreenPointToRay(mousePosition);
        if (!Physics.Raycast(ray, out RaycastHit hit))
        {
            return;
        }
        Vector3 worldPosition = hit.point;
        if (!spider.moving)
        {
            moveTarget.transform.position = worldPosition;
            spider.GetComponent<Webber>().CreateLine(spider.transform.position);
        }
    }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Spider"))
        {
            spider.moving = false;
            spider.animator.Play("Idle");
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
        }
    }
}