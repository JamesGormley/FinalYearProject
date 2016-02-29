using UnityEngine;
using System.Collections;

public class StandardTurret : MonoBehaviour {

    public GameObject projectile;
    public Transform barrelPos;
    public Transform sphere;
    public float reloadSpeed;
    public float rotationSpeed;
    public float timeToFire;
    public Transform target;
    

    private float nextShot;
    private float nextMove;
    private Quaternion turretRotation;
    private Vector3 aimAt;

	
	// Update is called once per frame
	void Update () {
	    //Check if a target is present
        if(target)
        {
            //Check if the turret has waited the correct time before moving again
            if(Time.time >= nextMove)
            {
                // Get position of target and lerp towards it. Use deltaTime as its always less than one 
                calculateTargetPos(target.position);
                //sphere.rotation = Quaternion.Lerp(sphere.rotation, turretRotation, Time.deltaTime * rotationSpeed);
            }

            if(Time.time >= nextShot)
            {
                shootBullit();
            }
        }
	}



    //When an enemy enters set as target
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            //This delays firing at first target slightly 
            //in order to allow time for aiming. Then sets target
            //timeToFire = Time.time + (reloadSpeed * 0.4f);
            target = other.gameObject.transform;
        }
    }

    void onTriggerExit (Collider other)
    {
        if (other.gameObject.transform == target)
        {
            target = null;
        }
    }

    void calculateTargetPos (Vector3 target)
    {
        // Rotate to look at target
        //aimAt = new Vector3(target.x, target.y, target.z);
        //turretRotation = Quaternion.LookRotation(target);
        sphere.LookAt(target);
    }

    void shootBullit()
    {
        nextShot = Time.time + reloadSpeed;
        //nextMove = Time.time + timeToFire;

       
        GameObject bullit = (GameObject)Instantiate(projectile, barrelPos.position, barrelPos.rotation);
        
    }
}
    