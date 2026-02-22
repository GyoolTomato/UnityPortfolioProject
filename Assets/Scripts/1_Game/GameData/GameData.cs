using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData : Singleton<GameData>
{
    //
    public GameData_Gacha     pDataGacha     { private set; get; } = null;
    public GameData_Character pDataCharacter { private set; get; } = null;
    public GameData_Shop      pDataShop      { private set; get; } = null;


    public void Init()
    {
        //
        pDataGacha     = new GameData_Gacha   ();
        pDataCharacter = new GameData_Character();
        pDataShop      = new GameData_Shop    ();
    }
}
