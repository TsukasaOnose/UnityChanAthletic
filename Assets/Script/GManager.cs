using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//静的なゲームマネージャー(かなり使えそう)
public class GManager : MonoBehaviour
{
    //GManagerを静的なものとして設定する
    public static GManager instance = null;
    //取得したイベントアイテムの数
    private int eventItem;
    //コンティニュー数
    [SerializeField] private int continueNum;

    void Awake()
    {
        //実体がない時(インスタンスがない時)
        if (instance == null)
        {
            //インスタンスに自身を入れる(多分)
            instance = this;
            //シーンがロードされた時もこのオブジェクトを破棄しない（今回のゲームでは必要ないけど一応）
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            //中身がすでに入っている場合、このオブジェクトを破棄する(唯一の物にしたいため)
            //開発中は必要
            Destroy(this.gameObject);
        }
    }

    //残機の数を返す関数
    public int GetContinueNum()
    {
        return continueNum;
    }

    //残機を減らす関数
    public void MinusContinueNum()
    {
        continueNum--;
    }
}
