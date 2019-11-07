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

    FadeImage fadeImage;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    //public void ChangeScene()
    //{
    //    SceneManager.LoadScene(stageSelectSceneName);
    //}

    

    //public void ChangeScene(string _sceneName)
    //{
    //}

    public void ChangeSceneFade(FadeName f,string _screenName)
    {
        if(fadeImage != null)
        {
            return;
        }
        stageSelectSceneName = _screenName;
        switch (f)
        {
            case FadeName.FADE_IN_DOWN:
                fadeImage = Instantiate(fade[0]).GetComponent<FadeImage>();
                StartCoroutine("DoFade");
                break;
            case FadeName.FADE_IN_UP:
                fadeImage = Instantiate(fade[1]).GetComponent<FadeImage>();
                StartCoroutine("DoFade");
                break;
            case FadeName.FADE_OUT_DOWN:
                fadeImage = Instantiate(fade[2]).GetComponent<FadeImage>();
                StartCoroutine("DoFade");
                break;
            case FadeName.FADE_OUT_UP:
                fadeImage = Instantiate(fade[3]).GetComponent<FadeImage>();
                StartCoroutine("DoFade");
                break;
        }
    }


    public void ChangeSceneFade(FadeName f)
    {
        if (fadeImage != null)
        {
            return;
        }
        switch (f)
        {
            case FadeName.FADE_IN_DOWN:
                fadeImage = Instantiate(fade[0]).GetComponent<FadeImage>();
                StartCoroutine("DoFade");
                break;
            case FadeName.FADE_IN_UP:
                fadeImage = Instantiate(fade[1]).GetComponent<FadeImage>();
                StartCoroutine("DoFade");
                break;
            case FadeName.FADE_OUT_DOWN:
                fadeImage = Instantiate(fade[2]).GetComponent<FadeImage>();
                StartCoroutine("DoFade");
                break;
            case FadeName.FADE_OUT_UP:
                fadeImage = Instantiate(fade[3]).GetComponent<FadeImage>();
                StartCoroutine("DoFade");
                break;
        }
    }

    IEnumerator DoFade()
    {
        while (fadeImage.Range <= 1.0f && fadeImage.Range >= 0.0f)
        {
            yield return null;
        }
        SceneManager.LoadScene(stageSelectSceneName);
    }
}
