using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BeansTerminal : MonoBehaviour
{

    public float stockAmount;
    public Text stockText;
    public Text showStockPrice;
    public int canCost;
    public string stock = "Bean Corp";


    public float Stocks()
    {
        return stockAmount;
    }

    public void ModifyStock(int _stocks)
    {
        stockAmount += _stocks;
        stockAmount = Mathf.Clamp(stockAmount,0, Mathf.Infinity);
    }

    // Start is called before the first frame update
    public virtual void Start()
    {
        //stockText = GameObject.Find("Stock Text").GetComponent<Text>();

        UpdateUI();

        for (int i = 0; i < Globals.companies.Count; i++)
        {

            if (Globals.companies[i].name == "Bean Corp")
            {
                canCost = Globals.companies[i].stonkValue;
            }
        }
    }

    public virtual void UpdateUI()
    {
        stockText.text = stock + " Stocks: " + stockAmount.ToString();
        for (int i = 0; i < Globals.companies.Count; i++)
        {
            if (Globals.companies[i].name == "Bean Corp")
            {
                canCost = Globals.companies[i].stonkValue;
                showStockPrice.text = "Cost: " + canCost;
            }
        }
    }
}
