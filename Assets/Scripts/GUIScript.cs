using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GUIScript : MonoBehaviour {
    
    public bool stdTurretBtnClicked = false;


    // Use this for initialization
    void Start ()
    { 
        //tp = tp.GetComponent<TowerPlatform>();
        //standardTurretBtn = standardTurretBtn.GetComponent<Button>();
    }

    
    //If standard turret button clicked set to true to build turret when platform clicked. After platform clicked, reset to false
    public void stdTurretBuild()
    {
        stdTurretBtnClicked = true;
    }
}
