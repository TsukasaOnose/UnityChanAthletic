using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoFallPlayer : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        //移動床にぶつかった時
        if (collision.gameObject.tag == "MoveFloorTag")
            //移動床を親にセットする
            transform.SetParent(collision.transform);
    }

    void OnCollisionExit(Collision collision)
    {
        //移動床と離れた時
        if (collision.gameObject.tag == "MoveFloorTag")
        {
            //移動床を親から外す
            transform.SetParent(null);
        }
    }
}
