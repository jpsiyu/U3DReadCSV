using UnityEngine;
using System.Collections;

public class ShopCfg : ICfg
{

    private int id;
    private string desc;
    private int sType;
    private int price;
    private int addValue;
    private int timeLimit;


    public int GetId()
    {
        return Id;
    }

    public int Id
    {
        get { return id; }
        set { id = value; }
    }

    public string Desc
    {
        get { return desc; }
        set { desc = value; }
    }

    public int SType
    {
        get { return sType; }
        set { sType = value; }
    }

    public int Price
    {
        get { return price; }
        set { price = value; }
    }

    public int AddValue
    {
        get { return addValue; }
        set { addValue = value; }
    }

    public int TimeLimit
    {
        get { return timeLimit; }
        set { timeLimit = value; }
    }
 
}
