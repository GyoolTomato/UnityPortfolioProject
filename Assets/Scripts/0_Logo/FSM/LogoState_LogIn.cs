using Data;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class LogoState_LogIn : LogoState
{
    //
    public LogoState_LogIn(ELogoState state) : base(state)
    {
        
    }

    //
    override public void Enter()
    {       

        var panel = Manager_UI.Instance.GetPanel(EPanelType.Title) as Panel_Title;
        panel.Init();
    }

    //
    override public void Exit()
    {

    }

    //
    override public void Update()
    {
        
    }

    //
    public void DoLogIn(string id, string password)
    {
        GameManager.ChangeGameScene();
    }
}
