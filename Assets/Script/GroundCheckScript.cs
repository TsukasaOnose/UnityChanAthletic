using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheckScript : MonoBehaviour
{
    //Groundタグの変数
    private string groundTag = "GroundTag";
    //MoveFloorTagの変数
    private string moveFloorTag = "MoveFloorTag";
    //接地判定
    private bool isGround = false;
    //地面に入った、入り続けている、出た時のフラグ
    private bool isGroundEnter, isGroundStay, isGroundExit;

    //ステータスを宣言
    enum Status
    {
        Enter,
        Stay,
        Exit
    }

    private Status status = Status.Enter;

    //接地判定を返すメソッド
    //物理判定の更新毎に呼ぶ必要あり？
    public bool IsGround()
    {
        //接地した時または接地し続けている時
        /*        if(isGroundEnter || isGroundStay)
                    //接地判定を有効
                    isGround = true;
                }
                //接地判定を出た時
                else if (isGroundExit)
                {
                    //接地判定を無効
                    isGround = false;
                }

                //各フラグは無効に戻す
                isGroundEnter = false;
                isGroundStay = false;
                isGroundExit = false;

                //地判定結果を返す
                return isGround; */

        return status == Status.Enter || status == Status.Stay;
    }

    //各種トリガーフラグを用意
    private void OnTriggerEnter(Collider other)
    {
        //侵入したタグをコンソールに表示
        Debug.Log(other.gameObject.tag);
        if (other.tag == groundTag || other.tag == moveFloorTag)
        {
            status = Status.Enter;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == groundTag || other.tag == moveFloorTag)
        {
            status = Status.Stay;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == groundTag || other.tag == moveFloorTag)
        {
            status = Status.Exit;
        }
    }
}
