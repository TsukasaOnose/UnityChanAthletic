using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreaClick : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //画面をクリックしたらシーンをロードしなおす
        if(Input.GetMouseButtonDown(0))
        {
            GameObject.Find(StageController.STR).GetComponent<StageController>().Retry();
        }
    }
}
