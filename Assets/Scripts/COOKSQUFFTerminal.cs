using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class COOKSQUFFTerminal : BeansTerminal
{

    // Start is called before the first frame update
    public override void Start()
    {
        stock = "COOKSQUFF";

        UpdateUI();

   

        for (int i = 0; i < Globals.companies.Count; i++)
        {

            if (Globals.companies[i].name == "COOKSQUFF")
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
