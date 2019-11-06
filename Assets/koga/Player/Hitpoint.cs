using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Hitpoint : MonoBehaviour
{
    [SerializeField] static int hitpoint = 0;
    [SerializeField] GameObject player;
    float boundWall = 25.0f;
    float boundObs = 40.0f;
    Vector2 pushvec;
    private Move move;

    // Start is called before the first frame update
    void Start()
    {
        move = player.GetComponent<Move>();
    }

    // Update is called once per frame
    void Update()
    {
       if(hitpoint == 0)
        {
            //SceneManager.LoadScene("ResultScene");
        }
    }

    private void OnCollisionEnter(Collision col)
    {
        if (!move.GetDieFlag())
        {
            if (col.gameObject.tag == "Obstacle")
            {
                Vector2 colpos = col.gameObject.transform.position;
                Vector2 playerpos = new Vector2(player.transform.position.x, player.transform.position.y);
                Vector2 ray = colpos - playerpos;
                pushvec = -ray.normalized * boundObs;
                move.CollisionObstract(pushvec);
            }
            if (col.gameObject.tag == "Chaser")
            {
                hitpoint++;
                move.CollisionChaser();
            }
            if (col.gameObject.tag == "Wall")
            {
                Vector2 colpos = col.gameObject.transform.position;
                Vector2 playerpos = new Vector2(player.transform.position.x, player.transform.position.y);
                Vector2 ray = colpos - playerpos;
                pushvec = -ray.normalized * boundWall;
                move.CollisionWall(pushvec);
            }
        }
    }

    private void OnCollisionStay(Collision col)
    {
        if (!move.GetDieFlag())
        {
            if(col.gameObject.tag == "Floor")
            {
                move.CollisionFloar();
            }
        }
    }

    private void OnTriggerEnter(Collider col)
    {
        if (!move.GetDieFlag())
        {
            if (col.gameObject.tag == "Chaser")
            {
                move.CollisionChaser();
            }
            if (col.gameObject.tag == "item_s")
            {
                move.CollisionItemS();
            }
            if (col.gameObject.tag == "item_l")
            {
                move.CollisionItemL();
            }
        }
    }

    public int GetHP()
    {
        return hitpoint;
    }
}
