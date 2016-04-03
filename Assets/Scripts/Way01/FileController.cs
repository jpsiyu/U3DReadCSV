using UnityEngine;
using System.Collections;

public class FileController : MonoBehaviour {

    private string path;
    private string fileName;

	// Use this for initialization
	void Start () {

        path = string.Format("{0}/../CSV", Application.dataPath);
        fileName = "copy.csv";

        Way01CSV.GetInstance().LoadFile(path, fileName);

        foreach (string s in Way01CSV.GetInstance().ArrayData) {
            Debug.Log(s);
        }
	}
	

}
