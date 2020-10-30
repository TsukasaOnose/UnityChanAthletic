using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallFloor : MonoBehaviour
{
    //復元判定
    private bool isRestor = false;
    //復元されてからの時間
    private float restorTime;
    //点滅間隔
    private float blinkTime = 0.0f;
    //レンダラーを入れる変数
    private Renderer rd = null;
    //初期地点の座標
    private Vector3 startPos;

    private void Start()
    {
        //レンダラーを取得
        rd = GetComponent<Renderer>();
        //初期地点の座標を取得
        startPos = this.gameObject.transform.position;
    }

    private void Update()
    {
        //復元された時
        if(isRestor == true)
        {
            //明滅　ついている時に戻る
            if (blinkTime > 0.2f)
            {
                //レンダラーを有効化
                rd.enabled = true;
                blinkTime = 0.0f;
            }
            //明滅　消えているとき
            else if (blinkTime > 0.1f)
            {
                rd.enabled = false;
            }
            //明滅　ついている時
            else
            {
                rd.enabled = true;
            }

            //1秒後たったら明滅終了
            if (restorTime > 1.0f)
            {
                isRestor = false;
                blinkTime = 0f;
                restorTime = 0f;
                rd.enabled = true;
            }
            else
            {
                blinkTime += Time.deltaTime;
                restorTime += Time.deltaTime;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //プレイヤーと接触時
        if (other.gameObject.CompareTag("GroundCheckTag"))
        {
            //1秒後にFall関数を呼ぶ
            Invoke("Fall", 0.7f);
        }

        //ゲームオーバーエリアと接触した時
        else if (other.gameObject.CompareTag("GameOverAreaTag"))
        {
            //Restor関数を呼び出す
            Invoke("Restor", 1);
        }
    }

    void Fall()
    {
        //リジッドボディのisKinematicを無効化
        GetComponent<Rigidbody>().isKinematic = false;
    }

    void Restor()
    {
        //初期地点に戻す
        this.gameObject.transform.position = startPos;
        //isKinematicを有効化
        GetComponent<Rigidbody>().isKinematic = true;
        //復元された判定
        isRestor = true;
    }
}
