using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Panel_CharacterDetail : Panel_Base
{
    /// <summary>
    /// 
    /// </summary>
    protected override void Awake()
    {
        base.Awake();

        pPanelType = EPanelType.CharacterDetail;
    }
}