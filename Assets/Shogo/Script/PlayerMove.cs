using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    Rigidbody rid;
    Vector3 direction;

    float speed;
    float itemSpeed;

    // Start is called before the first frame update
    void Start()
    {
        rid = GetComponent<Rigidbody>();
        speed = 2;
        itemSpeed = 1;
    }

    private void FixedUpdate()
    {
        // 移動
        rid.velocity = direction;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x > -10)
        {
            itemSpeed = 6;
        }
    }


    public void PlayerMoveNormal()
    {
        // 移動
        direction = new Vector3(1 * speed, 0, 0);
    }

    public void PlayerMoving()
    {
        // 移動
        direction = new Vector3(1 * speed * itemSpeed, 0, 0);
    }

    public void PlayerFarst()
    {
        // 移動
        direction = new Vector3(1 * speed * itemSpeed * itemSpeed, 0, 0);
    }

    public void PlayerStop()
    {
        // 移動
        direction = new Vector3(0, 0, 0);
    }
}
