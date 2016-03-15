using UnityEngine;
using System.Collections;

public class TowerPlatform : MonoBehaviour {

    public GUIScript gScript;

    public GameObject levelDriver;
    public LevelDriver ld;

    public GameObject turret;
    private GameObject g;



    //Colour to change to on hover over platform
    private Color startcolor;

    void Start()
    {
        //Make new gameobject of type levelscriptholder (empty script holder made in editor)
        //Access script component on that object
        levelDriver = GameObject.Find("LevelScriptHolder");
        ld = levelDriver.GetComponent<LevelDriver>();
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
        //Check if standard turret button has been clicked. This is from the GUIScript
        if (gScript.stdTurretBtnClicked == true)
        {
            //Check no tower in place already and enough funds are present
            if (!g && ld.funds >= ld.sTurretCost)
            {
                // Instantiate tower on clicked platform + 0.2 in y direction for correct height
                g = (GameObject)Instantiate(turret);
                g.transform.position = transform.position + new Vector3(0, 0.2f, 0);

                //Subtract from funds
                ld.funds = ld.funds - ld.sTurretCost;

                //Set standard turret button clicked variable back to false after tower built
                gScript.stdTurretBtnClicked = false;
            }
        }
    }


}
