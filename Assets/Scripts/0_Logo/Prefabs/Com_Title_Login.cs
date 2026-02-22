using UnityEngine;

public class Com_Title_Login : Com_Base
{
    /// <summary>
    /// 
    /// </summary>
    public void Init()
    {

    }

    /// <summary>
    /// 
    /// </summary>
    public void OnBtnGoogleLogin()
    {
        
    }

    /// <summary>
    /// 
    /// </summary>
    public void OnBtnGuestLogin()
    {
        LogoScene.pStateLogIn.DoLogIn(string.Empty, string.Empty);
    }
}
