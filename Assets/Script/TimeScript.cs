using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeScript : MonoBehaviour
{
    //分
    public int minute = 10;
    //秒
    public float seconds = 0;
    //変わる前の秒数
    private float oldSeconds = 0;
    //時間を表示するテキスト
    private Text timeText;

    // Start is called before the first frame update
    void Start()
    {
        timeText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        //一秒ごとに1ずつ減らす
        seconds -= Time.deltaTime;
        //分はマイナスにならない
        if (minute < 0) minute = 0;
        //秒数が0になるたび
        if (seconds <= 0f)
        {
            if (minute > 0)
            {
                //秒数を60に戻す
                seconds += 60f;
                //分を1減らす
                minute--;
            }
            else
            {
                seconds = 0;
            }


            //時間が0になったら
            if (minute == 0 && seconds == 0)
            {

                //タイムアップ関数を呼び出す
                GameObject.Find(StageController.STR).GetComponent<StageController>().TimeUp();
            }
        }

        //時間が変わった時
        if((int)seconds != (int)oldSeconds)
        {
            timeText.text = minute.ToString("00") + ":" + ((int)seconds).ToString("00");
        }
    }
}
