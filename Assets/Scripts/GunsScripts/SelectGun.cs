using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectGun : MonoBehaviour
{

    void Start()
    {
        PistolGun pistolGun = new PistolGun();
        SniperGun sniperGun = new SniperGun();
        MachineGun machineGun = new MachineGun();

        pistolGun.SayGunInfo();
        sniperGun.SayGunInfo();
        machineGun.SayGunInfo();
              
    }

   
}
