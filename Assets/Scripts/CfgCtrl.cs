using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CfgCtrl : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        Invoke("Test", 3f);
    }

    void Test()
    {
        Debug.Log("Start a Test ... ");

        string path = string.Format("{0}/../CSV", Application.dataPath);
        string fileName = "copy.csv";
        CfgUtility<CopyCfg> utiliy = new CfgUtility<CopyCfg>();
        List<string[]> list = utiliy.FileToList(path, fileName);

        List<Hashtable> tableList = utiliy.ListToHashtable(list);

        Dictionary<int, CopyCfg> dict = utiliy.TableListToDict(tableList);

        Debug.Log("Test finish!");
    }


}
