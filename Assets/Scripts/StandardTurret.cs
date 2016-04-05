using UnityEngine;
using System.Collections;

public class StandardTurret : MonoBehaviour {

    public GameObject projectile;
    public GameObject fireExplosion;
    public Transform barrelPos;
    public Transform sphere;
    public Transform target;
    public float reloadSpeed;
    private float nextShot;

	
	// Update is called once per frame
	void Update () {
	    //Check if a target is present
        if(target)
        {
            //if enough time has passed since the last shot, fire again
            if(Time.time >= nextShot)
            {
                //methods to calculate the position of the target and fire a bullit
                calculateTargetPos(target.position);
                shootBullit();
            }
        }
	}

    //When an enemy enters set as target
    void OnTriggerEnter(Collider other)
    {
        //Check there is no target already, if true, set new target
        if (!target)
        {
            if (other.gameObject.tag == "Enemy")
            {
                //Debug.Log("Enemy in range");
                //Set target for firing at
                target = other.gameObject.transform;
            }
        }
    }

    // This fires if a target enters the collider before another one leaves. Otherwise second target will not be found
    void OnTriggerStay(Collider other)
    {
        if (target == null)
        {
            if (other.gameObject.tag == "Enemy")
            {
                target = other.transform;
            }
        }
    }

    // When target leaves collider, set to null. OnTriggerStay will find targets already in collider.
    void OnTriggerExit(Collider other)
    {
        
        if (other.gameObject.transform == target)
        {
            target = null;
        }
    }

    //Look at target
    void calculateTargetPos (Vector3 target)
    {
        // Rotate to look at target
        sphere.LookAt(target);
    }

    //Fire/Instantiate projectile on vector towards target (after reload time reached)
    void shootBullit()
    {
        //Reload time calculated and waited for before instantiating bullit
        nextShot = Time.time + reloadSpeed;
        GameObject bullit = (GameObject)Instantiate(projectile, barrelPos.position, barrelPos.rotation);
        GameObject explosion = (GameObject)Instantiate(fireExplosion, barrelPos.position, barrelPos.rotation);
        
    }
}
    