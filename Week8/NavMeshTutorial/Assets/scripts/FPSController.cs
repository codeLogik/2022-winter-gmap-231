using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSController : MonoBehaviour
{
    //movement Variables
    public float walkingSpeed = 7.5f;
    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;

    //camera Variables
    public Camera playerCamera;
    public float lookSpeed = 2.0f;
    public float lookXLimit = 45.0f;

    //Public keycode for unlocking the mouse
    public KeyCode unlockMouse = KeyCode.Delete;

    //Private Variables
    CharacterController characterController;
    Vector3 moveDirection = Vector3.zero;
    float rotationX = 0;

    // Start is called before the first frame update
    void Start()
    {
        //find the character controller on the gameObject, our movement script here will use functionality from the character controller component to move
        characterController = GetComponent<CharacterController>();

        //locks the cursor to the center of the game window and hides it so it looks more like an fps
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        //let players get their mouse back if they want
        if(Input.GetKeyDown(unlockMouse))
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

        //Local Vector Variables used to store 
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);

        //Local float Variables to calculate how fast we should move both forward and side to side based on player input
        float curSpeedX = walkingSpeed * Input.GetAxis("Vertical");
        float curSpeedY = walkingSpeed * Input.GetAxis("Horizontal");

        //local float variable to store the current veritcal direction of our player
        float movementDirectionY = moveDirection.y;

        //calculate movement vector based on our speed variables for moving forward and side to side 
        moveDirection = (forward * curSpeedX) + (right * curSpeedY);

        //adds vertical movement to our player if the player is on the ground and pressed the jump button
        if (Input.GetButton("Jump") && characterController.isGrounded)
        {
            moveDirection.y = jumpSpeed;
        }
        //stops adding vertical movement while the player is not jumping
        else
        {
            moveDirection.y = movementDirectionY;
        }

        //if the player is not on the ground subtracts our gravity force from vertical movement. This will allows for the player jump to slowly reach a peak and then return to the ground over time
        if (!characterController.isGrounded)
        {
            moveDirection.y -= gravity * Time.deltaTime;
        }
        //resets vertical movement to 0 after landing
        else if (characterController.isGrounded && moveDirection.y < 0)
        {
            moveDirection.y = 0;
        }

        //apply our final move direction to the player in game using the built in characterController move funciton
        characterController.Move(moveDirection * Time.deltaTime);

        //calculate where our camera should rotate based on mouse input
        rotationX += -Input.GetAxis("Mouse Y") * lookSpeed;
        //restrict how high or low the camera can rotate
        rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
        //rotate the camera to match vertical mouse input, when using Quaternion.Euler the rotation is applied around the given axis not to it, this is why x and y appear to be flipped
        //hand pneumonic device
        playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
        /*rotate our character to match horizontal mouse input, we use multiply here because of the nature of quaternions. You can't use addition to add one to the other. 
        to combine 2 quaternions like we want here (our original quaternion rotation + the rotation we want to turn to based on mouse input) we multiply the original by the second*/
        transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeed, 0);

    }
}
