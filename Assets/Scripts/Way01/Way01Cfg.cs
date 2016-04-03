using UnityEngine;
using System.Collections;

public class Way01Cfg  {
    private int id;
    private string desc;
    private int m_lock;
    private int cost;
    private int reward;
    private int cd;

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

    public int M_lock
    {
        get { return m_lock; }
        set { m_lock = value; }
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

    public override string ToString()
    {
        string myself = string.Format("Way01Cfg,Id:{0},Desc:{1},M_lock:{2},Cost:{3},Reward:{4},Cd:{5}",
            Id, Desc, M_lock, Cost, Reward, Cd);
        return myself;
    }

}
