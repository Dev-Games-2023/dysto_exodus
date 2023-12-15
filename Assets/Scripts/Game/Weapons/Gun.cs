using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField]
    private Transform _gunOffset;

    public Bullet bullet;

    int numberOfGuns = 1;
    
    public int currentGunIndex;

    public GameObject[] guns;
    public GameObject gunHolder;
    public GameObject currentGun;

    void Start()
    {
        numberOfGuns = gunHolder.transform.childCount;
        guns = new GameObject[numberOfGuns];

        for (int i = 0; i < numberOfGuns; i++)
        {
            guns[i] = gunHolder.transform.GetChild(i).gameObject;
            guns[i].SetActive(false);
        }

        guns[0].SetActive(true);
        currentGun = guns[0];
        currentGunIndex = 0;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (currentGunIndex < numberOfGuns - 1)
            {
                guns[currentGunIndex].SetActive(false);
                currentGunIndex += 1;
                guns[currentGunIndex].SetActive(true);
                currentGun = guns[currentGunIndex];
            }
        }
        else if (Input.GetKeyDown(KeyCode.Q))
        {
            if (currentGunIndex > 0)
            {
                guns[currentGunIndex].SetActive(false);
                currentGunIndex -= 1;
                guns[currentGunIndex].SetActive(true);
                currentGun = guns[currentGunIndex];
            }
        }
    }

    public int Speed { get; private set; }

    public void Shoot(int speed)
    {
        GameObject gameObject = Instantiate(bullet.gameObject, _gunOffset.position, _gunOffset.rotation);
        gameObject.GetComponent<Rigidbody2D>().velocity = speed * transform.up;
    }
}
