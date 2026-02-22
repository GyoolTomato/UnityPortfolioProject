using UnityEngine;

public class Manager_Character : Singleton<Manager_Character>
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="character"></param>
    /// <returns></returns>
    public double GetAtk(Character character)
    {
        var temp = 0d;

        temp = character.pLevel * character.pTable.atk_level;

        return temp;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="studentId"></param>
    /// <param name="exp"></param>
    /// <returns></returns>
    public bool DoAddExp(int studentId, int exp)
    {
        //
        var student = GameData.Instance.pDataCharacter.GetCharacter(studentId);
        if (student == null)
            return false;

        //
        student.pExp += exp;

        //
        return true;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="studentId"></param>
    /// <returns></returns>
    public bool DoSkillLevelUp_Active(int studentId)
    {
        //
        var student = GameData.Instance.pDataCharacter.GetCharacter(studentId);
        if (student == null)
            return false;

        //
        if (student.pActiveLv >= 5)
            return false;

        student.pActiveLv += 1;

        //
        return true;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="studentId"></param>
    /// <param name="skillIndex"></param>
    /// <returns></returns>
    public bool DoSkillLevelUp_Passive(int studentId, int skillIndex)
    {
        //
        var student = GameData.Instance.pDataCharacter.GetCharacter(studentId);
        if (student == null)
            return false;

        //
        if (skillIndex >= student.pPassiveLv.Length)
        {
            return false;
        }
        
        //
        student.pPassiveLv[skillIndex] += 1;

        //
        return true;
    }

    public bool DoCharmUp(int studentId, int charmValue)
    {
        //
        var student = GameData.Instance.pDataCharacter.GetCharacter(studentId);
        if (student == null)
            return false;
        
        //
        student.pCharm += charmValue;

        //
        return true;
    }
}
