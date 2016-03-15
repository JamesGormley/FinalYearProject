using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LevelDriver : MonoBehaviour {

    public GameObject groundEnemy;
    //public LevelDriver levelDriver;

    //Global variable for damage to powercore/base
    static float coreDamage = 0;
    public int killPoints = 10;
    public int killFunds = 2;

    //User variables
    public int userHealth = 20;
    public int userScore = 20;

    //Bools to indicate ongoing wave and whether to spawn enemies 
    public bool waveInProgress = false;
    public bool spawnEnemies = false;

    //Variables to be displayed on GUI
    public Text scoreText;
    public Text fundsText;
    public int score = 0;
    public int funds = 0;
    public int sTurretCost = 5;

    public Text waveText;
    private int waveNumber = 0;
    public int numOfWaves = 10;
    // Vars for the time between enemy spawns
    public float spawnInterval = 3;
    private float nextSpawnTime;

    // Vars for number of enemies in a wave and enemies currently in game
    public int numEnemies = 10;
    public int enemyCounter = 0;

    //Location enemies will spawn
    public Vector3 spawnLocation = new Vector3(0f, 0.5f, -10f);
    public int spawnRandomiser = 4;


	// Use this for initialization
	void Start () {

        UpdateGUI();
	
	}
	
	// Update is called once per frame
	void Update () {
        
        //If enough time has passed, spawn an enemy
        if (Time.time >= nextSpawnTime)
        {
            // Check number of enemies has not been reached
            if (enemyCounter < numEnemies)
            {
                SpawnEnemy();
                enemyCounter++;
            }
        }

        UpdateGUI();
        
	
	}

    // Function to spawn enemies -- Random.insideUnitSphere varies the spawn location based on the value in the int variable, spawnRandomiser
    void SpawnEnemy()
    {
        nextSpawnTime += spawnInterval;
        GameObject enemy = (GameObject)Instantiate(groundEnemy, spawnLocation + Random.insideUnitSphere * spawnRandomiser, Quaternion.identity);

    }

    // Function to build the next wave
    void buildNextWave()
    {
        waveNumber++;
        numEnemies = numEnemies + 2;
        spawnInterval = ((spawnInterval / 100) * 95);
    }

    // Updates values on GUI (obviously...)
    void UpdateGUI()
    {
        //
        scoreText.text = "Score          :" + score;
        fundsText.text = "Funds         :" + funds;
        waveText.text = "Wave          :" + waveNumber;
    }

    //Method called whenever standard enemy is destroyed
    public void addScore()
    {
        score = score + killPoints;
        funds = funds + killFunds;
    }

}
