using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CansModel : MonoBehaviour
{
    public float cansAmount;
    Text cansText;
    public BeansTerminal bt;

    public float Stocks()
    {
        return cansAmount;
    }

    public void ModifyCans(int _cans)
    {
        cansAmount += _cans;
        cansAmount = Mathf.Clamp(cansAmount, 0, Mathf.Infinity);
    }

    // Start is called before the first frame update
    void Start()
    {
        cansText = GameObject.Find("Cans Text").GetComponent<Text>();
        cansAmount = 800;
    }

    // Update is called once per frame
    void Update()
    {
        cansText.text = "Cans: " + cansAmount.ToString();
    }
}
