using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScript : MonoBehaviour
{
    public Transform firePoint;

    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private GameObject player;

    public Joystick joystick;
    
    public enum GunType { normal, fast, enemy };

    private Vector3 difference;

    [SerializeField] private GunType gunType;    

    [SerializeField] private float timeBetweenTheShots;
    [SerializeField] private float startTimeBetweenTheShots;
    [SerializeField] private float offset = 90;
    private float rotZ = 180;

    void Update()
    {
        if (gunType == GunType.normal || gunType == GunType.fast)
        {
            if (joystick.Vertical >= 0.01 || joystick.Vertical <= -0.01 || joystick.Horizontal >= 0.1 || joystick.Horizontal <= -0.1)
            {   
                rotZ = Mathf.Atan2(joystick.Vertical, joystick.Horizontal) * Mathf.Rad2Deg;
            }
            transform.rotation = Quaternion.Euler(0f, 0f, rotZ + offset);
        }
        else if (gunType == GunType.enemy)
        {
            difference = player.transform.position - transform.position;
            rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
            if (timeBetweenTheShots <= 0)
            {
                Shoot();
            }
            else
            {
                timeBetweenTheShots -= Time.deltaTime;
            }
            transform.rotation = Quaternion.Euler(0f, 0f, rotZ -90);
        }

        if (timeBetweenTheShots <= 0)
        {
            Shoot();
        }
        else 
        {
            timeBetweenTheShots -= Time.deltaTime;
        }
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

        timeBetweenTheShots = startTimeBetweenTheShots;
    }
}
