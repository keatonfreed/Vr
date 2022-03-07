using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerController : MonoBehaviour
{
    
    public InputActionReference jumpReference;
    
    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    public float jumpHeight = 100.0f;
    private float gravityValue = -20.81f;
    private float maxVelY = 150f;
    public bool onlyIfGrounded = true;

    void Start()
    {
        jumpReference.action.performed += Jumping;
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {


        playerVelocity.y += gravityValue * Time.deltaTime;
        if(playerVelocity.y >= maxVelY) {
            playerVelocity.y = maxVelY;
        } else if(playerVelocity.y <= -maxVelY) {
            playerVelocity.y = -maxVelY;
        }
        controller.Move(playerVelocity * Time.deltaTime);
        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }


    }


    void Jumping(InputAction.CallbackContext obj) {
        if(!(onlyIfGrounded && !groundedPlayer)) {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -gravityValue);
        }
    }
}
