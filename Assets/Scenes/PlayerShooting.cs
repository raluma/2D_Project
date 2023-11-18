using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject bulletPrefab;

    public float fireDelay = 0.25f;
    public float cooldownTimer = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        cooldownTimer -= Time.deltaTime;

        if (cooldownTimer <= 0)
        {
            cooldownTimer = fireDelay;

            Vector3 offset = transform.rotation * new Vector3(0, 0.75f, 0);
            Instantiate(bulletPrefab, transform.position + offset, transform.rotation);
        }
    }
}
