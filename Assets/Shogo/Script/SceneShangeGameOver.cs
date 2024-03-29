﻿//-------------------------------------
// Script  : SceneShangeGameOver
// Name    : 小惑星の移動
// Creater : 大山 尚悟 (おおやま しょうご)
// Day     : 11 / 07
//-------------------------------------
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneShangeGameOver : MonoBehaviour
{
    [SerializeField, Tooltip("プレイヤー")]
    Move player;
    [SerializeField, Tooltip("シーン")]
    SceneChange sceneChange;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // プレイヤーが死んだとき
        if (player.GetDieFlag())
        {
            Sound.StopBGM();
            //sceneChange.ChangeSceneFade();
            sceneChange.ChangeSceneFade(SceneChange.FadeName.FADE_IN_DOWN, "ResultLose");
        }
    }
}
