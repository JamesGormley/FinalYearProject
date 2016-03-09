using UnityEngine;
using System.Collections;

public class TowerPlatform : MonoBehaviour {

    public GUIScript gScript;
    public GameObject turret;
    private GameObject g;
    private Color startcolor;


    void Start()
    {
        //tp = tp.GetComponent<TowerPlatform>();

        gScript = gScript.GetComponent<GUIScript>();
        
    }

    void Update()
    {
        if (gScript.stdTurretBtnClicked == false)
        {
            Debug.Log("Its false dummy");
        }
        if (gScript.stdTurretBtnClicked == true)
        {
            Debug.Log("Its true dummy");
        }
    }




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
        if (gScript.stdTurretBtnClicked == true)
        {
            //Check no tower in place already
            if (!g)
            {
                // Instantiate tower on clicked platform + 0.2 in y direction for correct height
                g = (GameObject)Instantiate(turret);
                g.transform.position = transform.position + new Vector3(0, 0.2f, 0);

                //Set standard turret button clicked variable back to false after tower built
                gScript.stdTurretBtnClicked = false;
            }
        }
    }


}
