using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.UI;

public class Panel_Main : Panel_Base
{
    //
    [SerializeField] Com_UserAssets _comUserAssets = null;



    /// <summary>
    /// 
    /// </summary>
    protected override void Awake()
    {
        //
        base.Awake();

        //
        pPanelType = EPanelType.Main;
    }


    private void OnDestroy()
    {
        Debug.LogWarning(
            $"[OnDestroy] {gameObject.name} destroyed!\n" +
            $"Scene: {gameObject.scene.name}\n" +
            $"Parent: {(transform.parent != null ? transform.parent.name : "None")}\n" +
            $"IsDontDestroyOnLoad: {gameObject.scene.name == "DontDestroyOnLoad\\"}"
    );
    }

    /// <summary>
    /// 
    /// </summary>
    public void Init()
    {        
        //
        _comUserAssets.Init(EItemType.Crystal, EItemType.Gold);

       
    }

    /// <summary>
    /// 
    /// </summary>
    public void OnBtnPlayerInfo()
    {
        var panel = Manager_UI.Instance.ShowPanel(EPanelType.PlayerInfo) as Panel_Characters;
        panel.Init();
    }

    /// <summary>
    /// 
    /// </summary>
    public void OnBtnNotice()
    {
        var panel = Manager_UI.Instance.ShowPanel(EPanelType.Notice) as Panel_Notice;
        panel.Init();
    }

    /// <summary>
    /// 
    /// </summary>
    public void OnBtnMissions()
    {
        var panel = Manager_UI.Instance.ShowPanel(EPanelType.Missions) as Panel_Missions;
        panel.Init();
    }

    /// <summary>
    /// 
    /// </summary>
    public void OnBtnLobbyCharacter()
    {
        var panel = Manager_UI.Instance.ShowPanel(EPanelType.LobbyCharacter) as Panel_Characters;
        panel.Init();
    }

    /// <summary>
    /// 
    /// </summary>
    public void OnBtnMail()
    {
        var panel = Manager_UI.Instance.ShowPanel(EPanelType.Mail) as Panel_Characters;
        panel.Init();
    }

    /// <summary>
    /// 
    /// </summary>
    public void OnBtnOthers()
    {

    }
    
    /// <summary>
    /// 
    /// </summary>
    public void OnBtnHideUI()
    {

    }

    /// <summary>
    /// 
    /// </summary>
    public void OnBtnChangeView()
    {

    }

    /// <summary>
    /// 
    /// </summary>
    public void OnBtnStudents()
    {
        var panel = Manager_UI.Instance.ShowPanel(EPanelType.Characters) as Panel_Characters;
        panel.Init();
    }

    /// <summary>
    /// 
    /// </summary>
    public void OnBtnFormation()
    {
        var panel = Manager_UI.Instance.ShowPanel(EPanelType.Formation) as Panel_Formation;
        panel.Init();
    }

    /// <summary>
    /// 
    /// </summary>
    public void OnBtnShop()
    {
        var panel = Manager_UI.Instance.ShowPanel(EPanelType.Shop) as Panel_Shop;
        panel.Init();
    }

    /// <summary>
    /// 
    /// </summary>
    public void OnBtnGacha()
    {
        var panel = Manager_UI.Instance.ShowPanel(EPanelType.Gacha) as Panel_Gacha;
        panel.Init();
    }
}
