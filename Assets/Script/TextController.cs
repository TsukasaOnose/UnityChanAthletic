using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextController : MonoBehaviour
{
    //チュートリアル文を格納する
    public string[] tutrials;
    //テキストを入れる
    public Text uiText;
    //現在のテキストの番号
    int textNum = 0;

    // Start is called before the first frame update
    void Start()
    {
        //テキストを更新する関数を呼び出し
        TextUpdataNext();
        //時間停止
        Time.timeScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //テキスト番号が最後までいってない時にクリックした場合
        if (textNum < tutrials.Length && Input.GetMouseButtonDown(0))
        {
            //テキストを次に更新する関数を呼び出す
            TextUpdataNext();
        }
        //テキスト番号が0より大きい時に、右クリックした場合
        else if (0 < textNum && Input.GetMouseButtonDown(1))
        {
            //テキストを1つ前に戻す関数を呼び出す
            TextUpdataBack();
        }
        //テキスト番号が最後の時にクリックした場合、チュートリアル画面を終了
        else if (textNum == tutrials.Length && Input.GetMouseButton(0))
        {
            //時間停止を解除
            Time.timeScale = 1;
            //チュートリアルオブジェクトを破棄
            Destroy(this.gameObject);
        }
    }

    //テキストを更新する関数
    void TextUpdataNext()
    {
        //現在のテキストをuiTextに入れる
        uiText.text = tutrials[textNum];
        //現在のテキスト番号を1つ追加
        textNum++;
    }
    void TextUpdataBack()
    {
        textNum--;
        uiText.text = tutrials[textNum];
    }
}
