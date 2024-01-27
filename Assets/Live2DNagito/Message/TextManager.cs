using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextManager : MonoBehaviour
{
    [SerializeField]
    private TextSetting textSetting;

    [SerializeField]
    private TextMeshProUGUI NameText;

    [SerializeField]
    private TextMeshProUGUI MessageText;

    // ナギトのセリフ
    public bool NagitoState = false;

    [SerializeField]
    private float textSpeed = 0.1f; // テキストの速さを調整するための変数

    //現在の配列の場所
    private int currentIndex = 0;

    private void Start()
    {
        // null確認
        if (textSetting != null && textSetting.textData != null && textSetting.textData.Count > 0)
        {
            // 初期テキストの表示
            ShowTextATIndex(currentIndex);
        }
        else
        {
            Debug.LogWarning("TextSetting or its messages are not assigned.");
        }
    }


    public void OnGameScreenClick()
    {
        Debug.Log("クリックした");
        // 次のテキストを表示
        currentIndex++;
        if(currentIndex < textSetting.textData.Count)
        {
            ShowTextATIndex(currentIndex);
        }
        else
        {
            Debug.Log("No more texts to display");
        }
    }

    // 指定したインデックスのテキストを表示する関数
    private void ShowTextATIndex(int index)
    {
        Debug.Log("TextCount: " + index + "Message: " + textSetting.textData[index].message);

        // NamaTextにTextSetting
        if(NameText != null)
        {
            NameText.text = textSetting.textData[index].name;
        }

        // MessageTextにTextSettingのmessageを表示
        if (MessageText != null)
        {
            StartCoroutine(DisplayTextOneByOne(MessageText, textSetting.textData[index].message));
        }
    }

    // テキストを一文字ずつ表示するコルーチン
    IEnumerator DisplayTextOneByOne(TextMeshProUGUI textMesh, string fullText)
    {
        for (int i = 0; i <= fullText.Length; i++)
        {
            textMesh.text = fullText.Substring(0, i);
            yield return new WaitForSeconds(textSpeed); // 待機時間を変数で指定
        }
    }
}

