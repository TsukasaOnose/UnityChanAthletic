using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//静的なゲームマネージャー(かなり使えそう)
public class GManager : MonoBehaviour
{
    //GManagerを静的なものとして設定する
    public static GManager instance = null;
    //取得したイベントアイテムの数
    public int eventItem;
    //コンティニュー数
    public int continueNum;

    void Awake()
    {
        //実体がない時(インスタンスがない時)
        if (instance == null)
        {
            //インスタンスに自身を入れる(多分)
            instance = this;
            //シーンがロードされた時もこのオブジェクトを破棄しない
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            //中身がすでに入っている場合、このオブジェクトを破棄する(唯一の物にしたいため)
            //開発中は必要
            Destroy(this.gameObject);
        }
    }
}
