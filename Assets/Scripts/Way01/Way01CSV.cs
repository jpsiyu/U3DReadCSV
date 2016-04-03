using UnityEngine;
using System.Collections;
using System.IO;
using System.Collections.Generic;
using System;

public class Way01CSV  {

    private static Way01CSV csv;
    private List<string> m_ArrayData;

    public static Way01CSV GetInstance() {
        if (csv == null) {
            csv = new Way01CSV(); 
        }
        return csv;
    }

    public List<string> ArrayData {
        get { return m_ArrayData; }
    }

    private Way01CSV() { m_ArrayData = new List<string>(); }

    public void LoadFile(string path, string fileName) {
        m_ArrayData.Clear();
        StreamReader sr = null;
        string filePath = string.Format("{0}/{1}", path, fileName);
        try {
            sr = File.OpenText(filePath);
        }
        catch (Exception e){
            Debug.LogError("CSV read failed! " + filePath + e.Message);
            return;
        }
        string line;
        while ((line = sr.ReadLine()) != null) {
            m_ArrayData.Add(line);
        }
        sr.Close();
        sr.Dispose();
    }

}
