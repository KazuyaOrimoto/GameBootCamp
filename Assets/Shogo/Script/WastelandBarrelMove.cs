﻿//-------------------------------------
// Script  : WastelandBarrelMove
// Name    : 樽の移動
// Creater : 大山 尚悟 (おおやま しょうご)
// Day     : 11 / 05
//-------------------------------------
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WastelandBarrelMove : MonoBehaviour
{
    [SerializeField, Tooltip("プレイヤー")]
    GameObject player;

    Rigidbody rid;
    Vector3 direction;

    const int SPEED = -5;

    int time;
    const int deleteTime = 300;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        // 各初期化
        rid = GetComponent<Rigidbody>();
        time = 0;
    }

    private void FixedUpdate()
    {
        // 左向き
        gameObject.transform.rotation = new Quaternion(0, 180, 0, 0);

        // 移動
        rid.velocity = direction;
    }

    // Update is called once per frame
    void Update()
    {
        // サインカーブ
        float sin = Mathf.Sin(2 * Mathf.PI * 1 * Time.time);

        // 移動
        direction = new Vector3(1 * SPEED, sin * 10, 0);

        // 時間後削除
        if (transform.position.x < -20)
        {
            Destroy(this.gameObject);
        }
    }
}