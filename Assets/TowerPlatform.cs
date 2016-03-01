using UnityEngine;
using System.Collections;

public class TowerPlatform : MonoBehaviour {


    public GameObject turret;
    private Color startcolor;

    //Change colour of platform when mouse hovers over it
    void OnMouseEnter()
    {
        startcolor = GetComponent<Renderer>().material.color;
        GetComponent<Renderer>().material.color = Color.cyan;
    }

    //Revert to original colour when mouse leaves object
    void OnMouseExit()
    {
        GetComponent<Renderer>().material.color = startcolor;
    }

    //Instantiate tower when platform clicked. 
    void OnMouseUpAsButton()
    {
        // Instantiate tower on clicked platform + 0.2 in y direction for correct height
        GameObject g = (GameObject)Instantiate(turret);
        g.transform.position = transform.position + new Vector3(0, 0.2f, 0);
    }


}
