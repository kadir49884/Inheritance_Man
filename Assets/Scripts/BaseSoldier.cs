using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BaseSoldier : MonoBehaviour
{
   
    protected float healt = 100;
    Rigidbody _rb;
    protected bool _died = false;

    protected float damageValue = 5;

    protected float countDown = 3;

    GameManager gameManager;

    protected Animator anim;

    [SerializeField]
    protected float addForceValue = 1000;

    protected BoxCollider _soldierObject;

    protected virtual void Start()
    {
        gameManager = GameManager.Instance;
        anim = gameObject.GetComponent<Animator>();

        _soldierObject = GetComponent<BoxCollider>();
    }

    private void Update()
    {
        if (gameManager.CurrentState == State.Shoot)
        {
            countDown -= Time.deltaTime;
            if (countDown < 0)
            {
                gameObject.GetComponent<IChangeValue>().DamageValue();
                countDown = 3;
            }
        }
    }

    public void Damage()
    {
        healt-=damageValue;

        Debug.Log(healt);
        if (healt < 1 && !_died)
        {
            _soldierObject.size = new Vector3(20, 50, 20);
            transform.parent = null;
            _rb = gameObject.AddComponent<Rigidbody>();
            _rb.AddForce(-transform.forward * addForceValue);
            Invoke(nameof(LateDestroy), 5f);
            _died = true;
        }
    }

    private void LateDestroy()
    {
        Destroy(gameObject);
    }
    
    public void StopRunAnimation()
    {
        anim.SetBool("Shoot", true);
    }
}
