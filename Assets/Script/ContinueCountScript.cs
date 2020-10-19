using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ContinueCountScript : MonoBehaviour
{
    //残機の数を表示するテキストの変数
    private Text continueText;
    //元の残機を入れる変数
    private int oldContinuetNum;

    // Start is called before the first frame update
    void Start()
    {
        //テキストコンポーネントを取得
        continueText = GetComponent<Text>();
        //ゲームマネージャーの中身がnullでない時
        if (GManager.instance != null)
        {
            //GetContinueNum関数で残機数を取得し、テキストに残機を表示
            continueText.text = "×" + GManager.instance.GetContinueNum();
        }
        //Gmanagerの中身がnullの時
        else
        {
            //このオブジェクトを破棄
            Destroy(this);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //GManagerで設定した残機と変わるたび
        if(oldContinuetNum != GManager.instance.GetContinueNum())
        {
            //GetCountinueNum関数で残機数を取得し、残機の表示を更新する
            continueText.text = "×" + GManager.instance.GetContinueNum();
            //oldContinueNumを更新する
            oldContinuetNum = GManager.instance.GetContinueNum();
        }
    }
}
