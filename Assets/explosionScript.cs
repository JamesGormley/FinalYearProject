using UnityEngine;
using System.Collections;

public class explosionScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
        StartCoroutine("DestroyExplosion");
	}
	
    IEnumerator DestroyExplosion()
    {
        yield return new WaitForSeconds(0.4f);
        Destroy(gameObject);
    }
}
