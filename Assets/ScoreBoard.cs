////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//  Code in this class referenced from 
//  gamedevelopment.tutsplus.com/tutorials/how-to-code-a-self-hosted-phpsql-leaderboard-for-your-game--gamedev-11627
//  (Edited)
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreBoard : MonoBehaviour {


    public Canvas canvas;
    //these gameobjects will hold the prefab we instantiate each user name and highscore into
    public GameObject uNameDisplayBox;
    public GameObject scoreDisplayBox;
    //Object for the players rank and score and name, under scoreboard. Needs to be wider than the others
    public GameObject individDisplayBox;
    //Holders for the text components of the above gameobjects
    private Text userNameText;
    private Text scoreText;
    //This will be the position our first text prefab will be instantiated to
    public Vector3 userNamePos;
    public Vector3 userScorePos;


    //URLS for the online php files used to access database
    //private string displayScoreURL = "http://www.unknowndefence.comli.com/displayOnline.php"; 
    //private string checkRankURL = "http://www.unknowndefence.comli.com/checkRankOnline.php?";

    //URLS for the online php files used to access database
    private string displayScoreURL = "http://localhost/FYP/display.php";
    private string checkRankURL = "http://localhost/FYP/checkRank.php?";


    // Use this for initialization
    void Start () {
        //Coroutines to display the top 5 scores and the users last score
        StartCoroutine("DisplayScores");
        StartCoroutine("CompareUser");
    }
	
	// Update is called once per frame
	void Update () {
	
	}


    //***********************************************************************************************************************
    //  This code referenced from 
    //  gamedevelopment.tutsplus.com/tutorials/how-to-code-a-self-hosted-phpsql-leaderboard-for-your-game--gamedev-11627
    //  (Edited)
    //***********************************************************************************************************************

    IEnumerator DisplayScores()
    {
        WWW getScores = new WWW(displayScoreURL);
        yield return getScores;

        if (getScores.error != null)
        {
            Debug.Log(getScores.error);
        }
        else
        {
            //Gets list of scores and puts them into an array of strings
            string[] textlist = getScores.text.Split(new string[] { "\n", "\t" }, System.StringSplitOptions.RemoveEmptyEntries);
            //Makes new array half the size of the one created above. 
            //FloorToInt make it the size of the largest full integer below the float number and we then divide by 2
            string[] names = new string[Mathf.FloorToInt(textlist.Length / 2)];
            //Makes another array of strings the same size as the one above
            string[] scores = new string[names.Length];
            //We now place the names and scores into their respective arrays
            for (int i = 0; i < textlist.Length; i++)
            {
                if (i % 2 == 0)
                {
                    names[Mathf.FloorToInt(i / 2)] = textlist[i];
                }
                else scores[Mathf.FloorToInt(i / 2)] = textlist[i];

                
            }
            

            //Loop through the array of names
            for (int i = 0; i < names.Length; i++)
            {
                //Instantiate a single UserName Display Box
                GameObject userDisplayObj = (GameObject)Instantiate(uNameDisplayBox, userNamePos, Quaternion.identity);
                //Set the box as a child of the canvas in the scene
                userDisplayObj.transform.SetParent(canvas.transform, false);
                //Access and set the text in that text component
                userNameText = userDisplayObj.GetComponent<Text>();

                //This if statement is needed for correct formatting of display 
                if (i == 0)
                {
                    userNameText.text = "" + (i + 1) + "  " + names[i];
                }
                else
                {
                    userNameText.text = "" + (i + 1) + " " + names[i];
                }
                //This moves the position by 12 on the y axis to place the next username
                userNamePos -= new Vector3(0, 12, 0);
            }

            //Loop through the array of scores. (Same length as array of names)
            for (int i = 0; i < scores.Length; i++)
            {
                //Instantiate a single scoreDisplayObj
                GameObject scoreDisplayObj = (GameObject)Instantiate(scoreDisplayBox, userScorePos, Quaternion.identity);
                //Set the box as a child of the canvas in the scene
                scoreDisplayObj.transform.SetParent(canvas.transform, false);
                //Access and set the text in that text component
                scoreText = scoreDisplayObj.GetComponent<Text>();
                scoreText.text = "" + scores[i];
                //This moves the position by 12 on the y axis to place the next username
                userScorePos -= new Vector3(0, 12, 0);
            }
        }
    }

    //This method pulls the score corresponding to the username given in the last scene
    IEnumerator CompareUser()
    {
        WWW checkScores = new WWW(checkRankURL + "name=" + WWW.EscapeURL(UploadScoreScript.finalUserName));
        yield return checkScores;


        if (checkScores.error != null)
        {
            Debug.Log(checkScores.error);
        }
        else
        {
            string returnedUser = checkScores.text;
            Debug.Log(returnedUser);

            GameObject userScorecoreDisplayObj = (GameObject)Instantiate(individDisplayBox, new Vector3 (-400, 50, 0), Quaternion.identity);
            //Set the box as a child of the canvas in the scene
            userScorecoreDisplayObj.transform.SetParent(canvas.transform, false);
            //Access and set the text in that text component
            scoreText = userScorecoreDisplayObj.GetComponent<Text>();
            scoreText.text = "Rank: " + returnedUser + "points.";
        }
    }


    //***********************************************************************************************************************
    //  End of reference
    //***********************************************************************************************************************


}
