using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopLineControl : MonoBehaviour
{
    GameObject otherObject;

    private void OnTriggerEnter(Collider other)
    {
        otherObject =  other.gameObject;
        otherObject.GetComponent<BaseControl>()?.StopLine();

        for (int i = 0; i < otherObject.transform.childCount; i++)
        {
            otherObject.transform.GetChild(i).GetComponent<BaseSoldier>()?.StopRunAnimation();
        }
    }
   
}
