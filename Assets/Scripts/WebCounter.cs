using UnityEditor.Analytics;
using UnityEngine;

public class WebCounter : MonoBehaviour
{
    public bool isDestroying;
    [SerializeField]
    private int websLeft;
    private UIManager uiManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        uiManager = FindAnyObjectByType<UIManager>();
        isDestroying = false;
        uiManager.gameOverScreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        websLeft = transform.childCount;
        if (isDestroying && websLeft == 0)
        {
            //Debug.Log("Game Ended");
            uiManager.gameOverScreen.SetActive(true);
        }        
    }
}
