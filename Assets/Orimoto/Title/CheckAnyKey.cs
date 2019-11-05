using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckAnyKey : MonoBehaviour
{
    SceneChange sceneChange;
    FadeImage fadeImage;
    [SerializeField] float fadeSpeed;
    // Start is called before the first frame update
    void Start()
    {
        sceneChange = GameObject.FindGameObjectWithTag("SceneManager").GetComponent<SceneChange>();
        fadeImage = GameObject.Find("FadeCanvas").GetComponent<FadeImage>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.anyKey)
        {
            if(sceneChange != null)
            {
                if(fadeImage != null)
                {
                    StartCoroutine(Fadein());
                }
            }
        }
    }

    IEnumerator Fadein()
    {
        while (fadeImage.Range < 1)
        {
            fadeImage.Range += fadeSpeed;
            yield return null;
        }
        sceneChange.ChangeScene("StageSelect");
    }
}
