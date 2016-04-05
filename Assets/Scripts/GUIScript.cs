using UnityEngine;
using UnityEngine.UI;
using System.Collections;

//This script is used to act in response to clicks on gui buttons. It changes bools which effect other scripts.
//And open/close otions/quit window
public class GUIScript : MonoBehaviour {


    public bool stdTurretBtnClicked = false;
    public bool sendNextWaveBtnClicked = false;
    public bool pauseBtnClicked = false;


    
    //If standard turret button clicked set to true to build turret when platform clicked. After platform clicked, reset to false
    public void stdTurretBuild()
    {
        stdTurretBtnClicked = true;
    }

    public void sendNextWave()
    {
        sendNextWaveBtnClicked = true;
    }
    //This method effectively pauses the game by setting the timescale to 0 if pauseBtnClicked is false. It then sets it to true
    //if pauseBtnClicked is true, it unpauses the game and sets it to false
    public void pauseGame()
    {
        if (pauseBtnClicked == false)
        {
            Time.timeScale = 0.0f;
            pauseBtnClicked = true;
        }
  
        else if (pauseBtnClicked == true)
        {
            Time.timeScale = 1.0f;
            pauseBtnClicked = false;
        }
    }

}
