using UnityEngine;
using System.Collections;
using System.IO;
using System.Collections.Generic;
using System;

public class Way01CSV  {

    private static Way01CSV csv;
    private List<string[]> m_ArrayData;
    private Dictionary<int, Way01Cfg> m_DictData;

    public static Way01CSV GetInstance() {
        if (csv == null) {
            csv = new Way01CSV(); 
        }
        return csv;
    }

    private Way01CSV() { 
        m_ArrayData = new List<string[]>();
        m_DictData = new Dictionary<int, Way01Cfg>();
    }

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
            m_ArrayData.Add(line.Split(','));
        }
        sr.Close();
        sr.Dispose();
        ArrayListToDict();
    }

    private void ArrayListToDict() {
        string[] temp;
        for (int i = 0; i < m_ArrayData.Count; i++) {
            if (i < 2) continue;
            temp = m_ArrayData[i];
            Way01Cfg cfg = new Way01Cfg();
            cfg.Id = int.Parse(temp[0]);
            cfg.Desc = temp[1];
            cfg.M_lock = int.Parse(temp[2]);
            cfg.Cost = int.Parse(temp[3]);
            cfg.Reward = int.Parse(temp[4]);
            cfg.Cd = int.Parse(temp[5]);
            m_DictData.Add(cfg.Id, cfg);
        }
    }

    public Way01Cfg GetCfg(int id) {
        Way01Cfg cfg;
        try
        {
            cfg = m_DictData[id];
            return cfg;
        }
        catch (Exception e)
        {
            Debug.LogError(e.Message);
            return null;
        }
        
    }

}
