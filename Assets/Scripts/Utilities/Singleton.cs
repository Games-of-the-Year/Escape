using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 以下のコードは、Unity公式のInputSystemのサンプルコードから引用しています。
/// https://github.com/UnityTechnologies/InputSystem_Warriors.git
/// </summary>
/// <typeparam name="T"></typeparam>
public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T _instance;

    private static object _lock = new object();

    public static T Instance
    {
        get
        {
            if (applicationIsQuitting)
            {
                Debug.LogWarning("[Singleton] Instance '" + typeof(T) +
                    "' はアプリケーションの終了時に既に破棄されています。" +
                    "nullを返して再び作成されることはありません。");
                return null;
            }

            // ここでロックしているのは、複数のスレッドが同時に
            // インスタンスを作成しようとして、
            // 2つのインスタンスが作成されてしまうのを防ぐためです。
            lock (_lock)
            {
                if (_instance == null)
                {
                    _instance = (T)FindObjectOfType(typeof(T));

                    if (FindObjectsOfType(typeof(T)).Length > 1)
                    {
                        Debug.LogError("[Singleton] 何らかの問題が発生しました。" +
                            " - シングルトンは1つより多く存在してはなりません!" +
                            "シーンを開き直すと直るかもしれません。");
                        return _instance;
                    }

                    if (_instance == null)
                    {
                        GameObject singleton = new GameObject();
                        _instance = singleton.AddComponent<T>();
                        singleton.name = "(singleton)" + typeof(T).ToString();

                        Debug.Log("[Singleton] " + typeof(T) +
                            "のインスタンスがシーンで必要なので、" + singleton +
                            "を作成しました。");
                    }
                }

                return _instance;
            }
        }
    }

    private static bool IsDontDestroyOnLoad()
    {
        if (_instance == null)
        {
            return false;
        }
        // オブジェクトはシーンのライフサイクルとは無関係に存在する。
        // それはDontDestroyOnLoad() が設定されていることを意味する。
        if ((_instance.gameObject.hideFlags & HideFlags.DontSave) == HideFlags.DontSave)
        {
            return true;
        }
        return false;
    }

    private static bool applicationIsQuitting = false;

    public void OnDestroy()
    {
        if (IsDontDestroyOnLoad())
        {
            applicationIsQuitting = true;
        }
    }
}
