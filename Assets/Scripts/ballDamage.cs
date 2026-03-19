using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballDamage : MonoBehaviour
{
    // Damage the ball does when it hits the player
    public int damageAmount = 5;

    //collison handling 
   private void OnTriggerEnter(Collider other)
    {
            // Get the player script from the player
            playerCharacter player = other.GetComponent<playerCharacter>();

            // If the script exists, deal damage to the player
            if (player != null)
            {
                //player.Hurt(damageAmount);
                Debug.Log("Game Over! Ball ran over player");

                //stop everything in game
                Time.timeScale = 0f;
            }
    }
}
