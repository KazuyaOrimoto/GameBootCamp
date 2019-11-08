//-------------------------------------
// Script  : PlayerEventScene
// Name    : プレイヤーのイベントシーン
// Creater : 大山 尚悟 (おおやま しょうご)
// Day     : 11 / 05
//-------------------------------------
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEventScene : MonoBehaviour
{
    Vector3 position;
    [SerializeField, Tooltip("ムーブ")]
    Move move;
    [SerializeField, Tooltip("台風")]
    GameObject Tiphon;

    PlayerMove playerMove;
    GameObject target;
    Vector3 targetPos;

    int startEventTime;
    int endEventTime;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Goal");
        playerMove = GetComponent<PlayerMove>();

        move.enabled = false;
        position = new Vector3(-15, 0, 0);
        targetPos = new Vector3(0, 0, 0);


        startEventTime = 0;
        endEventTime = 0;
    }


    // Update is called once per frame
    void Update()
    {
        // 始まり時のプレイヤーのイベント 無理やり
        startEventTime++;

        if (startEventTime > 170)
        {
            move.enabled = true;
            playerMove.enabled = false;
        }
        else
        {
            playerMove.PlayerMoving();
            // 回転
            gameObject.transform.Rotate(new Vector3(0, 1800, 0) * Time.deltaTime);
        }



        // 終わり時のプレイヤーのイベント

        if(EndGame.GetEndTimeGame())
        {
            Tiphon.SetActive(false);
            endEventTime++;
            move.enabled = false;
            playerMove.enabled = true;

            if (endEventTime < 180)
            {
                playerMove.PlayerMoveNormal();
                transform.position = Vector3.MoveTowards(transform.position, target.transform.position, 4 * Time.deltaTime);
            }

            if (endEventTime > 180)
            {
                playerMove.PlayerStop();
            }

            if (endEventTime > 210)
            {
                playerMove.PlayerFarst();
            }
        }
    }
}
