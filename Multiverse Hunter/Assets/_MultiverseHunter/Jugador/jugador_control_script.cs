using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jugador_control_script : MonoBehaviour
{
    CharacterController characterController;

    public float speed = 6.0f;
    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;

    private Vector3 moveDirection = Vector3.zero;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }
    
    void Update()
    {
   
        moveDirection = new Vector3(Input.GetAxis("Horizontal"), gravity*-1, Input.GetAxis("Vertical"));
        moveDirection *= speed;
       
        

        // Apply gravity. Gravity is multiplied by deltaTime twice (once here, and once below
        // when the moveDirection is multiplied by deltaTime). This is because gravity should be applied
        // as an acceleration (ms^-2)
       // moveDirection.y -= gravity * Time.deltaTime;

        // Move the controller
        characterController.Move(moveDirection * Time.deltaTime);
    }
}
