using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameMaster : MonoBehaviour
{
    //This script is used for the GameMaster GameObject, which controls all of the major functions in the game.

    //REFERENCES//

        //AUDIO CLIPS//

        private AudioClip snowBallCollect;
        private AudioClip allSnowBallsCollected;
        private AudioClip levelCompleted;
        private AudioClip buttonClick;

        //GAME REFERENCES//

        //Reference to the Player's Snow Plow GameObject
        private GameObject snowPlow;

            //Reference to the outline of the Snow Shape for the level which the player is on 
            public GameObject snowShapeOutline; 

            //Reference to the 3D model of the Snow Shape for the level which the player is on 
            public GameObject snowShape;

            //Reference to the SFXManager script 
            private SFXManager sfxManager;

            //Reference to the SFXManager's AudioSource component
            private AudioSource sfxSource;

        //CANVAS REFERENCES//

            //Reference to the LevelComplete Panel, which gets set to active once a level is completed.
            //private GameObject levelCompletePanel;

            //Reference to the text indicating to the player the current level which they are on.
            private TextMeshProUGUI curLevelText; 
        
            ////Reference to the Next Level Button, which appears when a level is completed 
            private GameObject nextLevelBut; 

            ////Reference to the Level Complete! text that displays when a level is completed
            private TextMeshProUGUI levelCompleteText;

            //Reference to the Progress Bar which is on top of the screen 
            public float currentProgressBarValue; //the % of the ProgressBar which is filled 
            private Image progressBar; //the outline of the Progress Bar
            private Image progressBarFill; //the inside of the Progress Bar

            //private Slider progressBar;

            //Reference to the "Drag To Start" UI @ the beginning of the game 
            public TextMeshProUGUI dragToStartText;

            //Reference to a GameObject with the PauseMenu elements (Retry, Vibration On/Off, Exit) 
            public GameObject pauseMenu; 

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

            //Checks to see if the game is paused or not. 
            public bool isPaused = false;

            //Checks to see if vibration is turned on or not.
            public bool vibration = true; 

    // Start is called before the first frame update
    void Start()
    {
        pauseMenu.SetActive(false);

        sfxManager = GameObject.Find("SFXManager").GetComponent<SFXManager>();
        sfxSource = GameObject.Find("SFXManager").GetComponent<AudioSource>();
        snowBallCollect = sfxManager.snowBallCollect;
        allSnowBallsCollected = sfxManager.allSnowBallsCollected;
        levelCompleted = sfxManager.levelComplete;
        buttonClick = sfxManager.buttonClickSFX;

        snowPlow = GameObject.Find("SnowPlow");
        snowShapeOutline.SetActive(true);
        snowShape.SetActive(false);
        //dragToStartText = GameObject.Find("DragToStartText").GetComponent<TextMeshProUGUI>();
        dragToStartText.SetText("DRAG TO START");
        curLevelText = GameObject.Find("CurLevelText").GetComponent<TextMeshProUGUI>();
        curLevelText.SetText("Level " + curLevel);
        levelCompleteText = GameObject.Find("LevelCompleteText").GetComponent<TextMeshProUGUI>();
        levelCompleteText.text = "";
        nextLevelBut = GameObject.Find("NextLevelButton");
        nextLevelBut.SetActive(false);

        //levelCompletePanel = GameObject.Find("LevelCompletePanel");
        //levelCompletePanel.SetActive(false);
        //progressBar = GameObject.Find("ProgressBar").GetComponent<Slider>();
        //progressBar.maxValue = totalSnowBalls;
        progressBar = GameObject.Find("ProgressBar").GetComponent<Image>();
        progressBarFill = GameObject.FindWithTag("ProgressBarFill").GetComponent<Image>();
        currentProgressBarValue = 0;

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
        //if(curSnowBallsCollected >= totalSnowBalls)
        //{
        //    SnowShapeComplete(); 
        //}
        progressBarFill.fillAmount = (float)curSnowBallsCollected / (float)totalSnowBalls;
        currentProgressBarValue = progressBar.fillAmount;
    }

    //TO-DO 
    //This method gets called whenever a player collects a Snow Ball. 
    //Increase the Counter by 1
    //And enable the Outlined Portion of that particular Snow Ball GameObject.
    public void IncreaseSnowBallCounter()
    {
        Debug.Log("Plow has collided with a Snow Ball");
        sfxSource.PlayOneShot(snowBallCollect);
        curSnowBallsCollected++;
        //progressBar.value += 1;

        //This makes sure the currentProgressBarValue always stays at 1.
        if(currentProgressBarValue > 1)
        {
            currentProgressBarValue = 1;
        }

        //If the Progress Bar has not reached its maximum,
        //Get the percentage of the maximum filled amount (what % out of 100, represented as a decimal #)
        //By dividing the current Snow Balls the player has collected by the total amount of Snow Balls in the level 
        //Set the current Value of the Progress Bar integer to the current fill amount of the Progress Bar 
        else if(currentProgressBarValue < (float) 1)
        {
            progressBarFill.fillAmount = (float) curSnowBallsCollected / (float) totalSnowBalls;
            currentProgressBarValue = progressBar.fillAmount;
        }

        //Vibrate the phone after collecting a Snow Ball, if vibration is set to being on.
        if (vibration == true)
        {
            Debug.Log("Vibrate Phone");
            Handheld.Vibrate(); 
        }

        else if(vibration == false)
        {
            Debug.Log("DO NOT VIBRATE");
        }

        if (curSnowBallsCollected >= totalSnowBalls)
        {
            //sfxSource.PlayOneShot(allSnowBallsCollected);
            SnowShapeComplete();
        }

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

        //Hide the player to make the Snow Shape more visible 
        snowPlow.SetActive(false);

        snowShape.SetActive(true);
        levelComplete = true;
        sfxSource.PlayOneShot(levelCompleted);

        //levelCompletePanel.SetActive(true);

        levelCompleteText.text = "Level " + curLevel + " Complete!";
        nextLevelBut.SetActive(true);

    }

    /*
     *This method gets called when the player taps the Pause button on the top-left corner of the screen.
     *Here, the player can restart the level, turn vibration on/off, or exit the pause menu. 
     */
    public void PauseGame()
    {
        if(isPaused == true)
        {
            sfxSource.PlayOneShot(buttonClick);
            Time.timeScale = 1f;
            isPaused = false;
            pauseMenu.SetActive(false);
        }

        else if(isPaused == false)
        {
            sfxSource.PlayOneShot(buttonClick);
            isPaused = true;
            Time.timeScale = 0f;
            pauseMenu.SetActive(true);
        }

    }

    /*
     * 
     *This method gets called when the player taps the Retry button on the top-left corner of the screen.
     *Re-load the screen the player is currently on and restart the level. 
     */
    public void RestartLevel()
    {
        sfxSource.PlayOneShot(buttonClick);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    /*
     *This method gets called when the player taps on the vibration toggle button on screen.
     *The toggle turns vibration on/off during gameplay.
     */
     public void ToggleVibration()
     {
        //If vibration is off, turn it on
        if (vibration == false)
        {
            sfxSource.PlayOneShot(buttonClick);
            vibration = true;
        }

        //If vibration is on, turn it off
        else if(vibration == true)
        {
            sfxSource.PlayOneShot(buttonClick);
            vibration = false;
        }
     }


    /*
     *This method gets called when the player taps on the audio toggle button on screen.
     *The toggle turns audio on/off during gameplay.
     */
    public void ToggleSound()
    {
        //If audio is off, turn it on 
        
        //If audio is on, turn it off 
    }
}
