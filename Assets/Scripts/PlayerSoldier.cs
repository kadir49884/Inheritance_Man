using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class PlayerSoldier : BaseSoldier, IChangeValue
{

   
    public void ChangeScale()
    {
        transform.localScale = new Vector3(transform.localScale.x - 0.0002f, transform.localScale.y - 0.0002f, transform.localScale.z - 0.0002f);
    }

    public void DamageValue()
    {
        damageValue += 1;
    }


}
