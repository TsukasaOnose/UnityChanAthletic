using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StageController : MonoBehaviour
{
    //プレイヤーオブジェクトを入れる
    public GameObject playerObj;
    //スタートポジションを入れる
    public GameObject startPos;
    //オブジェクト"StageController"を宣言
    public static readonly string STR = "StageController";
    //ゲームオーバー画面
    private GameObject gameOverUI;
    //ゲームオーバーの判定
    private bool isGameOver = false;

    // Start is called before the first frame update
    void Start()
    {
        //GameOverオブジェクトを取得
        this.gameOverUI = GameObject.Find("GameOverCanvas");
        //ゲームオーバー画面を非アクティブにする
        this.gameOverUI.SetActive(false);
        //プレイヤーオブジェクトの座標にスタート地点の座標を代入する
        if (playerObj != null && startPos != null)
        {
            playerObj.transform.position = startPos.transform.position;
        }
    }

    public void Retry()
    {
        //ステージ1のシーンをロードする
        SceneManager.LoadScene("Stage1");
    }

    public void GameOver()
    {
        //残機がまだある時
        if(GManager.instance.continueNum > 0)
        {
            //スタートポジションに戻る
            playerObj.transform.position = startPos.transform.position;
            GManager.instance.continueNum -= 1;
        }
        //残機が0の時
        if (GManager.instance.continueNum == 0)
        {
            //ゲームオーバーになった時、画面上にゲームオーバー画面を表示する
            this.gameOverUI.SetActive(true);
            this.isGameOver = true;
            Debug.Log("GameOver");
        }
    }
}
