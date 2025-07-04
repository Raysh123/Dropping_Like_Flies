using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject tutorialScreen;

    private void Start()
    {
        tutorialScreen.gameObject.SetActive(false); 
    }
    public void Play()
    {
        SceneManager.LoadScene("BoxScene");
    }

    public void ArcadeMode()
    {
        SceneManager.LoadScene("ArcadeMode");
    }

    public void Credits()
    {
        SceneManager.LoadScene("Credits");
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Tutorial()
    {
        tutorialScreen.gameObject.SetActive(true);
    }

    public void Back()
    {
        tutorialScreen.gameObject.SetActive(false);
    }
}
