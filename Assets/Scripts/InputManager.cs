using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private Transform[] transArray;

    void Start()
    {
        // サイズ2のTransform配列を宣言
        transArray = new Transform[2];

        // redPrefabとbluePrefabのTransformを取得して配列に割り当て
        GameObject redPrefab = GameObject.FindWithTag("Red");
        GameObject bluePrefab = GameObject.FindWithTag("Blue");

        if (redPrefab != null)
        {
            transArray[0] = redPrefab.transform;
        }

        if (bluePrefab != null)
        {
            transArray[1] = bluePrefab.transform;
        }
    }
}

