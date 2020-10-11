using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerHorizontal : MonoBehaviour
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
    public float jumpPower = 3f;
    //ジャンプした時の高さ
    private float jumpPos;
    //ジャンプの高さ制限
    public float jumpHeight = 1f;
    //接地判定
    private bool isGround = false;
    //ジャンプ判定
    private bool isJump = false;


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
        //接地判定の取得
        isGround = characterController.isGrounded;

        //左右の入力を取得する
        Vector3 input = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);

        //接地時
        if (isGround)
        {
            //掛かっている速度をリセットする(しないとどっか飛んでく)
            velocity = Vector3.zero;
            //ジャンプ落下アニメーションまたは上昇アニメーションが再生されていた時
            if (animator.GetBool("JumpFall") || animator.GetBool("JumpUp"))
            {
                //ジャンプ落下アニメーションを無効
                animator.SetBool("JumpFall", false);
                //ジャンプ上昇アニメーションを無効
                animator.SetBool("JumpUp", false);
                //着地アニメーションを再生
                animator.SetTrigger("JumpLanding");
            }

            //ジャンプ上昇アニメーションも無効
            animator.SetBool("JumpUp", false);

            //入力の長さが0.1より大きい時且つ、着地アニメーションが終わっている時
            if (input.magnitude > 0.1f　&& !animator.GetBool("JumpLanding"))
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

            //ジャンプキーを押した時且つ、着地アニメーションが終わっている時
            if (Input.GetKey(KeyCode.Space) && !animator.GetBool("JumpLanding"))
            {
                //ジャンプ開始アニメーションを再生
                animator.SetTrigger("JumpStart");
                //上方向へジャンプ力を代入
                velocity.y = jumpPower;
                //ジャンプした位置を記録
                jumpPos = transform.position.y;
                //ジャンプ判定を有効
                isJump = true;
            }
            //スペースキーを離した時
            else
            {
                //ジャンプ上昇アニメーションは無効
                animator.SetBool("JumpUp", false);
                //ジャンプ判定を無効(ここでジャンプ判定を無効にしている為、
                //ジャンプキーを押さずにただ落下している時に落下アニメーションが再生されない)
                isJump = false;
                //上にかかる速度を0
                velocity.y = 0f;
            }
        }
        //ジャンプ判定時
        else if (isJump)
        {
            //掛かっている速度をリセットする(しないとどっか飛んでく)
            velocity = Vector3.zero;
            //上方向を押している時
            bool pushJumpKey = Input.GetKey(KeyCode.Space);
            //現在の高さがジャンプ可能な高さか
            bool canHeight = jumpPos + jumpHeight > transform.position.y;

            //ジャンプキーを押している且つジャンプ可能な高さの時
            if (pushJumpKey && canHeight)
            {
                //ジャンプ上昇アニメーションを再生
                animator.SetBool("JumpUp", true);
                //上方向にジャンプ力を代入し続ける
                velocity.y = jumpPower;
            }
            //ジャンプキーを押していない、またはジャンプ可能高さにいない時
            else if (!pushJumpKey || !canHeight)
            {
                //ジャンプ上昇アニメーションを無効
                animator.SetBool("JumpUp", false);
                //ジャンプ落下アニメーションを再生
                animator.SetBool("JumpFall", true);
                //ジャンプ判定を無効
                isJump = false;
            }

            //ジャンプ上昇中であれば移動可能（本当は落下中も移動したい）
            //入力の長さが0.1より大きい時且つ、着地アニメーションが終わっている時
            if (input.magnitude > 0.1f && !animator.GetBool("JumpLanding"))
            {
                //入力した方向へ向かせる
                transform.LookAt(transform.position + input.normalized);
                //移動する
                velocity += transform.forward * Speed;
            }
            else
            {
                velocity += transform.forward * 0f;
            }
        }
        //重力を常にかける
        velocity.y += Physics.gravity.y * Time.deltaTime;
        //CharacterControllerのMove関数にvelocityの値を渡し動かす
        characterController.Move(velocity * Time.deltaTime);
    }
    //敵との接触判定
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "EnemyTag")
        {
            Debug.Log("敵と接触した");
        }
    }

}
