using UnityEngine;
using System.Collections;

public class EnemyBehaviour : MonoBehaviour {

	// Use this for initialization
	void Start () {
        //Check for enemy objective in scene. Enemy objective must be tagged as such in editor
        GameObject eObj = GameObject.Find("PowerCore");
        //If objective present, move towards
        if(eObj)
            GetComponent<NavMeshAgent>().destination = eObj.transform.position;
        
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
