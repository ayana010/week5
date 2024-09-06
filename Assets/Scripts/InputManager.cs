using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private Transform[] transArray;
    private Renderer redRenderer; // RedオブジェクトのRenderer
    private Renderer blueRenderer; // BlueオブジェクトのRenderer
    
    void Start()
    {
        // サイズ2のTransform配列を初期化
        transArray = new Transform[2];
        // LoadAssetsスクリプトからredObjとblueObjの参照を取得
        LoadAssets loadAssets = GameObject.FindFirstObjectByType<LoadAssets>(); // シーンからLoadAssetsコンポーネントを探す
        if (loadAssets != null)
        {
            if (loadAssets.redObj != null)
            {
                transArray[0] = loadAssets.redObj.transform;
                PrintAndHide redPrintAndHide = loadAssets.redObj.GetComponent<PrintAndHide>(); // PrintAndHideコンポーネントを取得
                if (redPrintAndHide != null)
                {
                    redRenderer = redPrintAndHide.rend; // rend変数を取得
                }
                else
                {
                    Debug.LogError("PrintAndHide component not found on redObj.");
                }
            }
            else
            {
                Debug.LogError("redObj not found in LoadAssets.");
            }

            if (loadAssets.blueObj != null)
            {
                transArray[1] = loadAssets.blueObj.transform;
                PrintAndHide bluePrintAndHide = loadAssets.blueObj.GetComponent<PrintAndHide>(); // PrintAndHideコンポーネントを取得
                if (bluePrintAndHide != null)
                {
                    blueRenderer = bluePrintAndHide.rend; // rend変数を取得
                }
                else
                {
                    Debug.LogError("PrintAndHide component not found on blueObj.");
                }
            }
            else
            {
                Debug.LogError("blueObj not found in LoadAssets.");
            }

        }


        else
        {
            Debug.LogError("No GameObject with the tag 'Blue' was found in the scene.");
        }
        SetColors();
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
            
                  //redObjとblueObjの垂直位置を交換
                 float temp = transArray[0].position.y;
            
            transArray[0].position = new Vector3(transArray[0].position.x, transArray[1].position.y, transArray[0].position.z);
            transArray[1].position = new Vector3(transArray[1].position.x, y:temp, transArray[1].position.z);

            if (redRenderer != null)
            {
                // Redオブジェクトの色をランダムに設定
                float redValue = Random.Range(51.0f / 255.0f, 250.0f / 255.0f);
                redRenderer.material.color = new Color(redValue, 0.0f, 0.0f);
                Debug.Log("Red: " + redRenderer.material.color); // 新しい色をコンソールに出力
            }

            if (blueRenderer != null)
            {
                // Blueオブジェクトの色をランダムに設定
                float blueValue = Random.Range(51.0f/255.0f, 250.0f/255.0f);
                blueRenderer.material.color = new Color(0.0f, 0.0f, blueValue);
                Debug.Log("Blue: " + blueRenderer.material.color); // 新しい色をコンソールに出力
            }

        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            TogglePrintAndHide();

        }
    }

    void TogglePrintAndHide()
    {
        // PrintAndHideコンポーネントの切り替え
        ToggleComponent<PrintAndHide>(transArray[0].gameObject);
        ToggleComponent<PrintAndHide>(transArray[1].gameObject);
    }

    void ToggleComponent<T>(GameObject obj) where T : Component
    {
        T component = obj.GetComponent<T>();
        if (component != null)
        {
            Destroy(component);
        }
        else
        {
            component = obj.AddComponent<T>();
            PrintAndHide printAndHide = component as PrintAndHide;
            if (printAndHide != null)
            {
                if (printAndHide.rend == null)
                {
                    printAndHide.rend = obj.GetComponent<Renderer>();
                }
                if (printAndHide.rend != null && !printAndHide.rend.enabled)
                {
                    printAndHide.rend.enabled = true;
                }
            }
        }
    }

    void SetColors()
    {
        if (redRenderer != null)
        {
            redRenderer.material.color = new Color(1f, 0f, 0f); // 初期色を赤に設定
        }

        if (blueRenderer != null)
        {
            blueRenderer.material.color = new Color(0f, 0f, 1f); // 初期色を青に設定
        }
    }
}

