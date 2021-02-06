using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script is based on the InputTouch script provided to me by Brianna Shuttleworth
//To help with the Snow Plow's movement. 

public class InputTouch : MonoBehaviour
{
    //REFERENCES//
    //Referenc to the Snow Plow's Rigidbody 
    private Rigidbody rb;

    //Reference to the GameMaster script 
    private GameMaster gm; 

    public float speed; //the speed at which the Snow Plow moves at.

    //VARIABLES//
    //private Vector3 startPos;
    private Vector3 touchPosition; //The position of the user's touch
    private Vector3 direction; //the direction at which the Snow Plow moves at.
    //private Vector2 touchPos;



    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        gm = GameObject.Find("GameMaster").GetComponent<GameMaster>();
    }

    // Update is called once per frame
    void Update()
    {
        //If there is at least 1 touch input on the screen
        //And if the level is not complete (if the level is complete, don't let the Snow Plow/Player from moving).
        if(gm.levelComplete == false && Input.touchCount > 0)
        {
            //Get the first touch input (with the index of 0)
            Touch touchInput = Input.GetTouch(0);

            //If the player has moved their finger across the screen
            //Move the Snow Plow.
            if(touchInput.phase == TouchPhase.Moved)
            {
                Debug.Log("Moving");

                //Camera.main.ScreenToWorldPoint converts the pixel coordinates of the touchInput into values which are able to be displayed on-screen to the Main Camera.
                touchPosition = Camera.main.ScreenToWorldPoint(new Vector3(touchInput.position.x, touchInput.position.y, Camera.main.nearClipPlane + 10f));

                //The direction which the Snow Plow moves in is the difference betweeen 
                //The current transform position and the touch position so there is an 
                //Offset between the two values. 

                direction = (touchPosition - transform.position).normalized;

                //Set the velocity of the Snow Plow's Rigidbody based on the direction Vector and the speed of the Snow Plow,
                //In order to make the Snow Plow actually move. 
                rb.velocity = direction * speed;
            }
        }
      
    }
}
