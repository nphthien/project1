using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    public int bulletCount = 10;
    public BulletController bulletPrefab;
    public List<BulletController> bullets = new List<BulletController>();
    // Start is called before the first frame update

    void Start()
    {
        for (int i = 0; i < bulletCount; i++)
        {
            CreateNewBullet();
        }
    }

    public BulletController GetAvailaibleBullet()
    {
        var availableBulet = bullets.Find(b => (b.isAvailable));

        if(availableBulet == null)
        {
            availableBulet = CreateNewBullet();
        }
        availableBulet.isAvailable = false;
        return availableBulet;
    }
    private BulletController CreateNewBullet()
    {
        var newBullet = Instantiate(bulletPrefab, bulletPrefab.transform.position, Quaternion.identity);
        newBullet.gameObject.SetActive(false);
        bullets.Add(newBullet);
        return newBullet;
    }
}
