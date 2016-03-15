using UnityEngine;
using System.Collections;

public class EnemyBehaviour : MonoBehaviour {

    public GameObject levelDriver;
    public LevelDriver ld;

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
	

    //Destroy enemy when hit for testing purposes
    //Minus hit from health value later
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Bullit")
        {
            enemyHealth = enemyHealth - damageValue;
            if (enemyHealth <= 0)
            {
                Destroy(gameObject);
            }
            Destroy(other.gameObject);
            ld.addScore();
        }
    }
}
