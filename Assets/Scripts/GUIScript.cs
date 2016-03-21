using UnityEngine;
using UnityEngine.UI;
using System.Collections;

//This script is used to act in response to clicks on gui buttons. It changes bools which effect other scripts.
//And open/close otions/quit window
public class GUIScript : MonoBehaviour {
    
    //Holder for pause menu window
    public Canvas pauseWindow;
    public Button pauseBtn;

    public bool stdTurretBtnClicked = false;
    public bool sendNextWaveBtnClicked = false;
    public bool pauseBtnClicked = false;


    // Use this for initialization
    void Start ()
    {
        //initialise pause menu window
        pauseWindow = pauseWindow.GetComponent<Canvas>();
        //Set enabled to false so it doesn's always show
        pauseWindow.enabled = false;

        pauseBtn = pauseBtn.GetComponent<Button>();
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
        pauseWindow.enabled = true;
        Time.timeScale = 0.0f;
    }
}
