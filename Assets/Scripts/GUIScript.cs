using UnityEngine;
using UnityEngine.UI;
using System.Collections;

//This script is used to act in response to clicks on gui buttons. It changes bools which effect other scripts.
//And open/close otions/quit window
public class GUIScript : MonoBehaviour {


    public bool stdTurretBtnClicked = false;
    public bool sendNextWaveBtnClicked = false;
    public bool pauseBtnClicked = false;


    // Use this for initialization
    void Start ()
    {

    }

    
    //If standard turret button clicked set to true to build turret when platform clicked. After platform clicked, reset to false
    public void stdTurretBuild()
    {
        stdTurretBtnClicked = true;
    }

    public void sendNextWave()
    {
        sendNextWaveBtnClicked = true;
    }

    public void pauseGame()
    {
        pauseBtnClicked = true;
        //Time.timeScale = 0.0f;
    }
}
