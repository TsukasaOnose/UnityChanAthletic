using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageController : MonoBehaviour
{
    //プレイヤーオブジェクトを入れる
    public GameObject playerObj;
    //スタートポジションを入れる
    public GameObject startPos;
    //オブジェクト"StageController"を宣言
    public static readonly string STR = "StageController";
    //ゲームオーバー画面
    private GameObject gameOver;

    // Start is called before the first frame update
    void Start()
    {
        //GameOverオブジェクトを取得
        this.gameOver = GameObject.Find("GameOverCanvas");
        //プレイヤーオブジェクトの座標にスタート地点の座標を代入する
        if(playerObj != null && startPos != null)
        {
            playerObj.transform.position = startPos.transform.position;
        }
    }

    // Update is called once per frame
    public void Retry()
    {
        //シーンを読み込み直す

    }

    public void GameOver()
    {

        Debug.Log("GameOver");
    }
}
