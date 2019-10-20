using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewsPaperCreator : MonoBehaviour
{
    public GameObject Paper;
    int timeCheck;

    // Start is called before the first frame update
    void Start()
    {
        timeCheck = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (timeCheck != Time_Handler.currentHour)
        {
            Instantiate(Paper);
            timeCheck = Time_Handler.currentHour;
        }
    }
}