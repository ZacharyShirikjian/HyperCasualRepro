using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

//This script is from Info Gamer's "How to Make an Audio Toggle in Unity (Snake Cubed Winners)" tutorial on YouTube:
//https://www.youtube.com/watch?v=FR7zDjS0mO8&list=WL&index=9

[RequireComponent(typeof(Toggle))] //When we add our script to GObject, it automatically adds toggle component if it doesn't exist 
public class MuteToggle : MonoBehaviour
{
    Toggle audioToggle;

    // Start is called before the first frame update
    void Start()
    {
        audioToggle = GetComponent<Toggle>(); 
        if(AudioListener.volume == 0)
        {
            audioToggle.isOn = false;
        }
    }

    public void ToggleAudioOnValueChange(bool audioIn)
    {
        if(audioIn == true)
        {
            AudioListener.volume = 1;
        }
        else
        {
            AudioListener.volume = 0; 
        }
    }
}
