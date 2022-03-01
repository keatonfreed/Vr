using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    
    public InputActionReference jumpReference;
    private Rigidbody rigidBody;
    // Start is called before the first frame update
    void Start()
    {
        jumpReference.action.performed += Jumped;
        rigidBody = GetComponent<Rigidbody>();
    }

    void Jumped(InputAction.CallbackContext obj) {
        rigidBody.AddForce(0,1000,0);
    }
}
