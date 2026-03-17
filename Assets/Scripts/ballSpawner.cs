using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballSpawner : MonoBehaviour
{
    //private field for instance of game object for ball chasing player
    [SerializeField] GameObject ballPrefab; //ball field in inspector
    private GameObject ball;
    //ball will spawn 5 seconds after game has started
    public float spawnTime = 5.0f;
    public float distanceFromPlayer = 5.0f; //spawn 5 units behind player

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnBall());
    }

    public IEnumerator SpawnBall()
    {
        //wait for the specified time so ball can spawn
        yield return new WaitForSeconds(spawnTime);

        //target player
        GameObject player = GameObject.FindWithTag("Player");

        if (player)
        {
            //get player position
            Vector3 spawnLocation = player.transform.position;
            //set distance behind player
            spawnLocation.z -= distanceFromPlayer;
            //set spawn height for ball
            spawnLocation.y = 3f;

            ball = Instantiate(ballPrefab);
            ball.transform.position = spawnLocation;
        }
    }
}
