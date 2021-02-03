using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script is used for moving the Snow Plow by dragging it with the user's finger on a phone. 
//The Touch.phase documentation from Unity was used as a reference for getting the keywords for the touch input to function:
//https://docs.unity3d.com/ScriptReference/Touch-phase.html

//This script was used as a reference for getting the Snow Plow to move across the screen:
//Landern's script from the Drag GameObject with finger touch on SmartPhone post on Unity Answers (rudisky):
//https://answers.unity.com/questions/1223838/drag-gameobject-with-finger-touch-in-smartphone.html 

public class MovePlow : MonoBehaviour
{
    //REFERENCES//
        //Reference to the Snow Plow's Rigidbody
        Rigidbody rb;

        //Float holding the amount of speed which the snow plow moves at 
        //public float speed = 1.0f;

    //VARIABLES//
    //Variable holding the current position of the Plow object 
    public Vector3 PlowPos;

    //Variable holding the current position of the Touch 
    public Vector3 touchPos;

    //Bool to check if the finger is held down or not 
    public bool fingerHeldDown = false; 

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        /*If the finger is held down on the screen (if there is a touch input),
         *Get the current position of the finger on the screen
         *Set the position of the Snow Plow to that of from the user's finger 
         */

        if (Input.touchCount > 0)
        {
            ////Set fingerHeldDown to true so the player knows the finger is held down on the screen 
            //fingerHeldDown = true;

            //Get the touch Input from the user 
            //Since there is at least 1 touch (touchCount is > 0), 
            //Get the first touch on the screen as the TouchInput 
            Touch touchInput = Input.GetTouch(0);

            //If the current phase of the Touch Input is Moved (if the finger has moved across the screen) 
            //AND if the player has touched on the Snow Plow (the touch has collided with the snow plow) 
            if(touchInput.phase == TouchPhase.Moved)
            {
                //Debug.Log("Moving the plow");
                rb.constraints = RigidbodyConstraints.FreezePositionY;

                //Camera.main.ScreenToWorldPoint is used because otherwise the touchInput values are off-screen
                //ScreenToWorldPoint converts a pixel point to that which is visible within the world space (on-screen) 
                //10f is used b/c it prevents 
                touchPos = Camera.main.ScreenToWorldPoint(new Vector3(touchInput.position.x, touchInput.position.y, 10f));
               // Vector3 temp = new Vector3(0, 2.35f, 0);

                //Set the current position of the Snow Plow based on the touch Input's position 
                //PlowPos = touchPos;
                transform.position = Vector3.Lerp(transform.position, touchPos, Time.deltaTime);
                //transform.position += temp;
            }

            /*If the finger is released from the screen,
             *Stop moving the Snow plow.
             */
            else if (touchInput.phase == TouchPhase.Ended)
            {
                //Debug.Log("Stop moving the plow");
                touchPos.y = 2.35f;
            }

            //fingerPos = touchInput.position;
            //Debug.Log(fingerPos);
            //Debug.Log(this.transform.position);
            //this.transform.position = fingerPos;
        }


    }
}
