using UnityEngine;
using System.Collections;

public class Way01Ctrl : MonoBehaviour
{

    private string path;
    private string fileName;

	// Use this for initialization
	void Start () {

        path = string.Format("{0}/../CSV", Application.dataPath);
        fileName = "copy.csv";

        Way01CSV.GetInstance().LoadFile(path, fileName);
        Way01Cfg cfg = Way01CSV.GetInstance().GetCfg(1001);
        Debug.Log(cfg.ToString());

	}
	

}
