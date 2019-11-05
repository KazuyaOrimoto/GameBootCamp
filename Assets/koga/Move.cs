using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    //回転速度
    [SerializeField] private float rotaspeed;
    //移動速度
    [SerializeField] private float speed;
    //重力
    [SerializeField] private float gravity;
    //入力フラグ
    [SerializeField] private bool rotaright = false;
    [SerializeField] private bool rotaleft = false;
    [SerializeField] private bool rotaup = false;
    [SerializeField] private bool rotadown = false;
    //スティックの入力感度
    [SerializeField] private float sticRange = 0.7f;
    //回転限界
    [SerializeField] private float rotalimit = 2.0f;
    [SerializeField] private float bound;
    [SerializeField] private float defaultbound = 25.0f;

    //死亡時用の変数
    //死亡フラグ
    [SerializeField] private bool dieflag = false;
    //回転速度
    [SerializeField] private float diespin = 5.0f;
    [SerializeField] private Vector3 keeppos;
    [SerializeField] private float wait = 0.0f;


    private Rigidbody rb;

    private enum State
    {
        Normal,
        die,
    }

    State state;
    

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rotaspeed = 0;
        speed = 4;
        gravity = 3;
        dieflag = false;
        bound = 0;
    }

    // Update is called once per frame
    void Update()
    {
        float rotaHorizontal = Input.GetAxis("Horizontal2");
        float rotaVertical = Input.GetAxis("Vertical2");
        float viasHorizontal = Input.GetAxis("Horizontal");

        if (!dieflag)
        {
            if (rotaHorizontal >= sticRange)
            {
                rotaright = true;
            }
            if (rotaHorizontal <= -sticRange)
            {
                rotaleft = true;
            }
            if (rotaVertical >= sticRange)
            {
                rotadown = true;
            }
            if (rotaVertical <= -sticRange)
            {
                rotaup = true;
            }

            RotaCheck();

            transform.Rotate(new Vector3(0, rotaspeed * rotalimit, 0));

            if (rotaspeed <= rotalimit)
            {
                rb.velocity = new Vector3(speed + viasHorizontal - bound, rotaspeed - gravity * rotalimit, 0);
            }
            else
            {
                rb.velocity = new Vector3(speed + viasHorizontal - bound, rotaspeed - gravity, 0);
            }
            rotaspeed *= 0.995f;
        }
        else
        {
            transform.Rotate(new Vector3(0, diespin, 0));
            rb.velocity = new Vector3(0, -gravity * rotalimit, 0);
            
            wait++;
            if(wait >= 30)
            {
                Respown();
            }
        }
        bound *= 0.85f;
        if(bound <= 1.0f)
        {
            speed = 4;
            bound = 0;
        }
    }


    //フラグすべて立っていたら回転速度を上げる
    private void RotaCheck() { 
        if(rotaright && rotaleft && rotaup && rotadown)
        {
            rotaspeed += rotalimit;
            rotaright = false;
            rotaleft = false;
            rotaup = false;
            rotadown = false;
        }
    }

    private void Respown()
    {
        Vector3 resPos = new Vector3(transform.position.x - 10, transform.position.y, transform.position.z);
        transform.position = resPos;
        rotaspeed = 2;
        gravity = 3;
        dieflag = false;
        if(wait >= 60)
        {
            speed = 4;
            wait = 0;
        }
    }

    public void CollisionObstract()
    {
        dieflag = true;
        keeppos = transform.position;
    }
    public void CollisionWall()
    {
        speed = 0;
        bound = defaultbound;
    }

    public bool GetDieFlag()
    {
        return dieflag;
    }
}
