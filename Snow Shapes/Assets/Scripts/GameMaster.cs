using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameMaster : MonoBehaviour
{
    //This script is used for the GameMaster GameObject, which controls all of the major functions in the game.

    //REFERENCES//

    //CANVAS REFERENCES//

        //Reference to the Next Level Button, which appears when a level is completed 
        private GameObject nextLevelBut; 

        //Reference to the Level Complete! text that displays when a level is completed
        private TextMeshProUGUI levelCompleteText; 

        //Reference to the Progress Bar which is on top of the screen 
        private Slider progressBar;

    //VARIABLES//

        //The current level which the player is on, set in the inspector.
        public int curLevel; 

        //The number of Snow Balls which the player has collected currently 
        public int curSnowBallsCollected;

        //The total amount of Snow Balls which the player has to collect to complete a level
        public int totalSnowBalls; 

    // Start is called before the first frame update
    void Start()
    {
        levelCompleteText = GameObject.Find("LevelCompleteText").GetComponent<TextMeshProUGUI>();
        levelCompleteText.text = "";
        nextLevelBut = GameObject.Find("NextLevelButton");
        nextLevelBut.SetActive(false);
        progressBar = GameObject.Find("ProgressBar").GetComponent<Slider>();
        progressBar.maxValue = totalSnowBalls;
        curSnowBallsCollected = 0;
    }

    // Update is called once per frame
    void Update()
    {
        /*
         * If the player has collected all of the Snow Balls in a level,
         * Call the SnowShapeComplete() method to end the level. 
        */
        if(curSnowBallsCollected >= totalSnowBalls)
        {
            SnowShapeComplete(); 
        }
    }

    //TO-DO 
    //This method gets called whenever a player collects a Snow Ball. 
    //Increase the Counter by 1
    //And enable the Outlined Portion of that particular Snow Ball GameObject.
    public void IncreaseSnowBallCounter()
    {
        Debug.Log("Plow has collided with a Snow Ball");
        curSnowBallsCollected++;
        progressBar.value += 1;

    }

    /*
     *Transform the Snow Shape Outline into the Snow Shape (3D Model),
     *Indicate to the player that the level is complete,
     *And enable the button to allow for the next level to be entered.  
     *
     * TO-DO:
     * ADD A PANEL WHICH DIMS THE SCREEN AND REVEALS THE MODEL THAT THE PLAYER MADE.
    */
    void SnowShapeComplete()
    {
        Debug.Log("All Snow Balls collected. Level Complete!");
        levelCompleteText.text = "Level " + curLevel + " Complete!";
        nextLevelBut.SetActive(true);
    }
}
