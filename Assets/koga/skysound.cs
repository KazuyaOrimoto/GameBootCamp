using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skysound : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Sound.LoadBGM("sky", "sora");
        Sound.PlayBGM("sky");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
