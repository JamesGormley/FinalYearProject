using UnityEngine;
using System.Collections;

public class EnemyBehaviour : MonoBehaviour {

    //Objects needed to access methods from LevelDriver class
    public GameObject levelDriver;
    public LevelDriver ld;
    //Holder for explosion prefab
    public GameObject killExplosion;

    public int enemyHealth = 10;
    public int damageValue = 5;

	// Use this for initialization
	void Start () {

        //Trying to access method from LevelDriver Class, but can't drag object to prefab in editor
        //Make new gameobject of type levelscriptholder (empty script holder made in editor)
        //Access script component on that object
        levelDriver = GameObject.Find("LevelScriptHolder");
        ld = levelDriver.GetComponent<LevelDriver>();
        
        //Check for enemy objective in scene. PowerCore is the objective, tagged EnemyObjective
        GameObject eObj = GameObject.FindGameObjectWithTag("EnemyObjective");

        //If objective present, move towards
        if(eObj)
            GetComponent<NavMeshAgent>().destination = eObj.transform.position;
	}

    //Minus hit from health value later
    void OnTriggerEnter(Collider other)
    {
        //Check the other object is a bullit
        if (other.tag == "Bullit")
        {
            //subtract damage value from health
            enemyHealth = enemyHealth - damageValue;
            if (enemyHealth <= 0)
            {
                //Destroy enemy prefab when health is less than zero and instantiate an explosion prefab
                Destroy(gameObject);
                GameObject explosion = (GameObject)Instantiate(killExplosion, transform.position, transform.rotation);
            }
            //Destroy the projectile that hit the enemy
            Destroy(other.gameObject);
            //Add points for the kill using method in LevelDriver
            ld.addScore();
        }
    }
}
