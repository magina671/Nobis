using UnityEngine.AI;
using UnityEngine;

public class Player2Controller : MonoBehaviour
{
    public Camera cam;

    public NavMeshAgent agent;

    private void Update()
    {
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
