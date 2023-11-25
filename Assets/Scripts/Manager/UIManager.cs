using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : Singleton<UIManager>
{
    [Header("Sub-Behaviour")]
    public UIMenuBehaviour uiMenuBehaviour;

    public void SetupManager()
    {
        uiMenuBehaviour.SetupBehaviour();
    }
}
