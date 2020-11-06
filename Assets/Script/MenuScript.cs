using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuScript : MonoBehaviour
{
    //メニュー画面のUIパネル
    [SerializeField] private GameObject menuUI;

    // Start is called before the first frame update
    void Start()
    {
        menuUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //Eキーを押した時、タイトルパネルを表示する(クリアしてない時の条件は恐らく必要)
        if(Input.GetKeyDown("e") && GManager.instance.isCrea != true)
        {
            //メニュー画面のアクティブ、非アクティブを切替
            menuUI.SetActive(!menuUI.activeSelf);

            //メニュー画面が表示されている時は時間停止
            if(menuUI.activeSelf)
            {
                Time.timeScale = 0;
            }
            else
            {
                Time.timeScale = 1;
            }
        }
    }
}
