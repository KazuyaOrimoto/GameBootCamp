using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clear : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Sound.LoadBGM("clear", "clear");
        Sound.LoadBGM("click", "click");
        Sound.PlayBGM("clear");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKey)
        {
            Sound.PlaySE("click");
        }
    }
}
