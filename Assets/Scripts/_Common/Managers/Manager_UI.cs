using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using Unity.VisualScripting;

public class Manager_UI : Singleton<Manager_UI>
{
    //
    ELanguage _language;

    //
    List<Panel_Base> _panels = new List<Panel_Base>();
    List<Com_Base> _coms = new List<Com_Base>();

    Transform _board_0;
    Transform _board_1;
    Transform _board_2;

    //
    AssetReference SpawnablePrefab;


    /// <summary>
    /// 
    /// </summary>
    public void Init()
    {
        _language = ELanguage.Korean;

        _board_0 = GameObject.Find("Board_0").transform;
        _board_1 = GameObject.Find("Board_1").transform;
        _board_2 = GameObject.Find("Board_2").transform;
    }

    /// <summary>
    /// 
    /// </summary>
    public void Clear()
    {
        _panels.Clear();
    }

    /// <summary>
    /// 
    /// </summary>
    public Panel_Base CreatePanel(EPanelType panelType)
    {
        UnityEngine.Object loadObject = null;
        switch (panelType)
        {
            case EPanelType.Title:
                loadObject = Resources.Load("0_Logo/Panel_Title");
                break;
            default:
                loadObject = Manager_Addressable.Instance.GetUI(panelType);
                break;
        }

        //
        var createObject = GameObject.Instantiate(loadObject, _board_0) as GameObject;
        createObject.transform.localPosition = Vector3.zero;

        var panel = createObject.GetComponent<Panel_Base>();
        _panels.Add(panel);
        return panel;
    }

    ///<summary>
    ///
    ///</summary>
    public Panel_Base GetPanel(EPanelType panelType)
    {
        //
        Panel_Base returnPanel = null;

        //
        foreach (Panel_Base panel in _panels)
        {
            if (panel.pPanelType == panelType)
            {
                returnPanel = panel;
                break;
            }
        }

        //
        return returnPanel;
    }

    ///<summary>
    ///
    ///</summary>
    public Panel_Base ShowPanel(EPanelType panelType)
    {
        //
        var panel = GetPanel(panelType);
        if (panel == null)
            panel = CreatePanel(panelType);
                
        //
        if (panel != null && panel.pIsShow == false)
            panel.pIsShow = true;

        //
        return panel;
    }

    /// <summary>
    /// 
    /// </summary>
    public void HidePanel(EPanelType panelType)
    {
        //
        var panel = GetPanel(panelType);
        if (panel == null)
            return;
        //
        if (panel.pIsShow == true)
            panel.gameObject.SetActive(false);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="key"></param>
    /// <returns></returns>
    public string GetText(int key)
    {
        var temp = _900_TextCommon.GetItem(key);
        if (temp == null)
            return string.Empty;

        switch (_language)
        {
            case ELanguage.Korean  : return temp.korean;
            case ELanguage.Japanese: return temp.japanese;
            default                : return temp.english;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="key"></param>
    /// <returns></returns>
    public string GetNotice(int key)
    {
        var temp = _902_TextNotice.GetItem(key);
        if (temp == null)
            return string.Empty;

        switch (_language)
        {
            case ELanguage.Korean: return temp.korean;
            case ELanguage.Japanese: return temp.japanese;
            default: return temp.english;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="messageKey"></param>
    /// <param name="type"></param>
    /// <param name="onConfirm"></param>
    /// <param name="onCancel"></param>
    public void ShowMessageBox(int messageKey, Panel_MessageBox.EType type, Action onConfirm = null, Action onCancel = null)
    {
        var panel = ShowPanel(EPanelType.MessageBox) as Panel_MessageBox;
        panel.Init(messageKey, type, onConfirm, onCancel);
    }
}
