using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class ScoreManager : MonoBehaviour
{
    [SerializeField]
    private float winScore;
    private string currentScene;

    [SerializeField] private float score;

    public float Score
    {
        get => score;
        set
        {
            score = value;
            scoreTMP.text = score.ToString();
        }
    }

    [SerializeField]
    private string scoreText;
    private string scoreUI;
    [SerializeField]
    private GameObject winScreen;
    [SerializeField]
    private TextMeshProUGUI scoreTMP;
    //private GameObject currentScore;
   
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //scoreUI = currentScore.gameObject.GetComponent<TextMeshProUGUI>().text;
        Score = 0;
        winScreen.SetActive(false);
        currentScene = SceneManager.GetActiveScene().name ;
    }

    /*private void Update()
    {
        scoreText = $"{score}";
    }*/

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
        Score++;
        scoreUI = scoreText;
        if (Score == winScore)
        {
            winScreen.SetActive(true);
        }
    }
}
