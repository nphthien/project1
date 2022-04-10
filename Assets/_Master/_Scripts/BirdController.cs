using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class BirdController : MonoBehaviour
{
    public int columnToNextLevel = 2;
    public int currentColumnPass = 0;
    public int currentLevel = 1;
    public float angleBullet = 15f;
    public float bulletCount = 1;
    public BulletController bulletPrefab;
    public Rigidbody rig;
    public float speed;
    private float currentAngle = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)){
            rig.velocity = Vector3.up * speed;
        }
        if(Input.GetMouseButtonDown(0)){
            currentAngle = 0f;
            bulletCount = 1 + (currentLevel - 1) * 2;
            for (int i = 0; i < bulletCount; i++)
            {
                if (i % 2 == 1)
                {
                    currentAngle += angleBullet;
                }
                currentAngle = currentAngle * -1;
                var angle = Quaternion.Euler(0, 0, currentAngle);
                CreateBullet(angle);
            }
        }
    }
    public void CreateBullet(Quaternion angle)
    {
        var newBullet = Instantiate(bulletPrefab, bulletPrefab.transform.position, angle);
        newBullet.gameObject.SetActive(true);
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "CheckThrough")
        {
            currentColumnPass += 1;
            if(currentColumnPass >= columnToNextLevel)
            {
                currentColumnPass = 0;
                currentLevel++;
            }
        }
        else
        {
            //dead
            Time.timeScale = 0f;
            LineController.IsRunning = false;
            Debug.Log("Game OVER ");
        }
        
    }

}
