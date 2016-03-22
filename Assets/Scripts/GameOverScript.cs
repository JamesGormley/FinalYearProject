using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameOverScript : MonoBehaviour {

    public Button returnToTitleBtn;

	// Use this for initialization
	void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    //This method returns the user to the title/main menu scene.
    public void returnToTitle()
    {
        Application.LoadLevel("MainMenu");
    }
}
