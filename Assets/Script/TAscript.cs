using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class TAscript : MonoBehaviour
{
    //分
    public int minute;
    //秒
    public float seconds;
    //ベストタイムの分
    public int bestMinute;
    //ベストタイムの秒
    public float bestSeconds;
    //変わる前の秒数
    private float oldSeconds;
    //プレイ時間を入れる
    public Text resultTime;
    //ベストタイムを入れる
    public Text bestTime;
    //テキストオブジェクト
    public GameObject bestTimeObject = null;

    private void Awake()
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        //初期化
        minute = 0;
        seconds = 0;
        oldSeconds = 0;

        /*bestMinute = PlayerPrefs.GetInt("Minute", 9);
        bestSeconds = PlayerPrefs.GetFloat("Seconds", 59);*/

        //SaveDataのLoad関数を呼び出す
        SaveData savedata = Load();
        //読み込んだベストタイムをログに表示
        Debug.Log(savedata.bestTimeMinute);
        Debug.Log(savedata.bestTimeSeconds);
        //SaveDataに保存されたベストタイムを反映する
        bestMinute = savedata.bestTimeMinute;
        bestSeconds = savedata.bestTimeSeconds;

    }

    // Update is called once per frame
    void Update()
    {
        //画面上にベストタイムを表示
        Text bestTimeText = bestTimeObject.GetComponent<Text>();
        bestTimeText.text = "BestTime " + bestMinute.ToString("00") + ":" + ((int)bestSeconds).ToString("00");

        //クリアするまで
        if (GManager.instance.isCrea != true)
        {
            //始まってからのプレイ時間を取得
            seconds += Time.deltaTime;
            //秒数が60になる度
            if (seconds >= 60)
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
            //タイムがベストタイムより小さかった時(ベストタイムを更新した時)
            if (minute <= bestMinute && seconds < bestSeconds)
            {
                //ベストタイムにタイムを代入
                bestMinute = minute;
                bestSeconds = seconds;

                /*//スコアを保持
                PlayerPrefs.SetInt("Minute", bestMinute);
                PlayerPrefs.SetFloat("Seconds", bestSeconds);
                PlayerPrefs.Save();*/

                //SaveDataクラスのsaveDataを作成
                SaveData saveData = new SaveData();
                //saveData内のベストタイムを書き換える
                saveData.bestTimeMinute = minute;
                saveData.bestTimeSeconds = seconds;
                //Save関数を呼び出す
                Save(saveData);
            }
            //ベストタイムに表示
            bestTime.text = bestMinute.ToString("00") + ":" + ((int)bestSeconds).ToString("00");
        }


    }

    public void Save(SaveData saveData)
    {
        //StreamWriterクラスのインスタンスwriterを作成
        StreamWriter writer;

        //saveDataをJSON型に変換し、string型のjsonstrに代入
        string jsonstr = JsonUtility.ToJson(saveData);
        //writerにファイルを書き込むパスを代入(第二引数がfalseだと上書き、trueだと追加で書き込む)
        //Application.dataPath + "/savedata.json"だと、プロジェクト内のAssetファイル内に書き込まれる
        writer = new StreamWriter(Application.dataPath + "/savedata.json", false);
        //jsonstrのデータを書き込み
        writer.Write(jsonstr);
        //データを確実に書き込むためのコード？
        writer.Flush();
        //ストリームを閉じるコード
        writer.Close();
    }

    public SaveData Load()
    {
        //Application.dataPath + "/savedata.json"のファイルがあるか確認
        if (File.Exists(Application.dataPath + "/savedata.json"))
        {
            //string型のdatastr変数
            string datastr = "";
            //StreamReaderクラスのインスタンスreaderを作成
            StreamReader reader;

            //readerにパスを代入
            reader = new StreamReader(Application.dataPath + "/savedata.json");
            //ReadToEnd関数でdatastrを読み込み
            datastr = reader.ReadToEnd();
            //ストリームを閉じる
            reader.Close();

            //datastrに代入されているJSON形式のデータをSaveDataに代入して、returnで返す
            return JsonUtility.FromJson<SaveData>(datastr);
        }

        //savedataがなかった場合、新しくデータを作成
        SaveData saveData = new SaveData();
        saveData.bestTimeMinute = 9;
        saveData.bestTimeSeconds = 59;
        return saveData;
    }
}
