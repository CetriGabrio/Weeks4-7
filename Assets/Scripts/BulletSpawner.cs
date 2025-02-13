using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform bulletSpawnPoint;
    public float bulletSpeed = 10.0f;

    public AudioClip fireSound;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
            Bullet bulletScript = bullet.GetComponent<Bullet>();
            bulletScript.speed = bulletSpeed;

            AudioSource.PlayClipAtPoint(fireSound, transform.position);
        }
    }
}
