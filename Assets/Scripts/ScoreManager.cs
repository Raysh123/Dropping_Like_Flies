using UnityEngine;
using UnityEngine.UIElements;

public class ScoreManager : MonoBehaviour
{
    public float score;
    [SerializeField]
    private GameObject winScreen;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        winScreen.SetActive(false);
    }

    public void AddScore()
    {
        score++;
        //Debug.Log("one point");

        if (score == 20)
        {
            winScreen.SetActive(true);
        }
    }
}
