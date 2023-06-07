using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    [SerializeField]
    private Transform objectToFollow;

    [SerializeField]
    private Vector3 offSet;

    private Vector3 pos;
    private Vector3 posFollow;

   

    private void FixedUpdate()
    {
        pos = transform.position;
        posFollow = objectToFollow.position;
        transform.position = Vector3.Lerp(transform.position,  new Vector3(pos.x, pos.y, posFollow.z + offSet.z), 0.5f);
    }

 
}
