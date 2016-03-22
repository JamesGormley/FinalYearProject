using UnityEngine;
using System.Collections;

public class explosionScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
        StartCoroutine("DestroyExplosion");
	}
	
    //This destroys the explosion after o.4 of a second to remove it from the game
    IEnumerator DestroyExplosion()
    {
        yield return new WaitForSeconds(0.4f);
        Destroy(gameObject);
    }
}
