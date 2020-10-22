using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

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

        StartPosition();
    }

    private void Update()
    {
        //
    }

    public void Retry()
    {
        //ステージ1のシーンをロードする
        SceneManager.LoadScene("Stage1");
    }

    public void PlayerDown()
    {
        //残機が0なら
        if (GManager.instance.GetContinueNum() == 0)
        {
            //GameOver関数を呼び出す
            GameOver();
        }
        //まだ残機があるなら
        else if (GManager.instance.GetContinueNum() > 0)
        {
            //プレイヤーの位置を初期地点に戻す
            Continue();
            //残機を1減らす
            GManager.instance.MinusContinueNum();
        }
    }

    public void StartPosition()
    {
        //プレイヤーオブジェクトの座標にスタート地点の座標を代入する
        if (playerObj != null && startPos != null)
        {
            playerObj.transform.position = startPos.transform.position;
        }
    }

    public void Continue()
    {
        //プレイヤーオブジェクトの座標にスタート地点の座標を代入する
        if (playerObj != null && startPos != null)
        {
            playerObj.transform.position = startPos.transform.position;
            //プレイヤーオブジェクトを非アクティブにする
            playerObj.SetActive(false);
            //一秒後にプレイヤーアクティブ関数を呼ぶ
            Invoke("PlayerActive", 0.5f);
        }
    }

    public void PlayerActive()
    {
        //プレイヤーをアクティブにする
        playerObj.SetActive(true);
    }

    public void GameOver()
    {
        {
            //ゲームオーバー(画面上にゲームオーバー画面を表示する)
            this.gameOverUI.SetActive(true);
            //ゲームオーバー状態を有効にする
            this.isGameOver = true;
        }
    }
}
