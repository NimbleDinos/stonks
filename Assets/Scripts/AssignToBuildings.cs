using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssignToBuildings : MonoBehaviour
{
    public List<GameObject> companyBuildings;

    private void Start()
    {
        for (int i = 0; i < companyBuildings.Count; i++)
        {
            Globals.companies[i].SetBuilding(companyBuildings[i]);
            Globals.companies[i].SetBuildingScale();
        }
    }
}
