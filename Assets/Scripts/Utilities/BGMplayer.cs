using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMplayer : MonoBehaviour
{
    // 静的な変数を使用してインスタンスを管理
    private static BGMplayer instance;

    // BGMを再生するためのAudioSource
    private AudioSource audioSource;

    // シングルトンパターンを使用して唯一のインスタンスを取得
    public static BGMplayer Instance
    {
        get
        {
            if (instance == null)
            {
                GameObject bgmManager = new GameObject("BGMManager");
                instance = bgmManager.AddComponent<BGMplayer>();
                DontDestroyOnLoad(bgmManager);
            }
            return instance;
        }
    }

    // 初期化処理
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            audioSource = gameObject.AddComponent<AudioSource>();
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // BGMを再生するメソッド
    public void PlayBGM(AudioClip bgmClip)
    {
        if (audioSource.isPlaying)
        {
            audioSource.Stop();
        }
        audioSource.clip = bgmClip;
        audioSource.loop = true; // BGMをループ再生
        audioSource.Play();
    }

    // BGMを停止するメソッド
    public void StopBGM()
    {
        audioSource.Stop();
    }
}
