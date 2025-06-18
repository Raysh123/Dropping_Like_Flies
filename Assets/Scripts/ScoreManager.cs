using UnityEngine;
using UnityEngine.UIElements;

public class ScoreManager : MonoBehaviour
{
    public float score;
    public Food food;
    [SerializeField]
    private GameObject winScreen;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        winScreen.SetActive(false);
        food = FindAnyObjectByType<Food>();
    }

    private void Update()
    {
        AddScore();
        if (score == 20)
        {
            winScreen.SetActive(true);
        }
    }

    public void AddScore()
    {
        if (food.isCaught)
        {
            score++;
            Debug.Log("one point");            
        }
    }


}
