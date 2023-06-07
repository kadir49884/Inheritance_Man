using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class AimControl : MonoBehaviour
{

    private float _tempX;

    private Vector3 _firstPos;
    private Vector3 _lastPos;
    private Vector3 _differentPos;
    private bool _checkFirstShoot;

    [SerializeField]
    private Camera camera;

    GameManager gameManager;


    private MeshRenderer crosshair;

    private void Start()
    {
        gameManager = GameManager.Instance;
        crosshair = GetComponent<MeshRenderer>();
    }

    void Update()
    {
        if (gameManager.CurrentState == State.Shoot)
        {
            if (Input.GetMouseButtonDown(0))
            {
                FirstTouchControl();
            }
            else if (Input.GetMouseButton(0))
            {
                if (!_checkFirstShoot)
                {
                    FirstTouchControl();
                    _checkFirstShoot = true;
                }
                OnMouseDown();
            }
            if(!crosshair.enabled)
            {
                crosshair.enabled = true;
            }
        }

    }

    private void FirstTouchControl()
    {
        Vector3 screenToWorld = camera.ScreenToWorldPoint(Input.mousePosition);
        _firstPos = new Vector3(screenToWorld.x, _firstPos.y, _firstPos.z);
        _tempX = transform.position.x;
    }

    private void OnMouseDown()
    {
        Vector3 screenToWorld = camera.ScreenToWorldPoint(Input.mousePosition);
        _lastPos = new Vector3(screenToWorld.x, _lastPos.y , _lastPos.z);

        _differentPos = new Vector3((_tempX + (_lastPos.x - _firstPos.x) * 8),  transform.position.y, transform.position.z);
        _differentPos.x = Mathf.Clamp(_differentPos.x, -10, 10);

        transform.DOMoveX(_differentPos.x, 0.1f);
    }

}
