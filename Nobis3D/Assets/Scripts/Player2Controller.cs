﻿using UnityEngine.AI;
using UnityEngine;
using UnityEngine.Networking;

public class Player2Controller : NetworkBehaviour
{
    public Camera cam;

    public NavMeshAgent agent;

    private void Update()
    {
        //if (!isLocalPlayer)
        //    return;

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition); //луч в место нажатия мышки
            RaycastHit hit;

            if (Physics.Raycast(ray,out hit))   // если в точке нажатия есть обьект
            {
                agent.SetDestination(hit.point);    //определение кратчайшего пути
            }
        }
    }
}
