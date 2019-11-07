using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BambooCreater : MonoBehaviour
{
    float time = 0;
    [SerializeField] GameObject bam;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if(time > 1.0f)
        {
            GameObject b = Instantiate(bam);
            time = 0;
            b.transform.position =transform.position + new Vector3(Random.Range(-50.0f,50.0f), Random.Range(-10.0f, 10.0f), Random.Range(-30.0f, 100.0f));
        }
    }
}
