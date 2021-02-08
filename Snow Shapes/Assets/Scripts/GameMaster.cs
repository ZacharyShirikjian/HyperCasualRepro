﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class GameMaster : MonoBehaviour
{
    //This script is used for the GameMaster GameObject, which controls all of the major functions in the game.

    //REFERENCES//

        //GAME REFERENCES//

        //Reference to the Player's Snow Plow GameObject
        private GameObject snowPlow;

        //Reference to the outline of the Snow Shape for the level which the player is on 
        public GameObject snowShapeOutline; 

        //Reference to the 3D model of the Snow Shape for the level which the player is on 
        public GameObject snowShape;
    
         //CANVAS REFERENCES//

        //Reference to the Next Level Button, which appears when a level is completed 
        private GameObject nextLevelBut; 

        //Reference to the Level Complete! text that displays when a level is completed
        private TextMeshProUGUI levelCompleteText; 

        //Reference to the Progress Bar which is on top of the screen 
        private Slider progressBar;

        //Reference to the "Drag To Start" UI @ the beginning of the game 
        public TextMeshProUGUI dragToStartText;

    //VARIABLES//

        //Checks to see if the player has begun moving or not (drag to start 
        //The current level which the player is on, set in the inspector.
        public int curLevel; 

        //The number of Snow Balls which the player has collected currently 
        public int curSnowBallsCollected;

        //The total amount of Snow Balls which the player has to collect to complete a level
        public int totalSnowBalls;

        //Checks to see if a level is complete. If the level is complete, the player can't move. 
        public bool levelComplete; 

    // Start is called before the first frame update
    void Start()
    {
        snowPlow = GameObject.Find("SnowPlow");
        snowShapeOutline.SetActive(true);
        snowShape.SetActive(false);
        //dragToStartText = GameObject.Find("DragToStartText").GetComponent<TextMeshProUGUI>();
        dragToStartText.SetText("DRAG TO START");
        levelCompleteText = GameObject.Find("LevelCompleteText").GetComponent<TextMeshProUGUI>();
        levelCompleteText.text = "";
        nextLevelBut = GameObject.Find("NextLevelButton");
        nextLevelBut.SetActive(false);
        progressBar = GameObject.Find("ProgressBar").GetComponent<Slider>();
        progressBar.maxValue = totalSnowBalls;
        curSnowBallsCollected = 0;
        levelComplete = false;
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
     *Freeze the Snow Plow's movement to prevent the player from being able to move on it anymore (maybe replace with set active = false?)
     *
     * TO-DO:
     * ADD A PANEL WHICH DIMS THE SCREEN AND REVEALS THE MODEL THAT THE PLAYER MADE.
    */
    void SnowShapeComplete()
    {
        Debug.Log("All Snow Balls collected. Level Complete!");
        snowShapeOutline.SetActive(false);
        snowShape.SetActive(true);
        levelComplete = true;
        levelCompleteText.text = "Level " + curLevel + " Complete!";
        nextLevelBut.SetActive(true);

    }
}
