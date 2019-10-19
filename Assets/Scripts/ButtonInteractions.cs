using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonInteractions : MonoBehaviour
{

    DataModel dm;
    CansModel cm;


    // Start is called before the first frame update
    void Start()
    {
        dm = GetComponent<DataModel>();
        cm = GetComponent<CansModel>();
    }

    public void SellOne()
    {
        if(dm.stockAmount >= 1)
        {
            dm.ModifyStock(-1);
            cm.ModifyCans(1 * dm.beansCost);
        }
    }

    public void SellOneHundred()
    {
        if (dm.stockAmount >= 100)
        {
            dm.ModifyStock(-100);
            cm.ModifyCans(100 * dm.beansCost);
        }
    }

    public void SellTen()
    {
        if(dm.stockAmount >= 10)
        {
            dm.ModifyStock(-10);
            cm.ModifyCans(10 * dm.beansCost);
        }
    }

    public void BuyOne()
    {
        if (cm.cansAmount >= dm.beansCost)
        {
            dm.ModifyStock(1);
            cm.ModifyCans(- dm.beansCost);
        }
    }

    public void BuyTen()
    {
        if (cm.cansAmount >= dm.beansCost * 10)
        {
            dm.ModifyStock(10);
            cm.ModifyCans(-dm.beansCost * 10);
        }
    }

    public void BuyOneHundred()
    {

        if (cm.cansAmount >= dm.beansCost * 100)
        {
            dm.ModifyStock(100);
            cm.ModifyCans(-dm.beansCost * 100);
        }
    }
}
