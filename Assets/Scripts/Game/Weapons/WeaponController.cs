using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{

    public Transform firePoint;
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
        // int playerDir()
        // {
        //     if (transform.parent.localScale.y < 0f)
        //     {
        //         return -1;
        //     }
        //     return 1;
        // }


        GameObject shot = Instantiate(ammoType, firePoint.position, firePoint.rotation);
        Rigidbody2D shotRB = shot.GetComponent<Rigidbody2D>();
        shotRB.AddForce(shotSpeed * transform.up, ForceMode2D.Impulse);
        Destroy(shot, 1f);
    }
}
