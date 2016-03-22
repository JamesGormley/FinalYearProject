////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//  This code referenced from
//  gamedevelopment.tutsplus.com/tutorials/how-to-code-a-self-hosted-phpsql-leaderboard-for-your-game--gamedev-11627
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreBoard : MonoBehaviour {

    public GameObject scoreDisplayBox;
    public Text scoreBoard;

    private string privateKey = "superSecretKey";
    private string addScoreURL = "http://localhost/FYP/addscore.php";  //Change this to online url when db hosted online
    private string displayScoreURL = "http://localhost/FYP/display.php"; // as above
    private int highScore;
    private string userName;
    private int rank;


    // Use this for initialization
    void Start () {

        StartCoroutine("DisplayScores");
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    IEnumerator DisplayScores()
    {
        WWW GetScores = new WWW(displayScoreURL);
        yield return GetScores;

        if (GetScores.error != null)
        {
            Debug.Log(GetScores.error);
        }
        else
        {
            //Gets list of scores and puts them into an array of strings
            string[] textlist = GetScores.text.Split(new string[] { "\n", "\t" }, System.StringSplitOptions.RemoveEmptyEntries);
            //Makes new array half the size of the one created above. 
            //FloorToInt make it the size of the largest full integer below the float number and we then divide by 2
            string[] Names = new string[Mathf.FloorToInt(textlist.Length / 2)];
            //Makes another array of strings the same size as the one above
            string[] Scores = new string[Names.Length];
            //We now place the names and scores into their respective arrays
            for (int i = 0; i < textlist.Length; i++)
            {
                if (i % 2 == 0)
                {
                    Names[Mathf.FloorToInt(i / 2)] = textlist[i];
                }
                else Scores[Mathf.FloorToInt(i / 2)] = textlist[i];

                
            }
            
            scoreBoard.text = "UserName :" + Names[1] + "    Score :" + Scores[1];
            
        }
    }
}
