using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Live2D.Cubism.Framework.MouthMovement;

public class LipSyncController : MonoBehaviour
{
    [SerializeField]
    private TextSetting textSetting;

    [SerializeField]
    private TextManager textManager;

    [SerializeField]
    private CubismMouthController mouthController;

    // 口パクの時間　ここでは0.1秒
    [SerializeField]
    private float mouthOpenTime = 0.1f;

    private int currentCharIndex; // 現在の文字のインデックス

    private bool isMouthOpen = false; // 口が開いているかどうかのフラグ


    // リップシンク用
    public void PerformLipSync(string message)
    {
        {
            StartCoroutine(SwitchMouthOpenValue(message));
        }
    }

    // 一定フレームごとにMouthOpeningを切り替える (口パクのやり方)
    private IEnumerator SwitchMouthOpenValue(string message)
    {
        int messageLength = message.Length;
        int currentCharIndex = 0;

        while (currentCharIndex < messageLength)
        {
            // リップシンク処理
            // 文字ごとの待機時間を考慮して口パク制御

            mouthController.MouthOpening = 1.0f;
            yield return new WaitForSeconds(mouthOpenTime); // 切り替え時間（必要に応じて調整）

            mouthController.MouthOpening = 0.0f;
            yield return new WaitForSeconds(mouthOpenTime); // 切り替え時間（必要に応じて調整）

            // 口パクが終了する条件を満たした場合
            if (currentCharIndex >= (textSetting.textData[textManager.currentIndex].message.Length / 2))
            {
                isMouthOpen = false;
                yield break; // コルーチンを終了
            }

            currentCharIndex++;
        }
    }

}
