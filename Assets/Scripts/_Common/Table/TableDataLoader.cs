using System;
using System.Collections.Generic;
using UnityEngine.AddressableAssets;
using Newtonsoft.Json;

namespace Data
{
    public class TableDataLoader : Singleton<TableDataLoader>
    {
        public Dictionary<int, _000_Notice.Values> _dic_000_Notice = new Dictionary<int, _000_Notice.Values>();
        public List<_000_Notice.Values> _list_000_Notice = new List<_000_Notice.Values>();
        public Dictionary<int, _102_Character.Values> _dic_102_Character = new Dictionary<int, _102_Character.Values>();
        public List<_102_Character.Values> _list_102_Character = new List<_102_Character.Values>();
        public Dictionary<int, _900_TextCommon.Values> _dic_900_TextCommon = new Dictionary<int, _900_TextCommon.Values>();
        public List<_900_TextCommon.Values> _list_900_TextCommon = new List<_900_TextCommon.Values>();
        public Dictionary<int, _901_TextCharacter.Values> _dic_901_TextCharacter = new Dictionary<int, _901_TextCharacter.Values>();
        public List<_901_TextCharacter.Values> _list_901_TextCharacter = new List<_901_TextCharacter.Values>();
        public Dictionary<int, _902_TextNotice.Values> _dic_902_TextNotice = new Dictionary<int, _902_TextNotice.Values>();
        public List<_902_TextNotice.Values> _list_902_TextNotice = new List<_902_TextNotice.Values>();


        public void Init()
        {
            var temp_000_Notice = JsonConvert.DeserializeObject<List<_000_Notice.Values>>(Manager_Addressable.Instance.GetTable("Assets/Table/_000_Notice.bytes").text);
            foreach (var item in temp_000_Notice)
            {
                _list_000_Notice.Add(item);
                _dic_000_Notice.Add(item.key, item);
            }
            var temp_102_Character = JsonConvert.DeserializeObject<List<_102_Character.Values>>(Manager_Addressable.Instance.GetTable("Assets/Table/_102_Character.bytes").text);
            foreach (var item in temp_102_Character)
            {
                _list_102_Character.Add(item);
                _dic_102_Character.Add(item.key, item);
            }
            var temp_900_TextCommon = JsonConvert.DeserializeObject<List<_900_TextCommon.Values>>(Manager_Addressable.Instance.GetTable("Assets/Table/_900_TextCommon.bytes").text);
            foreach (var item in temp_900_TextCommon)
            {
                _list_900_TextCommon.Add(item);
                _dic_900_TextCommon.Add(item.key, item);
            }
            var temp_901_TextCharacter = JsonConvert.DeserializeObject<List<_901_TextCharacter.Values>>(Manager_Addressable.Instance.GetTable("Assets/Table/_901_TextCharacter.bytes").text);
            foreach (var item in temp_901_TextCharacter)
            {
                _list_901_TextCharacter.Add(item);
                _dic_901_TextCharacter.Add(item.key, item);
            }
            var temp_902_TextNotice = JsonConvert.DeserializeObject<List<_902_TextNotice.Values>>(Manager_Addressable.Instance.GetTable("Assets/Table/_902_TextNotice.bytes").text);
            foreach (var item in temp_902_TextNotice)
            {
                _list_902_TextNotice.Add(item);
                _dic_902_TextNotice.Add(item.key, item);
            }
        }

    }
}