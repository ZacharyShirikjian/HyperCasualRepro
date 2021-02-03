using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowBallCollect : MonoBehaviour
{
    /*
     * This script is used for collecting the Snow Balls in each level.
     * Once a player touches a Snow Ball, 
     * Destroy the Snow Ball Object (set active is disabled for now) 
     * Turn on that part of the Object's Outline GameObject,
     * And increase the Progress Bar on the GameManager 
     */

    //REFERENCES//
        //Reference to the GameMaster
        private GameMaster gm; 

    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.Find("GameMaster").GetComponent<GameMaster>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /*This method gets called when the Snow Plow GameObject enters a Snow Ball's Trigger Collider.
     *If a player touches a Snow Ball,
     *Add 1 to the Cur Snow Balls Collected Counter (in the GameMaster) 
     *Enable the outlined GameObject (which is a child of the parent) 
     *And disable the main Gameobject 
     */
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Plow")
        {
            gm.IncreaseSnowBallCounter();
            this.gameObject.SetActive(false);
        }
    }
}
