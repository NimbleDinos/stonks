using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonInteractions : MonoBehaviour
{

    BeansTerminal dm;
    CansModel cm;

    // Start is called before the first frame update
    void Start()
    {
        cm = FindObjectOfType<CansModel>();
    }

    private void OnEnable()
    {
        if (cm != null)
        {
            if (cm.bt != null)
            {
                dm = cm.bt;
                dm.UpdateUI();
            }
        }
    }

    public void SellOne()
    {
        if(cm.bt.stockAmount >= 1)
        {
            cm.bt.ModifyStock(-1);
            cm.ModifyCans(1 * cm.bt.canCost);
            cm.bt.UpdateUI();
        }
    }

    public void SellOneHundred()
    {
        if (cm.bt.stockAmount >= 100)
        {
            cm.bt.ModifyStock(-100);
            cm.ModifyCans(100 * cm.bt.canCost);
            cm.bt.UpdateUI();
        }
    }

    public void SellTen()
    {
        if(cm.bt.stockAmount >= 10)
        {
            cm.bt.ModifyStock(-10);
            cm.ModifyCans(10 * cm.bt.canCost);
            cm.bt.UpdateUI();
        }
    }

    public void BuyOne()
    {
        if (cm.cansAmount >= cm.bt.canCost)
        {
            cm.bt.ModifyStock(1);
            cm.ModifyCans(- cm.bt.canCost);
            cm.bt.UpdateUI();
        }
    }

    public void BuyTen()
    {
        if (cm.cansAmount >= cm.bt.canCost * 10)
        {
            cm.bt.ModifyStock(10);
            cm.ModifyCans(-cm.bt.canCost * 10);
            cm.bt.UpdateUI();
        }
    }

    public void BuyOneHundred()
    {

        if (cm.cansAmount >= cm.bt.canCost * 100)
        {
            cm.bt.ModifyStock(100);
            cm.ModifyCans(- cm.bt.canCost * 100);
            cm.bt.UpdateUI();
        }
    }
}
