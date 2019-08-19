using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class NewEnemyControllerSingle : MonoBehaviour
{
    public GameObject Player;
    public GameObject Enemy;

    public GameObject losingMenuUI;
    public int checkOfDying = 0;

    private float rangeplayer1;

    private void Awake()
    {
        losingMenuUI.SetActive(false);
    }

    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");

        if (!Player)
        {
            Debug.Log("Make sure your player is tagged!!");
        }
    }
    void Update()
    {
        FindClosestPlayer();
        
        if(checkOfDying == 1)
        {
            Lose(); 
        }
    }

    private void OnTriggerEnter(Collider other)
    {
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
