using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject gameOverScreen;

    [SerializeField]
    private GameObject pauseScreen;

    [SerializeField] 
    private GameObject pauseButton;
    [SerializeField]
    private Sprite pauseButtonSprite;
    [SerializeField]
    private Sprite playButtonSprite;
    private Image buttonImage;

    private void Start()
    {
        buttonImage = pauseButton.GetComponent<Image>();
        pauseScreen.SetActive(false);
        buttonImage.sprite = pauseButtonSprite;
    }

    public void PauseButton()
    {
        if (pauseScreen.activeSelf == false)
        {
            pauseScreen.SetActive(true);
            Time.timeScale = 0f;
            buttonImage.sprite = playButtonSprite;
            
        }
        else if (pauseScreen.activeSelf == true)
        {
            pauseScreen.SetActive(false);
            Time.timeScale = 1.0f;
            buttonImage.sprite = pauseButtonSprite;
        }
    }

    public void Menu()
    {
        SceneManager.LoadScene("Main Menu");
    }

}
