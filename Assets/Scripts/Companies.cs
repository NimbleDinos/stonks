using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class History
{
    int time;
    int price;

    public History(int time, int price)
    {
        this.time = time;
        this.price = price;
    }

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

    public void setStonkValue(int stonkValue)
    {
        this.stonkValue = stonkValue;
    }

    public List<History> getStonkHistory()
    {
        return stonkHistory;
    }

    public void updateStonkHistory(int time, int price)
    {
        stonkHistory.Add(new History(time, price));
    }
}
