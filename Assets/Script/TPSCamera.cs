using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TPSCamera : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] float rotateSpeed;

    float yaw, pitch;

    // Start is called before the first frame update
    void Start()
    {
        rotateSpeed = 1;
    }

    // Update is called once per frame
    void Update()
    {
        //プレイヤーを追従
        transform.position = new Vector3(player.position.x, player.position.y, player.position.z);

        //横回転の入力
        yaw += Input.GetAxis("Mouse X") * rotateSpeed;
        //縦回転の入力
        pitch -= Input.GetAxis("Mouse Y") * rotateSpeed;

        //縦回転の角度を制限
        pitch = Mathf.Clamp(pitch, -80, 60);
        //回転の実行
        transform.eulerAngles = new Vector3(pitch, yaw, 0.0f); 
    }
}
