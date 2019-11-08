using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class title : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

        Sound.LoadBGM("title", "title");
        Sound.LoadBGM("click", "click");
        Sound.PlayBGM("title");
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
