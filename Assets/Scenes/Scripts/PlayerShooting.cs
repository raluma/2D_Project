using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{  
    public GameObject bulletPrefab;
    public PlayerMovement player;

    public float fireDelay;
    public float cooldownTimer;
    public float killPoint = 100f;
    private int meteorsCount;

    // Start is called before the first frame update
    void Start()
    {
        fireDelay = 0.25f;
        cooldownTimer = 0;
        meteorsCount = GameObject.FindGameObjectsWithTag("Meteor").Length;
    }

    // Update is called once per frame
    void Update()
    {
        cooldownTimer -= Time.deltaTime;

        if (cooldownTimer <= 0 && transform.position.y <= 12)
        {
            cooldownTimer = fireDelay;

            Vector3 offset = transform.rotation * new Vector3(0, 0.75f, 0);
            Instantiate(bulletPrefab, transform.position + offset, transform.rotation);
        }
    }


    void OnGUI()
    {
        float points = (meteorsCount - GameObject.FindGameObjectsWithTag("Meteor").Length) * killPoint;

        GUI.Label(new Rect(0, 0, 100, 50), "Puntos: " + points);

        if ((GameObject.FindGameObjectsWithTag("Meteor").Length == 0 || transform.position.y >= 12) && player.health > 0)
        {
            GUI.Label(new Rect(Screen.width / 2 - 50, Screen.height / 2 - 25, 100, 50), "You win! \n Points: " + points);
        }
    }
}
