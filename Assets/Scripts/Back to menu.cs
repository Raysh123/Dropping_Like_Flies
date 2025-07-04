using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Backtomenu : MonoBehaviour
{
    [SerializeField]
    private AudioClip clip;
    private float clipLength;
    public void MainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }

    private void Start()
    {
        clipLength = clip.length;
        StartCoroutine(SwitchScene());
    }

    IEnumerator SwitchScene()
    {
        yield return new WaitForSeconds(clipLength);
        SceneManager.LoadScene("Main Menu");
    }
}
