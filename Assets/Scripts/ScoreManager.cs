using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class ScoreManager : MonoBehaviour
{
    private string currentScene;
    public float score;
    [SerializeField]
    private GameObject winScreen;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        winScreen.SetActive(false);
        currentScene = SceneManager.GetActiveScene().name ;
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void Retry()
    {
       
        SceneManager.LoadScene(currentScene);
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
