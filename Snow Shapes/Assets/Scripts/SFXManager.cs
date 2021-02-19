using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : MonoBehaviour
{
    //REFERENCE TO ALL OF THE SFX AUDIO CLIPS IN THE GAME//

    public AudioClip snowBallCollect;
    public AudioClip allSnowBallsCollected;
    public AudioClip levelComplete;
    public AudioClip buttonClickSFX;

    //Reference to this Audio Source
    public AudioSource sfxSource;

    //An instance of this SFXManager script, which is used for the DontDestroyOnLoad() method.
    private static SFXManager instance;

    private void Awake()
    {
        //If there is already an instance of this script in the current scene, then delete this duplicated instance
        if(instance != null)
        {
            Destroy(this.gameObject);
        }

        //Otherwise, if there are no other instances of this script in the current scene,
        //Make sure it doesn't get deleted by calling the DontDestroyOnLoad() method. 
        else
        {
            instance = this;

            //DontDestroyOnLoad() is called to the current GameObject with the SFXManager script on it. 
            DontDestroyOnLoad(this.transform.gameObject);
        }
    }
}
