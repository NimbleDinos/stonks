using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightCycle : MonoBehaviour
{
    public float anglePerHour = 15.0f;

    void Update()
    {
        float rotation = Time_Handler.currentHour * anglePerHour;

        transform.localEulerAngles = new Vector3(rotation, 0.0f, 0.0f);

        //TODO change to sin on intensity?
    }
}
