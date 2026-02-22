using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using TMPro;

public class Com_Notice_Slot : Com_Base
{
    //
    [SerializeField] TextMeshProUGUI _title = null;

    _000_Notice.Values _tableData = null;
    Action<_000_Notice.Values> _onBtn = null;

    /// <summary>
    /// 
    /// </summary>
    public void Init(int key, Action<_000_Notice.Values> onBtn)
    {
        _tableData = _000_Notice.GetItem(key);
        _onBtn = onBtn;

        _000_Notice.Values a = new _000_Notice.Values(1, "", "", 1, 2, 3);
        
        _title.text = Manager_UI.Instance.GetNotice(_tableData.title);
    }

    /// <summary>
    /// 
    /// </summary>
    public void OnBtn()
    {
        _onBtn?.Invoke(_tableData);
    }
}
