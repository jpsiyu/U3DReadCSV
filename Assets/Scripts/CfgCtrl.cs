using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public enum CfgType { 
    Copy,
    Shop,
}



public class CfgCtrl
{

    private static CfgCtrl cfgCtrl;
    private Dictionary<CfgType, ICfgCtrlItem> dictItem;

    private CfgCtrl() {
        dictItem = new Dictionary<CfgType, ICfgCtrlItem>();
        InitItemDict();
    }

    public static CfgCtrl Instance{ 
        get{
            if (cfgCtrl == null){
                cfgCtrl = new CfgCtrl();
            }
            return cfgCtrl;
        }
    }

    private void InitItemDict() {
        dictItem.Add(CfgType.Copy, new CfgCtrlItem<CopyCfg>("copy.csv"));
        dictItem.Add(CfgType.Shop, new CfgCtrlItem<ShopCfg>("shop.csv"));

    }

    public object GetCfg(CfgType ct, int dkey) {
        return dictItem[ct].GetCfg(dkey);
    }

}

public interface ICfgCtrlItem { 
    object GetCfg(int dKey);
}

public class CfgCtrlItem<T> : ICfgCtrlItem where T:ICfg, new()
{
    private Dictionary<int, T> dict;
    private string path;

    public CfgCtrlItem(string fileName){
        path = string.Format("{0}/../CSV", Application.dataPath);
        dict = new CfgUtility<T>().GetFileDict(path, fileName);
    }

    public object GetCfg(int dKey)
    {
        if (dict.ContainsKey(dKey))
            return dict[dKey];
        else
            Debug.LogError("key not found: " + dKey);
            return null;
    }
}
