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

    private void Start()
    {

        // null確認
        if (textSetting != null && textSetting.textData != null)
        {
            // NameTextにTextSettingのnameを表示
            if (NameText != null)
            {
                NameText.text = textSetting.textData[0].name;
            }

            // MessageTextにTextSettingのmessageを表示
            if (MessageText != null)
            {
                StartCoroutine(DisplayTextOneByOne(MessageText, textSetting.textData[0].message));
                //MessageText.text = textSetting.textData[0].message;
            }

            // Nameがナギトの場合、NagitoStateをtureに設定
            if (textSetting.textData[0].name == "ナギト")
            {
                NagitoState = true;
            }


        }
        else
        {
            Debug.LogWarning("TextSetting or its messages are not assigned.");
        }
    }

    IEnumerator DisplayTextOneByOne(TextMeshProUGUI textMesh, string fullText)
    {
        for (int i = 0; i <= fullText.Length; i++)
        {
            textMesh.text = fullText.Substring(0, i);
            yield return new WaitForSeconds(textSpeed); // 待機時間を変数で指定
        }
    }
}

