//-------------------------------------
// Script  : CreateObject
// Name    : 障害物の作成
// Creater : 大山 尚悟 (おおやま しょうご)
// Day     : 11 / 04
//-------------------------------------
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class CreateObject : MonoBehaviour
{
    [SerializeField]
    GameObject[] obj;

    //private TextAsset csvFile; // CSVファイル
    [SerializeField]
    TextAsset csvFile; // CSVファイル

    string str = "";
    int[] iDat = new int[100];

    // Start is called before the first frame update
    void Start()
    {
        StringReader reader = new StringReader(csvFile.text);

        while (reader.Peek() > -1)
        {
            string line = reader.ReadLine();
            str = str + line;
        }

        Debug.Log("test2: " + str);


        for (int i = 0; i < 100; i++)
        {
            iDat[i] = str.IndexOf(",", iDat[i]);
            Instantiate(obj[iDat[i]], new Vector3(8.0f * i, 0.0f, 0.0f), Quaternion.identity);
        }
        //Instantiate(obj[1], new Vector3(4.0f, 0.0f, 0.0f), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
