using UnityEngine;
using System.Collections;

public class CfgTest : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Invoke("Test", 2);
	}
	
	void Test () {
        CfgCtrlHelper h = new CfgCtrlHelper();
        Debug.Log("OK");
	}
}
