using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : BaseControl
{

    [SerializeField]
    private GameObject crosshair;
    Vector3 _targetPostition;
    private bool _shootLock = true;
    private float _shootTime = 0.5f;

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
    }
    protected override void Update()
    {
        
        if (gameManager.CurrentState == State.Shoot)
        {
            if (Input.GetMouseButton(0) && _shootLock)
            {
                Invoke(nameof(LateShoot), _shootTime);
                _shootLock = false;
            }
            for (int i = 0; i < transform.childCount; i++)
            {
                _targetPostition = new Vector3(crosshair.transform.position.x,
                                        transform.position.y,
                                        crosshair.transform.position.z);

                transform.GetChild(i).LookAt(_targetPostition);
            }
            
        }
    }

    protected override void LateShoot()
    {
        base.LateShoot();
        _shootLock = true;
    }


}
