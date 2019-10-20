using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PriceManager : MonoBehaviour
{
    public float canssAmount;
    Text cansText;
    CansModel coon;

    public float Stocks()
    {
        return canssAmount;
    }

    public void ModifyCans(int _cans)
    {
        canssAmount += _cans;
        canssAmount = Mathf.Clamp(canssAmount, 0, Mathf.Infinity);
    }

    // Start is called before the first frame update
    void Start()
    {
        cansText = GameObject.Find("Cans Text").GetComponent<Text>();
        coon = GetComponent<CansModel>();
        canssAmount = coon.cansAmount;
    }

    // Update is called once per frame
    void Update()
    {
        cansText.text = "Cans: " + canssAmount.ToString();
    }
}
