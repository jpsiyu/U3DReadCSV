using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Way02Ctrl : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Invoke("Test", 3f);
	}

    void Test() {
        Debug.Log("Start a Test ... ");

        string path = string.Format("{0}/../CSV", Application.dataPath);
        string fileName = "copy.csv";
        Way02Utility<Way02Cfg> utiliy = new Way02Utility<Way02Cfg>();
        List<string[]> list = utiliy.FileToList(path, fileName);

        List<Hashtable> tableList = utiliy.ListToHashtable(list);

        Dictionary<int, Way02Cfg> dict = utiliy.TableListToDict(tableList);

        Debug.Log("Test finish!");
    }
	

}
