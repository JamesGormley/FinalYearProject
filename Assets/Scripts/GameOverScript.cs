using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameOverScript : MonoBehaviour {

    public Button returnToTitleBtn;
    public Button exitGameBtn;

    //This method returns the user to the title/main menu scene.
    public void returnToTitle()
    {
        Application.LoadLevel("MainMenu");
    }

    //This method closes the application
    public void exitGame()
    {
        Application.Quit();
    }
}
