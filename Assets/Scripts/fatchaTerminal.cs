using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class fatchaTerminal : MonoBehaviour
{
    public float stockAmount;
    Text stockText;
    public int beansCost;
    string stock = "fatcha";

    public float Stocks()
    {
        return stockAmount;
    }

    public void ModifyStock(int _stocks)
    {
        stockAmount += _stocks;
        stockAmount = Mathf.Clamp(stockAmount, 0, Mathf.Infinity);
    }

    // Start is called before the first frame update
    void Start()
    {
        stockText = GameObject.Find("Stock Text").GetComponent<Text>();

        for (int i = 0; i < Globals.companies.Count; i++)
        {

            if (Globals.companies[i].name == "fatcha")
            {
                beansCost = Globals.companies[i].stonkValue;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        stockText.text = stock + " Stocks: " + stockAmount.ToString();
    }
}
