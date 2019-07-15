using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollowPLayer : MonoBehaviour
{
    public Transform target;
    public Transform mytransform;
    private float movementSpeed = 11.0f;

    private void Update()
    {
        transform.LookAt(target.transform);
        transform.position += transform.forward * movementSpeed * Time.deltaTime;
    }
}
