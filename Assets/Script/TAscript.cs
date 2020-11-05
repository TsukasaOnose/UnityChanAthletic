using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TAscript : MonoBehaviour
{
    //分
    public int minute;
    //秒
    public float seconds;
    //変わる前の秒数
    private float oldSeconds;
    //ベストタイムを入れる
    public Text bestTime;
    //プレイ時間を入れる
    public Text resultTime;
    //ベストタイムの分
    public int bestMinute = 99;
    //ベストタイムの秒
    public float bestSeconds = 59;

    private void Awake()
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        minute = 0;
        seconds = 0;
        oldSeconds = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //クリアするまで
        if (GManager.instance.isCrea != true)
        {
            //始まってからのプレイ時間を取得
            seconds += Time.deltaTime;
            //秒数が60になる度
            if(seconds >=  60)
            {
                //分を1増やす
                minute += 1;
                //秒を0に戻す
                seconds = 0;
            }
            //時間が変わった時
            if ((int)seconds != (int)oldSeconds)
            {
                resultTime.text = minute.ToString("00") + ":" + ((int)seconds).ToString("00");
            }
        }
        //クリア時
        else if (GManager.instance.isCrea == true)
        {
            //リザルトタイムがベストタイムより小さい時(良いタイムの時)
            if(minute <= bestMinute && seconds < bestSeconds)
            {
                bestMinute = minute;
                bestSeconds = seconds;
            }
            //リザルトタイムをベストタイムにする
            bestTime.text = bestMinute.ToString("00") + ":" + ((int)bestSeconds).ToString("00");
        }


    }
}
