using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewsPaperCreator : MonoBehaviour
{
    public GameObject Paper;
    int timeCheck;
    string paperHeadLine;

    // Start is called before the first frame update
    void Start()
    {
        timeCheck = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        paperHeadLine = newsGen.newsHeadline;

        if (timeCheck != Time_Handler.currentHour)
        {
            if (Time_Handler.currentHour >= 9 && Time_Handler.currentHour <= 20)
            {
                Instantiate(Paper);
                Paper.GetComponent<PaperText>().text.text = paperHeadLine;
                timeCheck = Time_Handler.currentHour; 
            }
        }
    }
}