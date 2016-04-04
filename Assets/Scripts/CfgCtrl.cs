using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Reflection;

public enum CfgType { 
    Copy,
    Shop,
}


public class CfgCtrl
{

    private static CfgCtrl cfgCtrl;
    private Dictionary<CfgType, ICfgCtrlItem> dictItem;
    private int enumLen = 2;
    string path = string.Format("{0}/../CSV", Application.dataPath);

    private CfgCtrl() {
        dictItem = new Dictionary<CfgType, ICfgCtrlItem>();
        InitDictStruct();
    }

    public static CfgCtrl Instance{ 
        get{
            if (cfgCtrl == null){
                cfgCtrl = new CfgCtrl();
            }
            return cfgCtrl;
        }
    }

    private void InitDictStruct() {
        Dictionary<int, CopyCfg> copyDict = new CfgUtility<CopyCfg>().GetFileDict(path, "copy.csv");
        Dictionary<int, ShopCfg> shopDict = new CfgUtility<ShopCfg>().GetFileDict(path, "shop.csv");

        ICfgCtrlItem itemCopy = new CfgCtrlItem<CopyCfg>(copyDict);
        ICfgCtrlItem itemShop = new CfgCtrlItem<ShopCfg>(shopDict);

        dictItem.Add(CfgType.Copy, itemCopy);
        dictItem.Add(CfgType.Shop, itemShop);

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
