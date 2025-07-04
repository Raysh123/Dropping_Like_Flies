using Unity.VisualScripting;
using UnityEngine;

public class DestroyScript : MonoBehaviour
{
    [SerializeField]
    private float destructionTime;
    void Update()
    {
        Destroy(this.gameObject, destructionTime);             
    }
}
