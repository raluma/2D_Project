using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float maxSpeedX = 3.5f;
    public float maxSpeedY = 1.5f;
    public float shipBoundaryRadius = 0.5f;
    public int health = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    } 

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

        // Limits
        if (pos.y + shipBoundaryRadius > Camera.main.orthographicSize)
        {
            pos.y = Camera.main.orthographicSize - shipBoundaryRadius;
        }

        if (pos.y - shipBoundaryRadius < -Camera.main.orthographicSize)
        {
            pos.y = -Camera.main.orthographicSize + shipBoundaryRadius;
        }

        float screenRatio = (float)Screen.width / (float)Screen.height;
        float widthOrtho = Camera.main.orthographicSize * screenRatio;

        if (pos.x + shipBoundaryRadius > widthOrtho)
        {
            pos.x = widthOrtho - shipBoundaryRadius;
        }

        if (pos.x - shipBoundaryRadius < -widthOrtho)
        {
            pos.x = -widthOrtho + shipBoundaryRadius;
        }
        // Limits

        pos.y += maxSpeedY * Time.deltaTime;
        transform.position = pos;
    }

    void OnTriggerEnter2D(Collider2D collider)
    {

        foreach (GameObject enemy in GameObject.FindGameObjectsWithTag("Objects"))
        {
            if (collider.Equals(enemy.GetComponent("Collider2D")))
            {
                Debug.Log("Nave Destruida!");
                health--;
            }
        }

        if (health <= 0)
        {
            Destroy(gameObject);
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
