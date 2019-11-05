using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DrawHitpoint : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject hptext;
    [SerializeField] private int keephp;
    [SerializeField] private Hitpoint hp;

    // Start is called before the first frame update
    void Start()
    {
        hp = player.GetComponent<Hitpoint>();
        keephp = hp.GetHP();
    }

    // Update is called once per frame
    void Update()
    {
        keephp = hp.GetHP();
        DrawHitPoint();
    }

    private void DrawHitPoint()
    {
        Text hp = hptext.GetComponent<Text>();
        hp.text = "残りHP" + keephp;
    }
}
