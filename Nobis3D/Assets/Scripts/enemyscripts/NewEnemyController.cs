using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class NewEnemyController : MonoBehaviour
{
    public GameObject Player;
    public GameObject Enemy;

    public GameObject losingMenuUI;
    public int checkOfDying = 0;
   

    public GameObject Player2;
    private float rangeplayer1;
    private float rangeplayer2;

    private void Awake()
    {
        losingMenuUI.SetActive(false);
    }

    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        Player2 = GameObject.FindGameObjectWithTag("Player2");
        //rangeplayer1 = Vector3.Distance(transform.position, Player.transform.position);
        //rangeplayer2 = Vector3.Distance(transform.position, Player2.transform.position);

        if (!Player || !Player2)
        {
            Debug.Log("Make sure your player is tagged!!");
        }
    }
    void Update()
    {
        //GetComponent<NavMeshAgent>().destination = Player.transform.position;

        FindClosestPlayer();
        
        if(checkOfDying == 2)
        {
            Lose(); // проигрыш
        }

        //if (rangeplayer1 < rangeplayer2)
        //{
        //    GetComponent<NavMeshAgent>().destination = Player.transform.position;
        //    //transform.position = Vector3.Lerp(transform.position, Player.transform.position, 1f);
        //}
        //else
        //{
        //    GetComponent<NavMeshAgent>().destination = Player2.transform.position;
        //    // transform.position = Vector3.Lerp(transform.position, Player2.transform.position, 1f);
        //}

    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.tag == "Player2")
        {
            Player2.SetActive(false);
            checkOfDying++;
        }
        if (other.tag == "Player")
        {
            Player.SetActive(false);
            checkOfDying++;
        }
    }

    void Lose()
    {
        //Time.timeScale = 0f;         //заморозка времени
        losingMenuUI.SetActive(true); //активация паузы
    }

    

    void FindClosestPlayer()
    {
        float distanceToClosestPlayer = Mathf.Infinity;
        Player closestPlayer = null;
        Player[] allPlayers = GameObject.FindObjectsOfType<Player>();

        foreach (Player currentPlayer in allPlayers)
        {
            float distanceToPlayer = (currentPlayer.transform.position - this.transform.position).sqrMagnitude;
            if (distanceToPlayer < distanceToClosestPlayer)
            {
                distanceToClosestPlayer = distanceToPlayer;
                closestPlayer = currentPlayer;
            }
            Debug.DrawLine(this.transform.position, closestPlayer.transform.position, Color.red);
            GetComponent<NavMeshAgent>().destination = closestPlayer.transform.position;
        }
    }
}
