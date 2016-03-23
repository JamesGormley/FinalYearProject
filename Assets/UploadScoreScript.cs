using UnityEngine;
using UnityEngine.UI;
using System.Collections;


//This script will deal with taking the players name from an input field and their score from the game and uploading them both to the db
public class UploadScoreScript : MonoBehaviour {
    
    //Maximum allowed length of name. 16 is the value of the varchar in the db
    private int maxNameLength = 16;

    //Variable to hold username which will be uploaded with score. Begins empty
    private string userName = string.Empty;

    private int userScore;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
