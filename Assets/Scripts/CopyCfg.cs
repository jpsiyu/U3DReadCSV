using UnityEngine;
using System.Collections;

public class CopyCfg : ICfg
{

    private int id;
    private string desc;
    private int lockLv;
    private int cost;
    private int reward;
    private int cd;

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

    public int LockLv
    {
        get { return lockLv; }
        set { lockLv = value; }
    }

    public int Cost
    {
        get { return cost; }
        set { cost = value; }
    }

    public int Reward
    {
        get { return reward; }
        set { reward = value; }
    }

    public int Cd
    {
        get { return cd; }
        set { cd = value; }
    }
}
