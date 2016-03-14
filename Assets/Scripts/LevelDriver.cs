using UnityEngine;
using System.Collections;

public class LevelDriver : MonoBehaviour {

    public GameObject groundEnemy;

    public Vector3 spawnLocation = new Vector3(2.5f, 0.5f, -12f);

    public float spawnInterval = 1;
    public float nextSpawnTime;
    public int numEnemies = 10;
    private int i = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        
        //If enough time has passed, spawn an enemy
        if (Time.time >= nextSpawnTime)
        {
            // Check number of enemies has not been reached
            if (i < numEnemies)
            {
                SpawnEnemy();
                i++;
            }
        }
        
	
	}

    // Function to spawn enemies
    void SpawnEnemy()
    {
        nextSpawnTime += spawnInterval;
        GameObject enemy = (GameObject)Instantiate(groundEnemy, spawnLocation, Quaternion.identity);
    }
}
