using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    private CharacterController charController;
    private Vector3 moveVector;

    private float speed = 5.0f;
    public float gravity = -9.8f;
    // Start is called before the first frame update
    void Start()
    {
        charController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float deltaX = Input.GetAxis("Horizontal") * speed /* Time.deltaTime*/;
        float deltaZ = Input.GetAxis("Vertical") * speed /*Time.deltaTime*/;
        //transform.Translate(deltaX, speed, deltaZ);

        Vector3 movement = new Vector3(deltaX, speed, deltaZ);
        movement = Vector3.ClampMagnitude(movement, speed);
        movement.y = gravity;
        movement *= Time.deltaTime;
        movement = transform.TransformDirection(movement);
        charController.Move(movement);
    }
}
