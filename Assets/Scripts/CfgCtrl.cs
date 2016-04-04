using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public enum CfgType { 
    Copy,
    Shop,
}

public struct CfgStruct {
    public Dictionary<int, CopyCfg> copyCfg;
    public Dictionary<int, ShopCfg> shopCfg;
}

public class CfgCtrl
{

    private static CfgCtrl cfgCtrl;
    private CfgStruct cfgStruct;
    private int enumLen = 2;
    string path = string.Format("{0}/../CSV", Application.dataPath);

    private CfgCtrl() {
        cfgStruct = new CfgStruct();
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

        cfgStruct.copyCfg = copyDict;
        cfgStruct.shopCfg = shopDict;
    }

    public object GetCfg(CfgType ct, int dkey)
    {
        if (ct == CfgType.Copy)
            if(cfgStruct.copyCfg.ContainsKey(dkey))
                return cfgStruct.copyCfg[dkey];
        if (ct == CfgType.Shop)
            if(cfgStruct.shopCfg.ContainsKey(dkey))
                return cfgStruct.shopCfg[dkey];

        Debug.LogError("key not found: " + dkey);
        return null;
    }


}
