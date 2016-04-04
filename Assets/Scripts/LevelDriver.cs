using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LevelDriver : MonoBehaviour {

    //Objects to access variables in other scripts
    public GUIScript gScript;
    public EnemyBehaviour eScript; //Not yet required as not yet functional  
    

    public GameObject groundEnemy;

    //Damage applied when powerCore hit
    public int baseDamage = 1;
    //Points and funds for a kill
    public int killPoints = 10;
    public int killFunds; //set this in editor
    public int enemyIncrease; // This is the value the enemies health will increase by each round

    //User variables 
    //Score declared as static for access in other scenes
    public int userHealth = 10;
    static public int score = 0;
    public int funds = 0;

    //Current wavwnumber and total number of waves respectivley
    //Wavenumber declared as static for access in other scenes
    static public int waveNumber = 0;

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
	
    void Start ()
    {
        eScript = GetComponent<EnemyBehaviour>();
    }
	// Update is called once per frame
	void Update () {

        //When the level ends (i.e. user runs out of health, load the next scene
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
        //Method to update display
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

        //While less than numEnemies (the wavesize) we spawn enemies and increase the count of enemies
        //While loop stops on reaching the prerequisite number of enemies.
        //Wait for the spawninterval after each spawn
        while (enemyCounter < numEnemies)
        {
            SpawnEnemy();
            enemyCounter++;
            yield return new WaitForSeconds(spawnInterval);
        }
        //Method to build next wave
        BuildNextWave();
    }

    // Function to build the next wave
    // Resets enemy counter, Increases the number of enemies for the next wave and decreases the spawn interval
    void BuildNextWave()
    {
        enemyCounter = 0;
        numEnemies = numEnemies + 5;
        spawnInterval = ((spawnInterval / 100) * 90);

        // *** Causing null reference exception  ***
        //Increase the health of the enemies each wave
        //eScript.enemyHealth = (eScript.enemyHealth + enemyIncrease);

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
