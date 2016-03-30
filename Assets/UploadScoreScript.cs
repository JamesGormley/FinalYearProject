using UnityEngine;
using UnityEngine.UI;
using System.Collections;


//This script will deal with taking the players name from an input field and their score from the game and uploading them both to the db
public class UploadScoreScript : MonoBehaviour { 

    //Variable to hold username which will be uploaded with score. Static for access in other scenes
    static public string userName;

    public InputField nameField;

    public Text roundText;
    public Text scoretext;

    public Button submitBtn;


    // Use this for initialization
    void Start () {
        
        roundText.text = "You reached round: " + LevelDriver.waveNumber;
        scoretext.text = "Your score is: " + LevelDriver.score;
    }
	
	// Update is called once per frame
	void Update () {

        
        Debug.Log(userName + userScore.ToString());
    }

    public void submitButtonClicked()
    {
        userName = nameField.text;
    }
}
