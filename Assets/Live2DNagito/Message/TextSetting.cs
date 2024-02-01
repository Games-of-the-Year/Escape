using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


// Image種類
public enum BGType
{
    None = 0,
    Black = 1,
    Classroom = 2,
    BadEnd = 3,
    HappyStill = 4,
    Entrance = 5,

}


[System.Serializable]
public class TextData
{

    [TextArea (1,2)]
    public string name;

    [TextArea(3, 10)]
    public string message;

    public bool N_LipSync = false;

    public bool N_Off = false;

    public BGType _BGType;
}


[CreateAssetMenu(menuName = "ScriptableObject/TextSetting", fileName = "TextSetting")]
public class TextSetting : ScriptableObject
{
    public List<TextData> textData;

}
