using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class funBornTerminal : BeansTerminal
{
    // Start is called before the first frame update
    public override void Start()
    {
        stock = "funBorn";

        UpdateUI();

    

        for (int i = 0; i < Globals.companies.Count; i++)
        {

            if (Globals.companies[i].name == "funBorn")
            {
                canCost = Globals.companies[i].stonkValue;
            }
        }
    }

    public override void UpdateUI()
    {
        stockText.text = stock + " Stocks: " + stockAmount.ToString();
        for (int i = 0; i < Globals.companies.Count; i++)
        {
            if (Globals.companies[i].name == "funBorn")
            {
                canCost = Globals.companies[i].stonkValue;
                showStockPrice.text = "Cost: " + canCost;
            }
        }
    }
}
