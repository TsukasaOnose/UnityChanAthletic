using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventItem : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        //イベントアイテムがプレイヤーに衝突した時
        if(other.gameObject.tag == "Player")
        {
            //イベントアイテム数を1増やす
            GManager.instance.PlusEventItem();
            //このオブジェクトを削除する
            Destroy(this.gameObject);
        }
    }

}
