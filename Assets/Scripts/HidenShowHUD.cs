using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HidenShowHUD : MonoBehaviour
{
    public GameObject stockHUD;
    private bool isShowing;
    bool isColliding = false;

    public BeansTerminal bt;
    private CansModel cm;

    // Start is called before the first frame update
    void Start()
    {
        cm = GetComponent<CansModel>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isColliding == true && Input.GetKeyDown(KeyCode.E))
        {
          
            isShowing = !isShowing;
         
            stockHUD.SetActive(isShowing);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Terminal")
        {
            bt = collision.gameObject.GetComponent<BeansTerminal>();
            cm.bt = bt;
            cm.bt.UpdateUI();
            isColliding = true;
            Debug.Log("am colliding");
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        isColliding = false;
    }
}
