//-------------------------------------
// Script  : SpaceShipEvent
// Name    : 始まりの時の宇宙船のイベント
// Creater : 大山 尚悟 (おおやま しょうご)
// Day     : 11 / 06
//-------------------------------------
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShipEventScene : MonoBehaviour
{
    Rigidbody rid;
    Vector3 direction;

    [SerializeField, Tooltip("ゴール一のUFO")]
    int goal;

    const int MIN_SPEED = 40;
    const int MAX_SPEED = 100;

    int startEventTime;
    int endEventTime;

    [SerializeField, Range(0, 1), Tooltip("Ufo終わり方 1 : 続行アニメーション 2 : 終了アニメーション")]
    int EndGameUfo;

    // Start is called before the first frame update
    void Start()
    {
        // 各初期化
        rid = GetComponent<Rigidbody>();

        startEventTime = 0;
        endEventTime = 0;

        //
        transform.position = new Vector3(-20, 0, -5);
    }

    private void FixedUpdate()
    {
        // 移動
        rid.velocity = direction;
    }

    // Update is called once per frame
    void Update()
    {
        startEventTime++;

        if (startEventTime < 60)
        {
            if (transform.position.x >= 8)
            {
                // 移動
                direction = new Vector3(0, 0, 0);
            }
            else
            {
                // 移動
                direction = new Vector3(1 * MIN_SPEED, 0, 0);
            }
        }
        if (startEventTime >= 60 && startEventTime < 120)
        {
            // 移動
            direction = new Vector3(0, 0, 0);
        }
        if (startEventTime > 120)
        {
            // 移動
            direction = new Vector3(1 * MAX_SPEED, 0, 0);
        }

        if (startEventTime >= 360)
        {
            if (EndGameUfo == 0)
            {
                if (EndGame.GetEndTimeGame())
                {
                    endEventTime++;
                }

                if (endEventTime > 180)
                {
                    // 移動
                    direction = new Vector3(1 * MAX_SPEED, 0, 0);
                }
                else
                {
                    transform.position = new Vector3(goal + MIN_SPEED, 0, 0);
                }
            }
            else
            {
                if (EndGame.GetEndTimeGame())
                {
                    endEventTime++;
                }

                if (endEventTime > 240)
                {
                    Destroy(this);
                }

                transform.position = new Vector3(goal, 0, 0);

            }
        }
    }
}
