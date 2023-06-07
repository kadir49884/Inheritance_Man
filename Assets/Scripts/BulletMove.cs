using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour
{
    [SerializeField]
    private float  _bulletSpeed = 4000;

    private Rigidbody rigidbody;

    MeshRenderer bulletMesh;

    void Start()
    {
        
        Quaternion rotation = Quaternion.Euler(transform.parent.eulerAngles);
        Vector3 direction = rotation * Vector3.forward;
        rigidbody = GetComponent<Rigidbody>();
        rigidbody.AddForce(direction.normalized * _bulletSpeed);
        bulletMesh = GetComponent<MeshRenderer>();
        Invoke(nameof(DestroyMe), 1.1f);

        transform.parent = null;
    }

    private void OnTriggerEnter(Collider other)
    {
        other.gameObject.GetComponent<IChangeValue>()?.ChangeScale();
        other.gameObject.GetComponent<BaseSoldier>()?.Damage();
        DestroyMe();
    }
  
    private void DestroyMe()
    {
        Destroy(gameObject);
    }
    
}
