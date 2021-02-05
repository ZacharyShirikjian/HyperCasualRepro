using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script is used for moving the Snow Plow by dragging it with the user's finger on a phone. 
//The Touch.phase documentation from Unity was used as a reference for getting the keywords for the touch input to function:
//https://docs.unity3d.com/ScriptReference/Touch-phase.html

//Alexander Zotov's "Tutorial How To Move & Control 3D Object By Touch Dragging Finger By The Screen In Mobile Unity Game" 
//was used as a reference for getting the Snow Plow to move across the screen:
//https://www.youtube.com/watch?v=3_CX-KtsDic 

public class MovePlow : MonoBehaviour
{
    //REFERENCES//
        //Reference to the Snow Plow's Rigidbody
        Rigidbody rb;

        //Variable for controlling the speed of the Snow Plow
        public float speed = 0.005f;

        //Reference to the GameMaster
        private GameMaster gm; 

    //VARIABLES//
    //Variable holding the current position of the Plow object 
    public Vector3 PlowPos;

    //Variable holding the current position of the Touch 
    public Vector3 touchPos;

    //Bool to check if the finger is held down or not 
    public bool fingerHeldDown = false;

    //The Touch Object, which gets set to the first finger touched on the screen during player input.
    private Touch touchInput;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        gm = GameObject.Find("GameMaster").GetComponent<GameMaster>();
    }

    // Update is called once per frame
    void Update()
    {
        /*Check to see if the level is complete.
         *If the level is complete, this code block doesn't run, 
         *Because the player isn't supposed to move here. 
         *
         *If there is at least 1 finger touching the screen (Input.touchCount > 0),
         *Move the Snow Plow based on the position of the player's finger. 
         */

        if (gm.levelComplete == false && Input.touchCount > 0)
        {
            //Set fingerHeldDown to true so the player knows the finger is held down on the screen 
            fingerHeldDown = true;

            //Get the touch Input from the user 
            //Since there is at least 1 touch (touchCount is > 0), 
            //Get the first touch on the screen as the TouchInput 
            touchInput = Input.GetTouch(0);

            //If the current phase of the Touch Input is Moved (if the finger has moved across the screen) 
            //Set the position of the Snow Plow's transform based on the transform position of the user's touch input.
            if(touchInput.phase == TouchPhase.Moved)
            {
               // rb.constraints = RigidbodyConstraints.FreezePositionY;

                //Set the position of the Snow Plow's transform to be that of the difference between the touchInput's position 
                //And the Snow Plow's Transform position (to have it so the touchInput's coordinates matches with the transform position that is on-screen.
                //touchInput.deltaPosition is the "difference between the position recorded on the most recent update, and that recorded on the previous update."
                //https://docs.unity3d.com/ScriptReference/Touch-deltaPosition.html 

                
                this.transform.position = new Vector3(this.transform.position.x + touchInput.deltaPosition.x * Time.deltaTime,
                                      this.transform.position.y,
                                      this.transform.position.z + touchInput.deltaPosition.y * Time.deltaTime);
               // //Camera.main.ScreenToWorldPoint is used because otherwise the touchInput values are off-screen
               // //ScreenToWorldPoint converts a pixel point to that which is visible within the world space (on-screen) 
               // //10f is used b/c it prevents 
               // touchPos = Camera.main.ScreenToWorldPoint(new Vector3(touchInput.position.x, touchInput.position.y, 10f));
               //// Vector3 temp = new Vector3(0, 2.35f, 0);

               // //Set the current position of the Snow Plow based on the touch Input's position 
               // //PlowPos = touchPos;
               // transform.position = Vector3.Lerp(transform.position, touchPos, Time.deltaTime);
               // //transform.position += temp;
            }

            /*If the finger is released from the screen,
             *Stop moving the Snow plow.
             */
            else if (touchInput.phase == TouchPhase.Ended)
            {
                //Debug.Log("Stop moving the plow");
                fingerHeldDown = false; 
            }

            //fingerPos = touchInput.position;
            //Debug.Log(fingerPos);
            //Debug.Log(this.transform.position);
            //this.transform.position = fingerPos;
        }


    }
}
