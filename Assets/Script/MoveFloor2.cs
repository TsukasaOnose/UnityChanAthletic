using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveFloor2 : MonoBehaviour
{
    private Rigidbody rigid;
    private Vector3 defaultPos;

    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody>();
        defaultPos = transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rigid.MovePosition(new Vector3(defaultPos.x, defaultPos.y + Mathf.PingPong(Time.time, 2), defaultPos.z));
    }
}
