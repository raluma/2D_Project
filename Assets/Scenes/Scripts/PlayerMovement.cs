using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float maxSpeedX = 3.5f;
    public float maxSpeedY = 1.5f;
    public int health = 1;

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;

        // Movements
        if (Input.GetKey(KeyCode.RightArrow))
        {
            pos.x += maxSpeedX * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            pos.x -= maxSpeedX * Time.deltaTime;
        }
        // Movements

        pos.y += maxSpeedY * Time.deltaTime;
        transform.position = pos;
    }

    void OnTriggerEnter2D(Collider2D collider)
    {

        foreach (GameObject enemy in GameObject.FindGameObjectsWithTag("Meteor"))
        {
            if (collider.Equals(enemy.GetComponent("Collider2D")))
            {
                health--;
            }
        }
    }

    void OnGUI()
    {
        if (health <= 0)
        {
            GUI.Label(new Rect(Screen.width / 2 - 50, Screen.height / 2 - 25, 100, 50), "Game Over!");
        }
    }


}
