using System.Collections;
using UnityEngine;
using UnityEngine.Video;

public class GameStart : MonoBehaviour
{
    public bool isStarted = false;
    [SerializeField]
    private VideoPlayer player;
    [SerializeField]
    private GameObject sceneObject;
    [SerializeField]
    private VideoClip clip;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (isStarted)
        {
            player.Stop();
            sceneObject.SetActive(true);
        }

        else if(!isStarted)
        {
            StartCoroutine(PlayCutscene());
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isStarted && sceneObject.activeSelf == false)
        {
            sceneObject.SetActive(true);
        }
        else
        {
            return;
        }
    }

    IEnumerator PlayCutscene()
    {
        player.Play();
        float length = (float)clip.length;
        yield return new WaitForSeconds(length);
        player.Stop();
        isStarted = true;
    }

}
