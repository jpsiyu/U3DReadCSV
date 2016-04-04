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
    private string path;

    private CfgCtrl() {
        path = string.Format("{0}/../CSV", Application.dataPath);
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
        Dictionary<int, CopyCfg> copyDict = new CfgUtility<CopyCfg>().GetFileDict(path, "copy.csv");
        Dictionary<int, ShopCfg> shopDict = new CfgUtility<ShopCfg>().GetFileDict(path, "shop.csv");


        dictItem.Add(CfgType.Copy, new CfgCtrlItem<CopyCfg>(copyDict));
        dictItem.Add(CfgType.Shop, new CfgCtrlItem<ShopCfg>(shopDict));

    }

    public object GetCfg(CfgType ct, int dkey) {
        return dictItem[ct].GetCfg(dkey);
    }

}

public interface ICfgCtrlItem { 
    object GetCfg(int dKey);
}

public class CfgCtrlItem<T> : ICfgCtrlItem {
    private Dictionary<int, T> dict;

    public CfgCtrlItem(Dictionary<int, T> d) {
        dict = d;
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
