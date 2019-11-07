//-------------------------------------
// Script  : SkipSwayngWall
// Name    : 台風が近づいたときに揺らして飛ばす
// Creater : 大山 尚悟 (おおやま しょうご)
// Day     : 11 / 07
//-------------------------------------
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkipSwayngWall : MonoBehaviour
{
    Collider coll;
    Rigidbody rid;
    Vector3 direction;

    Vector3 nowPosition;
    bool isRota;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Chaser")
        {
            isRota = true;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        nowPosition = transform.position;
        rid = GetComponent<Rigidbody>();
        coll = GetComponent<Collider>();
        isRota = false;
    }

    private void FixedUpdate()
    {
        // 移動
        rid.velocity = direction;
    }


    // Update is called once per frame
    void Update()
    {
        // サインカーブ
        float sin = Mathf.Sin(1.0f * Mathf.PI * 20.0f * Time.time);

        if (isRota)
        {
            // 移動
            direction = new Vector3(0, sin * 4 , 0);
        }
        else
        {
            transform.position = nowPosition;
        }
    }
}
