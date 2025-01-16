using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;

    public void SpawnBullet()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
}
