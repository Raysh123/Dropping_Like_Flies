using Unity.VisualScripting;
using UnityEngine;

public class Webber : MonoBehaviour
{
    [SerializeField] private float lineWidth = 0.2f;
    [SerializeField] private Material lineMaterial;
    private Mover mover;

    private GameObject webLineParent;
    private LineRenderer currentLine;

    private void Start()
    {
        mover = FindAnyObjectByType<Mover>();
    }
    public void CreateLine(Vector3 originPosition)
    {
        GameObject lineObject = CreateLineObject();
        CreateLineRenderer(originPosition, lineObject);
    }

    private GameObject CreateLineObject()
    {
        GameObject lineObject = new GameObject("Web Line");
        if (webLineParent == null)
        {
            webLineParent = new GameObject("Web Lines");
            webLineParent.AddComponent<WebCounter>();
        }
        webLineParent.transform.localScale = Vector3.one;
        lineObject.transform.parent = webLineParent.transform;
        lineObject.transform.localScale = Vector3.one;
        return lineObject;
    }

    private void CreateLineRenderer(Vector3 originPosition, GameObject lineObject)
    {
        currentLine = lineObject.AddComponent<LineRenderer>();
        currentLine.startWidth = currentLine.endWidth = lineWidth;
        currentLine.material = lineMaterial;
        currentLine.SetPosition(0, originPosition);
        //Mesh mesh = new Mesh();
        //currentLine.BakeMesh(mesh);
        currentLine.AddComponent<MeshRenderer>();
        currentLine.AddComponent<MeshFilter>();
        //currentLine.GetComponent<MeshFilter>().mesh = mesh;
        currentLine.AddComponent<MeshCollider>();
        //currentLine.GetComponent<MeshCollider>().convex = true;
        //currentLine.GetComponent<MeshCollider>().isTrigger = true;
        currentLine.AddComponent<WebFunction>();
        currentLine.gameObject.layer = 6;
        currentLine.gameObject.tag = "Web";
    }

    private void Update()
    {
        if (currentLine == null) { return; }
        currentLine.SetPosition(1, transform.position);

        if (!mover.moving)
        {
            Mesh mesh = new Mesh();
            currentLine.BakeMesh(mesh);
            currentLine.GetComponent<MeshFilter>().mesh = mesh;
            currentLine.GetComponent<MeshCollider>().sharedMesh = mesh;
        }
    }
}
