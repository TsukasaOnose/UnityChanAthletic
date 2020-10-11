using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class VillagerScript : MonoBehaviour
{
    //ナビメッシュエージェントを入れる変数
    //アニメーターを入れる変数
    //移動したい地点
    //現在の地点
    //移動する速さ
    //移動している時(状態)
    //移動地点に着いた後少し棒立ちしている時(状態)
    //棒立ちしている間の時間


    private void Start()
    {
        //ナビメッシュエージェントを取得
        //アニメーターを取得
        //開始地点を取得
        //移動する地点の座標を取得
    }

    void Update()
    {
        //地点0にいる時、地点1へ向かって歩く
        //地点1にいる時、地点2へ向かって歩く
        //地点2にいる時、地点0へ向かって歩く
        //どの地点にもいない時（歩いている時）、returnで返す？
    }

}