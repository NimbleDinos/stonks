using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpsetCompany : MonoBehaviour
{
    bool isColliding = false;
    int moneyThrownCounter;
    CansModel can;
    public GameObject projectile;


    public void Start()
    {
        can = FindObjectOfType<CansModel>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Buisness")
        {
            isColliding = true;
            Debug.Log("am colliding");
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        isColliding = false;
    }

    void Update()
    {
        if (isColliding == true && Input.GetKeyDown(KeyCode.Q))
        {
            //lower stock rate
        }

        if (moneyThrownCounter >= 5)
        {
            //raise stock rate
        }

        ThrowMoney();
    }

    private void ThrowMoney()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            moneyThrownCounter++;
            can.ModifyCans (-1);

            GameObject bullet = Instantiate(projectile, transform.position, Quaternion.identity) as GameObject;
            bullet.GetComponent<Rigidbody>().AddForce(transform.forward * 10);
        }
    }

}
