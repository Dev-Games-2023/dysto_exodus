using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotgunController : MonoBehaviour
{

    public Transform[] firePoints;
    public GameObject ammoType;

    public float shotSpeed;
    public float shotCounter, fireRate;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            shotCounter -= Time.deltaTime;
            if (shotCounter <= 0)
            {
                shotCounter = fireRate;
                Shoot();
            }
        }
        else{
            shotCounter = 0;
        }
    }

    void Shoot()
    {
        foreach (Transform firePoint in firePoints)
        {
            GameObject shot = Instantiate(ammoType, firePoint.position, firePoint.rotation);
            Rigidbody2D shotRB = shot.GetComponent<Rigidbody2D>();
            shotRB.AddForce(shotSpeed * transform.up, ForceMode2D.Impulse);
            Destroy(shot, 1f);
        }
    }
}
