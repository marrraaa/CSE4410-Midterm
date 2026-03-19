using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerCharacter : MonoBehaviour
{
    private int health;
    // Start is called before the first frame update
    void Start()
    {
        health = 5;
    }

    //taking damage
    public void Hurt(int damage)
    {
        health -= damage;
        Debug.Log($"Health: {health}");
    }
}
