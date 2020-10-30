using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoFallPlayer : MonoBehaviour
{
    //プレイヤーのオブジェクトの変数
    public GameObject playerObj;

    private void OnTriggerEnter(Collider other)
    {
        //移動床にぶつかった時
        if (other.gameObject.tag == "MoveFloorTag")
        {
            //移動床をPlayerの親にセットする
            playerObj.transform.SetParent(other.transform);
            Debug.Log("移動床に乗っています");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        //移動床と離れた時
        if (other.gameObject.tag == "MoveFloorTag")
        {
            //移動床をPlayerの親から外す
            playerObj.transform.SetParent(null);
            Debug.Log("移動床から降りました");
        }
    }
}
