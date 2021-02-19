using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//The documentation for the build index was used as a reference for figuring out how to get the specific build index of a scene:
//https://docs.unity3d.com/ScriptReference/SceneManagement.Scene-buildIndex.html

//This script is used for the buttons on the Title Screen, and for the Next Level button during gameplay.

public class TitleScreen : MonoBehaviour
{
    //Reference to the SFXManager script 
    private SFXManager sfxManager; 

    //Reference to the SFXManager's AudioSource
    private AudioSource sfxSource;

    //Reference to the buttonClick SFX
    private AudioClip buttonClick;

    private GameMaster gm;

    void Start()
    {
        if(SceneManager.GetActiveScene().buildIndex > 0)
        {
            gm = GameObject.Find("GameMaster").GetComponent<GameMaster>();

        }
        sfxManager = GameObject.Find("SFXManager").GetComponent<SFXManager>();
        sfxSource = GameObject.Find("SFXManager").GetComponent<AudioSource>();
        buttonClick = sfxManager.buttonClickSFX;
    }

    /*
     * This method gets called when the player taps on the "Start" button on the main menu. 
     * Load the first scene of the game and begin gameplay.
     */
    public void StartGame()
    {
        sfxSource.PlayOneShot(buttonClick);
        SceneManager.LoadScene(1);
    }

    /*
     * This method gets called when the player taps on the "NextLevel" button whenever they complete a level.
     * Load the next scene in the build index (or the Title Screen, if the player is on Level 3.
     */
    public void LoadNextLevel()
    {
        if(SceneManager.GetActiveScene().name == "Level3")
        {
            sfxSource.PlayOneShot(buttonClick);
            SceneManager.LoadScene(0);
        }

        else
        {
            sfxSource.PlayOneShot(buttonClick);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    public void Vibrate()
    {
        if(gm.vibration == true)
        {
            Debug.Log("Vibrate");
            Handheld.Vibrate();
        }

        else if(gm.vibration == false)
        {
            Debug.Log("DO NOT VIBRATE");
        }

    }


}
