using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunType 
{
    protected int gunSpeed;
    protected int gunWeight;
    protected string gunColor;
    

    public void SayGunInfo()
    {
        Debug.Log("Gun speed " + gunSpeed);
        Debug.Log("Gun weight " + gunWeight);
        Debug.Log("Gun color " + gunColor);

    }

}
