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
    [SerializeField, Tooltip("オブジェクト")]
    GameObject[] obj;

    //private TextAsset csvFile; // CSVファイル
    [SerializeField, Tooltip("マップ")]
    TextAsset csvDatas; // CSVファイル

    [SerializeField, Tooltip("サイズ")]
    Vector3 size;

    [SerializeField, Tooltip("間隔")]
    int interval;


    string str = "";        //CSVの全文字列を保存する
    string strget = "";     //取り出した文字列を保存する

    int gyou = 10;  //CSVデータの行数
    int retu = 10;  //CSVデータの列数

    int[,] map = new int[20, 20];   //マップ番号を格納するマップ用変数
    int[] iDat = new int[15];       //文字検索用

    int a = 0;    //濫用　数値型変数
    int b = 0;    //濫用　数値型変数
    int c = 0;    //濫用　数値型変数

    int ix = 0;     //マップ置くX座標　初期位置


    // Start is called before the first frame update
    void Start()
    {
        obj[0].transform.localScale = size;
        obj[1].transform.localScale = size;
        //----------↓　ここでCSVデータをstrに保存　↓
        StringReader reader = new StringReader(csvDatas.text);

        while (reader.Peek() > -1)
        {
            string line = reader.ReadLine();
            str = str + "," + line;
        }

        str = str + ",";        //最後に検索文字列の","を追記。これがないと最後の文字を取りこぼす。
                                //----------↑　ここでCSVデータをstrに保存　↑

        //----------↓　ここでCSVデータをマップ配列変数mapに保存　↓
        for (int c = 0; c < gyou; c++)
        {
            for (int i = 0; i < retu; i++)
            {
                try
                {
                    iDat[0] = str.IndexOf(",", iDat[0]);   //","を検索
                }
                catch { break; }

                try
                {
                    iDat[1] = str.IndexOf(",", iDat[0] + 1);   //次の","を検索
                }
                catch { break; }

                iDat[2] = iDat[1] - iDat[0] - 1;                //何文字取り出すか決定

                try
                {
                    strget = str.Substring(iDat[0] + 1, iDat[2]);   //iDat[2]文字ぶんだけ取り出す
                }
                catch { break; }

                try
                {
                    iDat[3] = int.Parse(strget);        //取り出した文字列を数値型に変換
                }
                catch { break; }

                map[a, b] = iDat[3];                    //マップ用変数に保存。１とか６とか数字が入るよ
                b++;                            //一つ右のマップ用変数へ
                iDat[0]++;                      //次のインデックスへ
            }

            a++;                                //一つ下のマップチップへ
            b = 0;                              //マップチップ格納を一番左に戻す。
        }

        //----------↑　ここでCSVデータをマップ配列変数mapに保存　↑

        //----------↓　ここでマップ配列変数mapの内容を確認できます　↓
        //a = 0;
        //for (int c = 0; c < gyou; c++)
        //{
        //    for (int i = 0; i < retu; i++)
        //    {
        //        Debug.Log("map." +a+"."+ i + ": " + map[a, i]);
        //    }
        //    a++;
        //}
        //----------↑　ここでマップ配列変数mapの内容を確認できます　↑

        //----------↓　ここでマップ配列変数mapからオブジェクトを配置　↓

        ix = -4;   //マップ置くX座標　初期位置

        a = 0;
        b = 0;
        c = 0;

        for (int c = 0; c < gyou; c++)
        {

            for (int i = 0; i < retu; i++)
            {
                if (map[a, b] == 0)     //マップ番号が１なら木を配置
                {
                    Instantiate(obj[0], new Vector3(ix, 0.0f, 0.0f), Quaternion.identity);
                }

                if (map[a, b] == 1)     //2なら石を地面に配置
                {
                    Instantiate(obj[1], new Vector3(ix, 0.0f, 0.0f), Quaternion.identity);
                }

                b++;            //次の右のマップ番号を読み込む
                ix = ix + interval;    //配置位置を右に移動
            }

            a++;            //一行終了。下の段のマップ番号を読み込んでいく
            b = 0;          //行の始めに戻るからb=0
        }

        //Instantiate(obj[0], new Vector3(8.0f, 0.0f, 0.0f), Quaternion.identity);
        //Instantiate(obj[1], new Vector3(8.0f, 0.0f, 0.0f), Quaternion.identity);

    } 

        // Update is called once per frame
        void Update()
    {
        
    }
}
