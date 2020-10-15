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
            //テキストに残機を表示
            continueText.text = "×" + GManager.instance.continueNum;
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
        //GManagerで設定した残機と変わるたび、残機の表示を更新する
        if(oldContinuetNum != GManager.instance.continueNum)
        {
            continueText.text = "×" + GManager.instance.continueNum;
            oldContinuetNum = GManager.instance.continueNum;
        }
    }
}
