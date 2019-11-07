using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

public class Sound
{
    const int SE_CHANNEL = 4;

    enum eType
    {
        bgm,
        se
    }

    static Sound _singleton;

    public static Sound GetInstance()
    {
        return _singleton ?? (_singleton = new Sound());
    }

    //サウンド再生オブジェクト
    GameObject soundObject = null;

    //サウンドリソース
    AudioSource soundSourceBGM = null;
    AudioSource soundSourceSE = null;
    AudioSource[] seChannel;

    //サウンド管理テーブル
    Dictionary<string, Data> bgmTable = new Dictionary<string, Data>();
    Dictionary<string, Data> seTable = new Dictionary<string, Data>();
    public Sound()
    {
        seChannel = new AudioSource[SE_CHANNEL];
    }
}


public class Data
{
    //アクセス用のキー
    public string key;

    //リソースの名前
    public string resouceName;

    //オーディオのクリップ
    public AudioClip Clip;

    public Data(string _key, string resName)
    {
        key = _key;

        resouceName = "Sound/" + resName;

        Clip = Resources.Load(resouceName) as AudioClip;
    }
}

