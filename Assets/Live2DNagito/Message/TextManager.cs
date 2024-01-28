using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TextManager : MonoBehaviour
{
    [SerializeField]
    private TextSetting textSetting;

    [SerializeField]
    private TextMeshProUGUI NameText;

    [SerializeField]
    private TextMeshProUGUI MessageText;

    [SerializeField]
    private LipSyncController lipSync;

    // ナギトのセリフ
    public bool NagitoState = false;

    [SerializeField]
    private float textSpeed = 0.1f; // テキストの速さを調整するための変数

    //現在の配列の場所
    public int currentIndex = 0;

    //現在実行中のコルーチン
    private Coroutine currentCoroutine;

    // クリックイベントの無効フラグ
    private bool clickDisabled = false;


    private void Start()
    {
        // null確認
        if (textSetting != null && textSetting.textData != null && textSetting.textData.Count > 0)
        {
            // 初期テキストの表示
            ShowTextATIndex(currentIndex);
            lipSync.PerformLipSync(textSetting.textData[currentIndex].message);
        }
        else
        {
            Debug.LogWarning("TextSetting or its messages are not assigned.");
        }
    }

    // クリックすると次のテキストを表示する
    public void OnGameScreenClick()
    {

        // クリックイベントが無効になっている場合は何もしない
        if (clickDisabled)
        {
            return;
        }

        // クリックイベントを一時的に無効化
        clickDisabled = true;

        // 現在のコルーチンを強制終了
        if(currentCoroutine != null)
        {
            StopCoroutine(currentCoroutine);
        }

        // 次のテキストを表示
        currentIndex++;
        if(currentIndex < textSetting.textData.Count)
        {
            ShowTextATIndex(currentIndex);

            if(textSetting.textData[currentIndex].N_LipSync == true)
            {
                // テキストが表示されるたびにリップシンクを行う
                lipSync.PerformLipSync(textSetting.textData[currentIndex].message);
            }

        }
        else
        {
            // テキストなくなった
            //　Scene移動
            SceneManager.LoadScene("Classroom");
        }

        // クリックイベントを有効化
        StartCoroutine(EnableClick());
    }

    IEnumerator EnableClick()
    {
        // 0.5秒待機してからクリックイベントを有効化
        yield return new WaitForSeconds(0.5f);
        clickDisabled = false;
    }

    // 指定したインデックスのテキストを表示する関数
    private void ShowTextATIndex(int index)
    {

        // NamaTextにTextSetting
        if(NameText != null)
        {
            NameText.text = textSetting.textData[index].name;
        }

        // MessageTextにTextSettingのmessageを表示
        if (MessageText != null)
        {
            if(currentCoroutine != null)
            {
                StopCoroutine(currentCoroutine);
            }

            // 新しいコルーチンを開始
            currentCoroutine = StartCoroutine(DisplayTextOneByOne(MessageText, textSetting.textData[index].message));
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

