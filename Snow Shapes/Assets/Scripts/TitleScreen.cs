using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//The documentation for the build index was used as a reference for figuring out how to get the specific build index of a scene:
//https://docs.unity3d.com/ScriptReference/SceneManagement.Scene-buildIndex.html

public class TitleScreen : MonoBehaviour
{
    //This script is used for the buttons on the Title Screen, and during gameplay. 

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /*
     * This method gets called when the player taps on the "Start" button on the main menu. 
     * Load the first scene of the game and begin gameplay.
     */
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    /*
     * This method gets called when the player taps on the "NextLevel" button whenever they complete a level.
     * Load the next scene in the build index.
     */
    public void LoadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }


}
