using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadAssets : MonoBehaviour
{
    public GameObject redPrefab;  // redPrefabの参照
    public GameObject bluePrefab; // bluePrefabの参照

     public GameObject redObj;    // redObjの参照を公開
    public GameObject blueObj;   // blueObjの参照を公開

    void Awake()
    {
        // redPrefabとbluePrefabをインスタンス化してシーンに配置
        redObj = Instantiate(redPrefab);
        blueObj = Instantiate(bluePrefab);

        // redObjとblueObjをそれぞれ指定された位置に配置
        redObj.transform.position = new Vector3(2, 1, 0);
        blueObj.transform.position = new Vector3(-2, -1, 0);

        // タグを設定する（もしプレハブにタグが設定されていない場合）
        redObj.tag = "Red";
        blueObj.tag = "Blue";
    }
}

