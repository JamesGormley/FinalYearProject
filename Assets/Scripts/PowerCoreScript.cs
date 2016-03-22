using UnityEngine;
using System.Collections;

public class PowerCoreScript : MonoBehaviour {


    public LevelDriver ld;
    public GameObject killExplosion;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame  
	void Update () {
	
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            GameObject explosion = (GameObject)Instantiate(killExplosion, transform.position, transform.rotation);
            Destroy(other.gameObject);
            ld.powerCoreDamage();
        }
    }
}
