using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollerBallMovement : MonoBehaviour {

    //______________________________________ Variables __________________________________________
    //Initialise Player RigidBody, movement_Speed and jump_Height which are all set in inspector
    public Rigidbody Player;
    public float movement_Speed;
    public float jump_Height;

	// Use this for initialization
	void Start ()
    {
        //Allows us to use Player.<RigidBody> commands in our code
        Player = GetComponent<Rigidbody>();
	}

    //_________________ Physics ___________________
    //Used for Physics calculations such as movement.
    void FixedUpdate()
    {
        //Checks for spacebar once per frame and applies force upwards on down press
        Jump();

        //________________________ X and Z Movement _____________________________
        //Tracking input via Input.GetAxis (Allows gamepad controller to be used)
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        //Define movement direction as a vector3
        Vector3 MoveDir = new Vector3(moveHorizontal, 0.0f, moveVertical);

        //Roll Player rigidbody in vector 3 of speed times preset movement speed which can be set in inspector as public variable
        Player.AddForce(MoveDir * movement_Speed);
    }

    // Update is called once per frame (unused in this instance as there are no continuous calculations outside of physics)
    void Update ()
    {
        //If (Party.Type == Disco)
        //{
        //  Dance = "Boogie";
        //}
        //
        //Else
        //{
        //  Happy = False;
        //}
	}

    //____________________________ Jumping Movement ____________________________
    void Jump()
    {
        //Check for "Jump" input, also compatible with gamepad/controller
        if (Input.GetButtonDown("Jump"))
        {
            //Add force to the player instantaneously due to VelocityChange modifier being applied (ignores mass when applying force)
            Player.AddForce(0, 1.0f * jump_Height, 0, ForceMode.VelocityChange);
        }
    }
}
