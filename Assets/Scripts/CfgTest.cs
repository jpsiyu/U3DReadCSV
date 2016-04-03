using UnityEngine;
using System.Collections;

public class CfgTest : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Invoke("Test", 2);
	}
	
	void Test () {
        CopyCfg cCfg = CfgCtrl.Instance.GetCfg(CfgType.Copy, 1001) as CopyCfg;
        ShopCfg sCfg = CfgCtrl.Instance.GetCfg(CfgType.Shop, 100001) as ShopCfg;
        ShopCfg sCfg2 = CfgCtrl.Instance.GetCfg(CfgType.Shop, 10123) as ShopCfg;
        Debug.Log("OK");
	}
}
