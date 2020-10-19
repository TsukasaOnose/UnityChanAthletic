using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveFloor : MonoBehaviour
{
    //初期地点の座標
    private Vector3 initialPos;
    //動く方向
    [SerializeField] private int moveX = 0;
    [SerializeField] private int moveY = 0;
    [SerializeField] private int moveZ = 0;
    //動くスピード
    [SerializeField] private int moveSpeed = 0;

    // Start is called before the first frame update
    void Start()
    {
        //最初の地点を初期地点として設定する
        initialPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //設定した速度で設定した方向へ移動する
        transform.position = new Vector3(Mathf.Sin(Time.time * moveSpeed) * moveX + initialPos.x, Mathf.Sin(Time.time * moveSpeed) * moveY + initialPos.y, Mathf.Sin(Time.time * moveSpeed) * moveZ + initialPos.z);
    }
}
