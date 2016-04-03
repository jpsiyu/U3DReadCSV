using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System;
using System.Reflection;

public class Way02Utility<T> where T:Way02ICfg, new() {


    /// <summary>
    /// Put CSV data into a 2d list
    /// </summary>
    public List<string[]> FileToList(string path, string fileName) {
        List<string[]> list = new List<string[]>();
        StreamReader sr = null;
        string filePath = string.Format("{0}/{1}", path, fileName);
        try
        {
            sr = File.OpenText(filePath);
        }
        catch (Exception e) {
            Debug.LogError(string.Format("CSV read failed! {0} {1}", filePath, e.Message));
            return null;
        }
        string line;
        while ((line = sr.ReadLine()) != null) {
            list.Add(line.Split(','));
        }
        sr.Close();
        sr.Dispose();
        return list;
    }

    public List<Hashtable> ListToHashtable(List<string[]> list) {
        List<Hashtable> tableList = new List<Hashtable>();
        string[] sKey = list[0];
        string[] sType = list[1];
        for (int i = 0; i < list.Count; i++) {
            if (i < 2) continue; // the first 2 row is common
            Hashtable temp = new Hashtable();
            string[] sRow = list[i];
            for (int j = 0; j < sRow.Length; j++) {
                temp.Add(UpperFirst(sKey[j]), sRow[j]);
            }
            tableList.Add(temp);
        }

        return tableList;
    }

    public string UpperFirst(string s){
        return s.Substring(0, 1).ToUpper() + s.Substring(1);
    }


    /// <summary>
    /// Use Dict to hold all data object of T
    /// </summary>
    public Dictionary<int, T> TableListToDict(List<Hashtable> tableList)
    { 
        Dictionary<int, T> dict = new Dictionary<int, T>();
        Hashtable sRow;
        for (int i = 0; i < tableList.Count; i++)
        {
            sRow = tableList[i];
            T t = HashtableToT(sRow);
            dict.Add(t.GetId(), t);
        }
        return dict;
    }

    /// <summary>
    /// Use table's data to fill a object of T
    /// </summary>
    public T HashtableToT(Hashtable table)
    {
        T t = new T();
        PropertyInfo[] info = t.GetType().GetProperties();
        foreach (PropertyInfo p in info) {
            if (p.PropertyType == typeof(int))
            {
                p.SetValue(t, int.Parse(table[p.Name].ToString()), null);
            }
            else
            {
                p.SetValue(t, table[p.Name].ToString(), null);
            }
        }
        return t;
    }

}
