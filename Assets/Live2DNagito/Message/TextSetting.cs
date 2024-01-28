using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TextData
{

    [TextArea (1,2)]
    public string name;

    [TextArea(3, 10)]
    public string message;

    public bool N_LipSync;
}

[CreateAssetMenu(menuName = "ScriptableObject/TextSetting", fileName = "TextSetting")]
public class TextSetting : ScriptableObject
{
    public List<TextData> textData;
}
