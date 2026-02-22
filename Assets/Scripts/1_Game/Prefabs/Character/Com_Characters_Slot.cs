using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Com_Characters_Slot : Com_Base
{
    //
    [SerializeField] Image _portrait;
    [SerializeField] TextMeshProUGUI _name;
    [SerializeField] TextMeshProUGUI _value;

    //
    Character _character = null;
    Action _onClick = null;

    //
    public void Init(Character character, Panel_Characters.EViewMode viewMode, Action onClick)
    {
        //
        _character = character;
        if (_character == null)
        {
            return;
        }

        //
        _onClick = onClick;
        _portrait.sprite = null;
        _name.text = string.Empty;

        SetValue(viewMode);
    }

    /// <summary>
    /// 
    /// </summary>
    public void SetValue(Panel_Characters.EViewMode viewMode)
    {
        //
        switch (viewMode)
        {
            case Panel_Characters.EViewMode.Level:
                _value.text = string.Format("Lv. {0}", _character.pLevel);
                break;
            case Panel_Characters.EViewMode.Grade:
                _value.text = string.Format("¡Ú {0}", _character.pGrade);
                break;
            default:
                break;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public void OnClick()
    {
        _onClick?.Invoke();
    }
}
