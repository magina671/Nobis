using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public Camera cam;
    public NavMeshAgent agent;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition); //Возвращает луч, идущий от камеры через точку на экране.
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit)) // если ударился
            {
                //move our agent
                agent.SetDestination(hit.point); // устанавливает кратчайшее расстояние до точки удара
            }
        }

    }
}
