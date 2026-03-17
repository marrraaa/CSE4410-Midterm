using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    private CharacterController charController;
    private Vector3 moveVector;

    private float speed = 5.0f;
    public float gravity = -9.8f;
    private float constantSpeed = 8.0f;
    private float jump = 7.0f;
    private float vertical;
    // Start is called before the first frame update
    void Start()
    {
        charController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float deltaX = Input.GetAxis("Horizontal") * speed;
        //ensures player moves forward at a constant speed
        float deltaZ = constantSpeed;

        //apply jump to player, press spacebar
        if (charController.isGrounded)
        {
            if (Input.GetButtonDown("Jump"))
            {
                vertical = jump;
            }
            else
            {
                //keep player grounded if not jumping
                vertical = -0.1f;
            }
        }
        //apply gravity while player is in air
        else
        {
            vertical += gravity * Time.deltaTime;
        }

        Vector3 movement = new Vector3(deltaX, vertical, deltaZ);
        movement *= Time.deltaTime;
        movement = transform.TransformDirection(movement);
        charController.Move(movement);
    }
}
