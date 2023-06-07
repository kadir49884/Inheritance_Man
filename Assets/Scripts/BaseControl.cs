using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BaseControl : MonoBehaviour
{
    [SerializeField]
    protected GameObject opponent;
    [SerializeField]
    protected float objectSpeed;
    [SerializeField]
    protected Rigidbody rb;
    [SerializeField]
    protected GameObject bulletObject;

    [SerializeField]
    protected int healt;
    [SerializeField]
    protected int damage;
    protected GameManager gameManager;


    protected virtual void Start()
    {
        gameManager = GameManager.Instance;
        rb = GetComponent<Rigidbody>();
    }


    protected virtual void Update()
    {

    }

    protected virtual void FixedUpdate()
    {
        if (gameManager.CurrentState == State.Moving)
        {
            rb.velocity = new Vector3(0, 0, objectSpeed * Time.fixedDeltaTime);
        }
    }

    protected void ShootBullet()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            Instantiate(bulletObject, transform.GetChild(i));
        }

    }


    public void StopLine()
    {
        gameManager.CurrentState = State.Shoot;
        rb.velocity = Vector3.zero;
    }
    
    protected virtual void LateShoot()
    {

        ShootBullet();

    }
}
