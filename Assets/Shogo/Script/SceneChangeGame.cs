//-------------------------------------
// Script  : SceneChangeGame
// Name    : ゲーム内のシーン切り替え
// Creater : 大山 尚悟 (おおやま しょうご)
// Day     : 11 / 06
//-------------------------------------
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangeGame : MonoBehaviour
{
    SceneChange sceneChange;
    [SerializeField,Tooltip("シーンゲームオーバー")]
    SceneChange sceneChangeGameOver;
    Move player;

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
        sceneChange = GameObject.FindGameObjectWithTag("SceneManager").GetComponent<SceneChange>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Move>();
    }

    // Update is called once per frame
    void Update()
    {
        if(EndGame.GetEndGame())
        {
            sceneChange.ChangeScene();
        }

        // プレイヤーが死んだとき
        if(player.GetDieFlag())
        {
            sceneChangeGameOver.ChangeScene();
        }
    }
}
