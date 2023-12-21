using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageHandler : MonoBehaviour
{
    public int health = 1;

    void OnTriggerEnter2D()
    {
        health--;

        if (health <= 0)
        {
            Destroy(gameObject);   
        }
    }
}
