using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class History
{
    int time;
    int price;

    public int getTime()
    {
        return time;
    }

    public int getPrice()
    {
        return price;
    }
}

public class Company
{
    string name;
    int stonkValue;
    List<History> stonkHistory;

    public Company(string name, int stonkValue)
    {
        this.name = name;
        this.stonkValue = stonkValue;
        this.stonkHistory = new List<History>();
    }

    public string getName()
    {
        return name;
    }

    public int getStonkValue()
    {
        return stonkValue;
    }

    public List<History> getStonkHistory()
    {
        return stonkHistory;
    }
}
