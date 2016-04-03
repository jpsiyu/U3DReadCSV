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
    private ArrayList list;
    private int enumLen = 2;
    string path = string.Format("{0}/../CSV", Application.dataPath);

    private CfgCtrl() {
        list = new ArrayList(System.Enum.GetNames(Type.GetType("CfgType")).Length);
        InitList();
    }

    public static CfgCtrl Instance{ 
        get{
            if (cfgCtrl == null){
                cfgCtrl = new CfgCtrl();
            }
            return cfgCtrl;
        }
    }


    private void InitList() {
        Dictionary<int, CopyCfg> copyDict = new CfgUtility<CopyCfg>().GetFileDict(path, "copy.csv");
        Dictionary<int, ShopCfg> shopDict = new CfgUtility<ShopCfg>().GetFileDict(path, "shop.csv");
        list.Add(copyDict);
        list.Add(shopDict);

    }

    public object GetCfg(CfgType ct, int dkey) {
        object o = null;
        try
        {
            switch (ct)
            {
                case CfgType.Copy:
                    o = ((Dictionary<int, CopyCfg>)list[(int)ct])[dkey];
                    break;
                case CfgType.Shop:
                    o = ((Dictionary<int, ShopCfg>)list[(int)ct])[dkey];
                    break;
                default:
                    break;
            }
            return o;
        }
        catch (Exception e) {
            Debug.LogError(string.Format("key not found:{0}", dkey));
            return null;
        }
    }
}
