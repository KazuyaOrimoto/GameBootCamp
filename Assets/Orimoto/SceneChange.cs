using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    public enum FadeName
    {
        FADE_IN_DOWN,
        FADE_IN_UP,
        FADE_OUT_DOWN,
        FADE_OUT_UP
    }



    [SerializeField] string stageSelectSceneName;

    [SerializeField] List<GameObject> fade = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ChangeScene()
    {
        SceneManager.LoadScene(stageSelectSceneName);
    }

    

    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void ChangeSceneFade(FadeName f)
    {
        switch(f)
        {
            case FadeName.FADE_IN_DOWN: ChangeScene();
                break;
            case FadeName.FADE_IN_UP:
                ChangeScene();
                break;
            case FadeName.FADE_OUT_DOWN:
                ChangeScene();
                break;
            case FadeName.FADE_OUT_UP:
                ChangeScene();
                break;
        }
    }
}
