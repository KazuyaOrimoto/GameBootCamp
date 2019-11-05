using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Capture : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine("CeateScreenShot");

        byte[] image = File.ReadAllBytes("ScreenShot.png");

        // ②．受け入れ用Texture2D作成
        Texture2D tex = new Texture2D(0, 0);

        // ③．バイナリ => Texture変換
        tex.LoadImage(image);

        // ④．Texture2Dをマテリアルに指定
        MeshRenderer renderer = GameObject.Find("Cube").
                            GetComponent<MeshRenderer>();
        renderer.materials[0].mainTexture = tex;

    }
    IEnumerator CeateScreenShot()
    {
        // スクリーンショットを撮る
        ScreenCapture.CaptureScreenshot("ScreenShot.png");


        while (File.Exists("ScreenShot.png") == false)
        {
            yield return null;
        }
    }
}
