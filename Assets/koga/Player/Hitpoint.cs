using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hitpoint : MonoBehaviour
{
    [SerializeField] int hitpoint = 3;
    [SerializeField] GameObject player;
    private Move move;

    // Start is called before the first frame update
    void Start()
    {
        move = player.GetComponent<Move>();
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void OnCollisionEnter(Collision col)
    {
        if (!move.GetDieFlag())
        {
            if (col.gameObject.tag == "Obstacle")
            {
                hitpoint--;
                move.CollisionObstract();
            }
            if (col.gameObject.tag == "Wall")
            {
                move.CollisionWall();
            }
        }
    }

    private void OnTriggerEnter(Collider col)
    {
        if (!move.GetDieFlag())
        {
            if (col.gameObject.tag == "Obstacle")
            {
                hitpoint--;
                move.CollisionObstract();
            }
            if (col.gameObject.tag == "Wall")
            {
                move.CollisionWall();
            }
        }
    }

    public int GetHP()
    {
        return hitpoint;
    }
}
