using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PeachTerminal : BeansTerminal
{
    // Start is called before the first frame update
    public override void Start()
    {
        stock = "Peach ";

        UpdateUI();

        //stockText = GameObject.Find("Stock Text").GetComponent<Text>();

        for (int i = 0; i < Globals.companies.Count; i++)
        {

            if (Globals.companies[i].name == "Peach")
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
