using System;
using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json;

public class _102_Character
{
    public class Values
    {
        public int key { private set; get; }
        public int name { private set; get; }
        public string model { private set; get; }
        public int hp { private set; get; }
        public int hp_level { private set; get; }
        public int atk { private set; get; }
        public int atk_level { private set; get; }
        public int def { private set; get; }
        public int def_level { private set; get; }
        public float avoid { private set; get; }
        public float avoid_level { private set; get; }
        public float focus { private set; get; }
        public float focus_level { private set; get; }
        public int atkspd { private set; get; }
        public int atkspd_level { private set; get; }
        public float crirate { private set; get; }
        public float crirate_level { private set; get; }
        public float cridmg { private set; get; }
        public float cridmg_level { private set; get; }
        public float speed { private set; get; }
        public int activeSkill { private set; get; }
        public int passiveSkill_0 { private set; get; }
        public int passiveSkill_1 { private set; get; }

        [JsonConstructor]
        public Values(int key,int name,string model,int hp,int hp_level,int atk,int atk_level,int def,int def_level,float avoid,float avoid_level,float focus,float focus_level,int atkspd,int atkspd_level,float crirate,float crirate_level,float cridmg,float cridmg_level,float speed,int activeSkill,int passiveSkill_0,int passiveSkill_1)
        {
            this.key = key;
            this.name = name;
            this.model = model;
            this.hp = hp;
            this.hp_level = hp_level;
            this.atk = atk;
            this.atk_level = atk_level;
            this.def = def;
            this.def_level = def_level;
            this.avoid = avoid;
            this.avoid_level = avoid_level;
            this.focus = focus;
            this.focus_level = focus_level;
            this.atkspd = atkspd;
            this.atkspd_level = atkspd_level;
            this.crirate = crirate;
            this.crirate_level = crirate_level;
            this.cridmg = cridmg;
            this.cridmg_level = cridmg_level;
            this.speed = speed;
            this.activeSkill = activeSkill;
            this.passiveSkill_0 = passiveSkill_0;
            this.passiveSkill_1 = passiveSkill_1;
        }
    }

    public static _102_Character.Values GetItem(int key)
    {
        if (Data.TableDataLoader.Instance._dic_102_Character.ContainsKey(key))
            return Data.TableDataLoader.Instance._dic_102_Character[key];
        else
            return null;
    }


    public static List<_102_Character.Values> GetList()
    {
        return Data.TableDataLoader.Instance._list_102_Character;
    }
}