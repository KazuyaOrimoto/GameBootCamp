using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateBackGround : MonoBehaviour
{
    [SerializeField,Tooltip("背景")]
    GameObject gameObject;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 20; i++)
        {
            Instantiate(gameObject, new Vector3(i * 75, 2.5f, 15.0f), Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}
