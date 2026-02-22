using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum ELanguage
{
    Korean,
    English,
    Japanese,
}

public enum ESceneType
{
    None,
    Logo,
    Game,
    End,
}

public enum ELogoState
{
    None,
    Logo,
    Download,
    LogIn,    
    End,
}

public enum EGameState
{
    None,
    Main,
    Stage,
    End,
}

public enum EPanelType
{
    None,
    Title,
    Main,
    Characters,
    Gacha,
    Formation,
    Shop,
    Mail,
    LobbyCharacter,
    Missions,
    Works,
    Notice,
    PlayerInfo,
    CharacterDetail,
    MessageBox,

    Group_0,
    Group_1,
    Group_2,
    End,
}

public enum EItemType
{
    None,
    Crystal,
    Gold,
}

public enum ECharacterAnim
{
    None,
    Idle,
    Walking,
    Running,
    Jumping,
    Attack,
    Die,
    Ceremony,
    End,
}

public enum ECharacterState
{
    None,
    Idle,
    Walking,
    Running,
    Jumping,
    Attack,
    Die,
    Ceremony,
    End,
}
