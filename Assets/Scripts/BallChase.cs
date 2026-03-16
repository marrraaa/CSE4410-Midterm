using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallChase : MonoBehaviour
{
    // Reference to the player object so the ball can follow it
    public Transform player;
    public float moveForce = 15f;
    public float spinSpeed = 50f;
    
    // Damage the ball does when it hits the player
    public int damageAmount = 5;
    // Rigidbody component attached to the ball
    private Rigidbody rb;
    // Tracks whether the player has started running (starts the game)
    private bool gameStarted = false;

    //challenge mode 
    //challenge mode in the inspector
    public bool challengeMode = false;
    public float challengeSpeedMultiplier = 1.5f;
    public Transform mainCamera;
    public float shakeAmount = 0.15f;
    public float shakeSpeed = 20f;

    // Original camera position so it can reset after shaking
    private Vector3 cameraOriginalPos;

    void Start()
    {
        // Get the Rigidbody attached to the ball
        rb = GetComponent<Rigidbody>();

        // If player not assigned in Inspector, find object tagged "Player"
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player").transform;
        }

        // If camera not assigned, grab the main camera
        if (mainCamera == null)
        {
            mainCamera = Camera.main.transform;
        }

        // Store the camera's starting position
        cameraOriginalPos = mainCamera.localPosition;
    }

    void Update()
    {
        // Get the player's Rigidbody to check movement speed
        Rigidbody playerRB = player.GetComponent<Rigidbody>();

        // If the player begins moving, the game starts
        if (!gameStarted && playerRB.velocity.magnitude > 0.1f)
        {
            gameStarted = true;
        }

        // Once the game has started, the ball begins chasing
        if (gameStarted)
        {
            // Calculate the direction from the ball to the player
            Vector3 direction = (player.position - transform.position).normalized;

            // If challenge mode is active, increase the force
            float currentForce = moveForce;
            if (challengeMode)
            {
                currentForce *= challengeSpeedMultiplier;
            }

            // Apply force toward the player so the ball rolls
            rb.AddForce(direction * currentForce);
            // Rotate the ball so it spins while rolling
            transform.Rotate(Vector3.right * spinSpeed * Time.deltaTime);

            // If challenge mode is active, shake the camera
            if (challengeMode)
            {
                ShakeCamera();
            }
            else
            {
                // Reset camera position if challenge mode is off
                mainCamera.localPosition = cameraOriginalPos;
            }
        }
    }

    //camera shakes in challenge mode
    void ShakeCamera()
    {
        // Create a small random movement for the camera
        float offsetX = Mathf.PerlinNoise(Time.time * shakeSpeed, 0) * shakeAmount - (shakeAmount / 2);
        float offsetY = Mathf.PerlinNoise(0, Time.time * shakeSpeed) * shakeAmount - (shakeAmount / 2);

        // Apply the shake offset
        mainCamera.localPosition = cameraOriginalPos + new Vector3(offsetX, offsetY, 0);
    }

    //collison handling 
    void OnCollisionEnter(Collision collision)
    {
        // Check if the ball hit the player
        if (collision.gameObject.CompareTag("Player"))
        {
            // Get the PlayerCharacter script from the player
            PlayerCharacter player = collision.gameObject.GetComponent<PlayerCharacter>();

            // If the script exists, deal damage to the player
            if (player != null)
            {
                player.Hurt(damageAmount);
            }
        }
    }
}