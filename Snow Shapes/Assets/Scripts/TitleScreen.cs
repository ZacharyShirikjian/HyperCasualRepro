using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleScreen : MonoBehaviour
{
    //This script is used for the buttons on the Title Screen.

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


}
