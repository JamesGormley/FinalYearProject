using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GUIScript : MonoBehaviour {

    public Button standardTurretBtn;
    public bool stdTurretBtnClicked = false;


    // Use this for initialization
    void Start ()
    { 
        //tp = tp.GetComponent<TowerPlatform>();
        //standardTurretBtn = standardTurretBtn.GetComponent<Button>();
    }

    

    public void test()
    {
        stdTurretBtnClicked = true;
        //Debug.Log("Its on in GUi");
    }
}
