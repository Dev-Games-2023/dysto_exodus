// using System.Collections;
// using System.Collections.Generic;
// using Unity.VisualScripting;
// using UnityEngine;
// using UnityEngine.InputSystem;

// public class PlayerShoot : MonoBehaviour
// {
//     public Transform gun;
//     public Transform shootPoint;

//     Vector2 direction;

//     public GameObject bullet;
//     public float bulletSpeed;

//     public float fireRate;
//     float readyForNextShot;

//     void Start()
//     {

//     }

//     void Update()
//     {
//         Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
//         direction = mousePos - (Vector2)gun.position;
//         FaceMouse();

//         if (Input.GetMouseButton(0) || Input.GetKeyDown(KeyCode.Space))
//         {
//             if (Time.time > readyForNextShot)
//             {
//                 readyForNextShot = Time.time + 1/fireRate;
//                 shoot();
//             }
//         }
//     }

//     void FaceMouse()
//     {
//         gun.transform.right = direction;
//     }

//     void shoot()
//     {
//         GameObject bulletInstance = Instantiate(bullet, shootPoint.position, shootPoint.rotation);
//         bulletInstance.GetComponent<Rigidbody2D>().AddForce(bulletInstance.transform.right * bulletSpeed);
//         Destroy(bulletInstance, 3);
//     }
// }
