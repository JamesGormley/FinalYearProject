using UnityEngine;
using UnityEngine.UI; // needed for user interface
using System.Collections;

public class MenuScript : MonoBehaviour {

    public Canvas quitWindow;
    public Canvas optionsWindow;
    public Button defendNowBtn;
    public Button optionsBtn;
    public Button exitBtn;


    // Use this for initialization
    void Start () {

        //Initialise button and canvas variables  
        quitWindow = quitWindow.GetComponent<Canvas>();
        optionsWindow = optionsWindow.GetComponent<Canvas>();
        //Disable quitwindow until exit button pressed
        quitWindow.enabled = false;
        optionsWindow.enabled = false;

        defendNowBtn = defendNowBtn.GetComponent<Button>();
        optionsBtn = optionsBtn.GetComponent<Button>();
        exitBtn = exitBtn.GetComponent<Button>();

	}

	// Begin game method
    public void defendNow()
    {
        Application.LoadLevel(1);
    }

   
    // Open quitWindow and disable unrequired buttons
    public void exitPressed()
    {
        quitWindow.enabled = true;
        optionsWindow.enabled = false;
        defendNowBtn.enabled = false;
        optionsBtn.enabled = false;
        exitBtn.enabled = false;
    }

    //Open options window
    public void optionsPressed()
    {
        optionsWindow.enabled = true;
        quitWindow.enabled = false;
        defendNowBtn.enabled = false;
        optionsBtn.enabled = false;
        exitBtn.enabled = false;
    }
    //When no pressed in quitWindow
    public void noPressed()
    {
        quitWindow.enabled = false;
        optionsWindow.enabled = false;
        defendNowBtn.enabled = true;
        optionsBtn.enabled = true;
        exitBtn.enabled = true;
    }

    //Set music to on when button pressed in options menu
    public void musicOn()
    {

    }
    //Set music to off when button pressed in options menu
    public void musicOff()
    {

    }

    //Close Options Window
    public void closeOptions()
    {
        quitWindow.enabled = false;
        optionsWindow.enabled = false;
        defendNowBtn.enabled = true;
        optionsBtn.enabled = true;
        exitBtn.enabled = true;
    }
}
