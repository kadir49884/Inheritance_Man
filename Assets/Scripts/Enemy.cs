using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : BaseControl
{
    [SerializeField]
    protected float shootTime = 3f;
    Vector3 _targetPostition;
    Vector3 _childPos;
    private float _newPosZ;
    private float _aimHelperZ = 28f;
    private float _countDown = 1;
    private int _randomNumber;

    protected override void Start()
    {
        base.Start();
        _childPos = opponent.transform.GetChild(0).transform.position;
        _newPosZ = _childPos.z + _aimHelperZ;
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
    }

    protected override void Update()
    {
        if (gameManager.CurrentState == State.Shoot)
        {
            _countDown -= Time.deltaTime;
            if (_countDown < 0)
            {
                RandomSelect();
                _countDown = 2;
            }
        }
    }

    private void RandomSelect()
    {
        if (opponent.transform.childCount < 1 || transform.childCount <1 )
        {
            gameManager.CurrentState = State.Finish;
            Invoke(nameof(LateLevelLoad), 3f);
        }
        else
        {
            _randomNumber = Random.Range(0, opponent.transform.childCount - 1);
            _childPos = opponent.transform.GetChild(_randomNumber).transform.position;
            _targetPostition = new Vector3(_childPos.x, transform.position.y, _newPosZ);

            for (int i = 0; i < transform.childCount; i++)
            {
                transform.GetChild(i).LookAt(_targetPostition);
            }


            Invoke(nameof(LateShoot), 0.5f);
        }

    }

    protected override void LateShoot()
    {
        base.LateShoot();
    }

    private void LateLevelLoad()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
