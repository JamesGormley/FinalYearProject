using UnityEngine;
using System.Collections;

public class Bullit : MonoBehaviour {
    //Speed and Range variables. Available in Unity Editor
    public float bullitSpeed;
    public float bullitRange;
    //Distance projectile destroys after, dictated by range variable
    private float maxDistance;


    // Update is called once per frame
    void Update () {

        //  **** Vector3.forward -- Forward or Up depends heavily on orientation of axis when exported from blender 
        transform.Translate(Vector3.forward * Time.deltaTime * bullitSpeed);
        maxDistance += Time.deltaTime * bullitSpeed;
        //Check if bullit is gone past maximum range. Destroy if so
        if(maxDistance>=bullitRange)
        {
            Destroy(gameObject);
        }
	
	}
}
