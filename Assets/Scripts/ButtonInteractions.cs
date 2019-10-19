using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonInteractions : MonoBehaviour
{

    DataModel dm;
    CansModel cm;
    bool canAffords = false;


    // Start is called before the first frame update
    void Start()
    {
        dm = GetComponent<DataModel>();
        cm = GetComponent<CansModel>();
    }

    public void SellOne()
    {
        dm.ModifyStock(-1);
        cm.ModifyCans(1);
    }

    public void SellOneHundred()
    {
        dm.ModifyStock(-100);
        cm.ModifyCans(100);
    }

    public void SellTen()
    {
        dm.ModifyStock(-10);
        cm.ModifyCans(10);
    }

    public void BuyOne()
    {
        if (cm.cansAmount > dm.beansCost)
        {
            dm.ModifyStock(1);
            cm.ModifyCans(- dm.beansCost);
        }
    }

    public void BuyTen()
    {
        dm.ModifyStock(10);
        cm.ModifyCans(-10);
    }

    public void BuyOneHundred()
    {
        dm.ModifyStock(100);
        cm.ModifyCans(-100);
    }

    public void canAfford()
    {
       //if(cm.cansAmount > )
    }
}
