using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewsPaperCreator : MonoBehaviour
{
    public GameObject Paper;
    GameObject clone;

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
                Vector3 spawn = new Vector3(transform.position.x,transform.position.y+6,transform.position.z+1);
                Quaternion quaternion = Quaternion.Euler(-90,0,0);

                clone = Instantiate(Paper,spawn,quaternion);
                Paper.GetComponent<PaperText>().text.text = paperHeadLine;
                timeCheck = Time_Handler.currentHour; 
            }
        }
    }
}