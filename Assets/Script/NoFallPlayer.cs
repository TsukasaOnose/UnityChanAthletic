using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoFallPlayer : MonoBehaviour
{
    //プレイヤーのオブジェクトの変数
    public GameObject playerObj;

    private void OnCollisionEnter(Collision collision)
    {
        //移動床にぶつかった時
        if (collision.gameObject.tag == "MoveFloorTag")
            //移動床をPlayerの親にセットする
            playerObj.transform.SetParent(collision.transform);
    }

    void OnCollisionExit(Collision collision)
    {
        //移動床と離れた時
        if (collision.gameObject.tag == "MoveFloorTag")
        {
            //移動床をPlayerの親から外す
            playerObj.transform.SetParent(null);
        }
    }
}
