//-------------------------------------
// Script  : SceneChangeGame
// Name    : ゲーム内クリア時のシーン切り替え
// Creater : 大山 尚悟 (おおやま しょうご)
// Day     : 11 / 06
//-------------------------------------
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangeGame : MonoBehaviour
{
    [SerializeField,Tooltip("シーンクリア")]
    SceneChange sceneChange;

    [SerializeField, Tooltip("シーン名")]
    string sceneChangeName;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            EndGame.SetEndTimeGame(true);
        }
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(EndGame.GetEndGame())
        {
            //sceneChange.ChangeScene();
            sceneChange.ChangeSceneFade(SceneChange.FadeName.FADE_IN_DOWN, sceneChangeName);
        }
    }
}
