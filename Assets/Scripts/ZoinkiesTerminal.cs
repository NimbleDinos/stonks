using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ZoinkiesTerminal : BeansTerminal
{
    // Start is called before the first frame update
    public override void Start()
    {
        stock = "Zoinkies";

        UpdateUI();

        for (int i = 0; i < Globals.companies.Count; i++)
        {

            if (Globals.companies[i].name == "Zoinkies")
            {
                canCost = Globals.companies[i].stonkValue;
            }
        }
    }

    public override void UpdateUI()
    {
        stockText.text = stock + " Stocks: " + stockAmount.ToString();
    }
}
