using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class roughsound : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Sound.LoadBGM("rough", "aretenkou");
        Sound.PlayBGM("rough");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
