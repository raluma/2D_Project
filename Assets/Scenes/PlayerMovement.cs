using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float maxSpeed = 3.5f;

    // Start is called before the first frame update
    void Start()
    {
        
    } 

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        

        if (Input.GetKey(KeyCode.RightArrow))
        {
            pos.x += maxSpeed * Time.deltaTime;
            transform.position = pos;
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            pos.x -= maxSpeed * Time.deltaTime;
            transform.position = pos;
        }
    }
}
