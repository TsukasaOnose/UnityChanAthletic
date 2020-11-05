using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CreaTextController : MonoBehaviour
{
    //クリア文を格納する
    public string[] creaTexts;
    //テキストを入れる
    public Text uiText;
    //現在のテキストの番号
    int textNum;
    //TitlePanelを格納する
    public GameObject titlePanel;

    // Start is called before the first frame update
    void Start()
    {
        textNum = 0;
        //テキストを更新する関数を呼び出し
        TextUpdataNext();
        this.titlePanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        Time.timeScale = 0;
        //テキスト番号が最後までいってない時にクリックした場合
        if (textNum < creaTexts.Length && Input.GetMouseButtonDown(0))
        {
            Debug.Log("クリック");
            //テキストを次に更新する関数を呼び出す
            TextUpdataNext();
        }

        //テキスト番号が最後の時にクリックした場合、クリア画面を終了
        else if (textNum == creaTexts.Length && Input.GetMouseButton(0))
        {
            this.titlePanel.SetActive(true);
        }
    }

    //テキストを更新する関数
    void TextUpdataNext()
    {
        //現在のテキストをuiTextに入れる
        uiText.text = creaTexts[textNum];
        //現在のテキスト番号を1つ追加
        textNum++;
    }
}
