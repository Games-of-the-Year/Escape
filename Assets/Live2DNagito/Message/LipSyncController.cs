using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Live2D.Cubism.Framework.MouthMovement;

public class LipSyncController : MonoBehaviour
{
    [SerializeField]
    private TextSetting textSetting;

    [SerializeField]
    private CubismMouthController mouthController;

    // 口パクの時間　ここでは0.1秒
    [SerializeField]
    private float mouthOpenTime = 0.1f;

    private int currentCharIndex; // 現在の文字のインデックス

    private bool isMouthOpen = false; // 口が開いているかどうかのフラグ

    // Update is called once per frame
    void Update()
    {
        // null確認
        if (textSetting != null && mouthController != null)
        {
            // TextSettingのmessageに合わせてLive2Dの口パクを制御
            string currentMessage = textSetting.textData[0].message;

            //Debug.Log("currentChar Index" + currentCharIndex);

            //Debug.Log("currentMessage: " + currentMessage.Length / 2);
            //Debug.Log("count: " + currentCharIndex);

            // 特定の条件で口パクを終了する
            if (currentCharIndex >= (currentMessage.Length / 2))
            {
                return;
            }

            // Live2Dモデルの口パクを制御
            // テキストの長さに応じて口の開閉を制御する
            SetMouthOpenValues(currentMessage);
        }
    }

    // 口の開閉の値を設定する関数
    void SetMouthOpenValues(string text)
    {
        if (!isMouthOpen)
        {
            StartCoroutine(SwitchMouthOpenValue());
            isMouthOpen = true;
        }

    }

    // 一定フレームごとにMouthOpeningを切り替える
    IEnumerator SwitchMouthOpenValue()
    {
        while (true)
        {
            mouthController.MouthOpening = 1.0f;
            yield return new WaitForSeconds(mouthOpenTime); // 切り替え時間（必要に応じて調整）

            mouthController.MouthOpening = 0.0f;
            yield return new WaitForSeconds(mouthOpenTime); // 切り替え時間（必要に応じて調整）

            // 口パクが終了する条件を満たした場合
            if (currentCharIndex >= (textSetting.textData[0].message.Length / 2))
            {
                isMouthOpen = false;
                yield break; // コルーチンを終了
            }

            currentCharIndex++;
        }
    }
}
