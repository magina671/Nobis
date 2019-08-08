using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeMove : MonoBehaviour
{
    float dirX, dirZ, movespeed = 5;

    private void Update()
    {
        dirX = Input.GetAxis("Horizontal") * movespeed * Time.deltaTime;
        dirZ = Input.GetAxis("Vertical") * movespeed * Time.deltaTime;

        transform.position = new Vector3(transform.position.x + dirX, 0 , transform.position.z + dirZ);
    }
}
