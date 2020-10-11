using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityChanController : MonoBehaviour
{
    //キャラクターコントローラーを入れる変数
    private CharacterController characterController;
    //アニメーターを入れる変数
    private Animator animator;

    //動かす速度のベクトル
    private Vector3 velocity;
    //走る速度
    public float Speed = 5f;
    //ジャンプ力
    public float jumpPower;

    // Start is called before the first frame update
    void Start()
    {
        //キャラクターコントローターを取得
        characterController = GetComponent<CharacterController>();
        //アニメーターを取得
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //地面に接地している時
        if (characterController.isGrounded)
        {
            //接地していた時は速度を0にする
            velocity = Vector3.zero;

            //前後左右の入力を取得する
            Vector3 input = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));

            //スペースキーが押された時
            if (Input.GetKeyDown(KeyCode.Space))
            {
                //ジャンプアニメーションを再生
                animator.SetBool("Jump", true);
                //ジャンプ力を上方向への速度を代入
                velocity.y = jumpPower;
            }
            //スペースキーが押されていない時
            else
            {
                //ジャンプアニメーションを無効
                animator.SetBool("Jump", false);
                //上にかかる速度を0
                velocity.y = 0f;
            }

            //入力の長さが0.1より大きい時
            if (input.magnitude > 0.1f)
            {
                //入力した方向へ向かせる
                transform.LookAt(transform.position + input.normalized);
                //アニメーションのSpeedに入力の値を渡す
                animator.SetBool("Run", true);
                //移動する
                velocity += transform.forward * Speed;
            }
            else
            {
                animator.SetBool("Run", false);
            }
        }
        //重力を常にかける
        velocity.y += Physics.gravity.y * Time.deltaTime;
        //CharacterControllerのMove関数にvelocityの値を渡し動かす
        characterController.Move(velocity * Time.deltaTime);
    }

}
