using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveFloor2 : MonoBehaviour
{
    void OnCollisionStay(Collision col)
    {
        if (col.gameObject.tag == "MovingFloorTag")
        {
            transform.parent = col.gameObject.transform;
            Debug.Log("parenting");
        }
    }
    void OnCollisionExit()
    {
        transform.parent = null;
        Debug.Log("exit");
    }
}