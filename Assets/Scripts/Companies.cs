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
    GameObject companyBuilding;
    float maxSize;
    float minSize = 0.25f;

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

        SetBuildingScale();
    }

    public List<History> getStonkHistory()
    {
        return stonkHistory;
    }

    public void updateStonkHistory(int time, int price)
    {
        stonkHistory.Add(new History(time, price));
    }

    public void SetBuilding(GameObject building)
    {
        companyBuilding = building;
        maxSize = companyBuilding.transform.localScale.z;
    }

    public void SetBuildingScale()
    {
        float scaleRange = maxSize - minSize;
        float scalePercentage = ((float)stonkValue - 1) / 9999;         

        float newYScale = (scaleRange * scalePercentage) + minSize;

        Debug.Log("Y Val: " + newYScale);
        Vector3 newScale = new Vector3(companyBuilding.transform.localScale.x, companyBuilding.transform.localScale.y, newYScale);
        companyBuilding.transform.localScale = newScale;
    }
}
