using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LevelDriver : MonoBehaviour {

    public GUIScript gScript;

    public GameObject groundEnemy;

    //Damage applied when powerCore hit
    public int baseDamage = 1;
    //Points and funds for a kill
    public int killPoints = 10;
    public int killFunds = 2;

    //User variables 
    //Score declared as static for access in other scenes
    public int userHealth = 10;
    static public int score = 0;
    public int funds = 0;

    //Current wavwnumber and total number of waves respectivley
    //Wavenumber declared as static for access in other scenes
    static public int waveNumber = 0;
    public int numOfWaves = 10;

    //Price for a standard turret
    public int sTurretCost = 50;

    //Bools to indicate ongoing wave and whether to spawn enemies 
    public bool waveInProgress = false;
    public bool spawnEnemies = false;

    //Variables to be displayed on GUI
    public Text scoreText;
    public Text fundsText;
    public Text healthText;
    public Text waveText;
    
    

    // Var for the time between enemy spawns
    public float spawnInterval;

    // Vars for number of enemies in a wave and enemies currently in game
    public int numEnemies = 10;
    public int enemyCounter = 0;

    //Location enemies will spawn
    public Vector3 spawnLocation = new Vector3(0f, 0.5f, -10f);
    //Spawn randomiser varies the exact location enemies spawn. 4 works well
    public int spawnRandomiser = 4;


	// Use this for initialization
	void Start () {

        //UpdateGUI();
	}
	
	// Update is called once per frame
	void Update () {

        if (userHealth == 0)
        {
            Application.LoadLevel("UploadScore");
        }

        //Start wave coroutine when button clicked is true and set button back to false
        if (gScript.sendNextWaveBtnClicked == true)
        {
            StartCoroutine("SpawnWave");
            gScript.sendNextWaveBtnClicked = false;
        }
        UpdateGUI();
        
	}

    // Function to spawn enemies -- Random.insideUnitSphere varies the spawn location based on the value in the int variable, spawnRandomiser
    void SpawnEnemy()
    {
        //nextSpawnTime  += spawnInterval;
        GameObject enemy = (GameObject)Instantiate(groundEnemy, spawnLocation + Random.insideUnitSphere * spawnRandomiser, Quaternion.identity);

    }

    //Coroutine to spawn wave, function to cpu intensive to have in Update()
    IEnumerator SpawnWave()
    {
        //Increment wavenumber for display
        waveNumber++;

        //While less than nemEnemies (the wavesize) we spawn enemies and increase the count of enemies
        //While loop stops on reaching the prerequisite number of enemies.
        while (enemyCounter < numEnemies)
        {
            SpawnEnemy();
            enemyCounter++;
            yield return new WaitForSeconds(spawnInterval);
        }

        BuildNextWave();
    }

    // Function to build the next wave
    // Resets enemy counter, Increases the number of enemies for the next wave and decreases the spawn interval
    void BuildNextWave()
    {
        enemyCounter = 0;
        numEnemies = numEnemies + 2;
        spawnInterval = ((spawnInterval / 100) * 95);
    }

    // Updates values on GUI (obviously...)
    void UpdateGUI()
    {
        //
        scoreText.text = "Score          :" + score;
        fundsText.text = "Funds         :" + funds;
        waveText.text = "Wave           :" + waveNumber;
        healthText.text = "Health         :" + userHealth;
    }

    //Method called whenever standard enemy is destroyed
    public void addScore()
    {
        score = score + killPoints;
        funds = funds + killFunds;
    }

    //Method called when enemy crashes into basee
    public void powerCoreDamage()
    {
        userHealth = userHealth - baseDamage;
    }

}
