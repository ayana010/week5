using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private Transform[] transArray;

    void Start()
    {
        // サイズ2のTransform配列を初期化
        transArray = new Transform[2];

        // GameObjectのタグを使用してPrefabのTransformを検索し、配列に割り当て
        GameObject redObj = GameObject.FindWithTag("Red");
        if (redObj != null)
        {
            transArray[0] = redObj.transform;
        }
        else
        {
            Debug.LogError("No GameObject with the tag 'Red' was found in the scene.");
        }

        GameObject blueObj = GameObject.FindWithTag("Blue");
        if (blueObj != null)
        {
            transArray[1] = blueObj.transform;
        }
        else
        {
            Debug.LogError("No GameObject with the tag 'Blue' was found in the scene.");
        }
    }

    void Update()
    {
        // "W"キーが押された場合の処理
        if (Input.GetKeyDown(KeyCode.W))
        {
            // z軸を中心にredObjを45度回転
            // RotateAroundを使用してredObjを45度回転
                transArray[0].Rotate(Vector3.forward,angle:45f);
            

            // z軸を中心にblueObjを-45度回転
            
                transArray[1].Rotate(Vector3.forward, angle: -45f);
           
        }

        // "Q"キーが押された場合の処理
        if (Input.GetButtonDown("Fire1")) // "Fire1"はQボタンにマッピングされている必要があります
        {
            
                // redObjとblueObjの垂直位置を交換
                float temp = transArray[0].position.y;
            
            transArray[0].position = new Vector3(transArray[0].position.x, transArray[1].position.y, transArray[0].position.z);
            transArray[1].position = new Vector3(transArray[1].position.x, y:temp, transArray[1].position.z);


        }
    }
}

