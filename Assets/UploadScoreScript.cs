using UnityEngine;
using UnityEngine.UI;
using System.Collections;


//This script will deal with taking the players name from an input field and their score from the game and uploading them both to the db
public class UploadScoreScript : MonoBehaviour { 

    //Variable to hold username which will be uploaded with score. Static for access in other scenes
    static public string finalUserName;

    //Holder for the inputfield used to accept the users name
    public InputField nameField;

    //For displaying the wave/round number and score achieved by the user
    public Text roundText;
    public Text scoretext;

    //Button used for submitting user name and initiating the post to the db
    public Button submitBtn;

    //this is the address of the php script used to post to the db
    private string addScoreURL = "http://localhost/FYP/addscore.php?";  //Change this to online url when db hosted online

    // Use this for initialization
    void Start () {
        //Round/wave and score variables taken from level
        roundText.text = "You reached round: " + LevelDriver.waveNumber;
        scoretext.text = "Your score is: " + LevelDriver.score;
    }
	

    //This method invoked when submit button pressed
    public void submitButtonClicked()
    {
        //takes username and starts coroutine to post info to db
        //Loads the gameover scene which displays the rankings and such
        finalUserName = nameField.text;
        StartCoroutine(AddScore(finalUserName, LevelDriver.score));
        Application.LoadLevel("GameOver");
    }

    //Coroutine to post info to db. Takes name and score variables
    IEnumerator AddScore(string name, int score)
    {


        WWW ScorePost = new WWW(addScoreURL + "name=" + WWW.EscapeURL(name) + "&score=" + score);
        yield return ScorePost;

        if (ScorePost.error == null)
        {
            //If post successful
            Debug.Log("Posted");

        }
        else
        {
            //Error message if post fails
            Debug.Log(ScorePost.error);
        }
    }

}
