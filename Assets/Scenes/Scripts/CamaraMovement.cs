using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraMovement : MonoBehaviour
{
    public float maxSpeedY = 1.5f;
    private new AudioSource audio;

    void Start()
    {
        audio = Camera.main.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;

        pos.y += maxSpeedY * Time.deltaTime;
        transform.position = pos;

        if (transform.position.y >= 16)
        {
            audio.mute = true;
        }
    }
}
