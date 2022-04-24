using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class BirdController : MonoBehaviour
{
    public Text birdLevelText;
    public Text bulletCountText;
    public Text nextLevelText;
    public Text pointText;

    public int columnToNextLevel = 2;
    public int currentColumnPass = 0;
    public int currentLevel = 1;
    public float angleBullet = 15f;
    public float bulletCount = 1;
    public Rigidbody rig;
    public float speed;
    public Transform bulletPivot;
    public BulletPool bulletPool;
    public int point = 0;
    private float currentAngle = 0f;

    // Start is called before the first frame update
    void Start()
    {
        bulletCount = 1 + (currentLevel - 1) * 2;

        pointText.text = point.ToString();
        nextLevelText.text = (columnToNextLevel - currentColumnPass).ToString();
        birdLevelText.text = currentLevel.ToString();
        bulletCountText.text = bulletCount.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)){
            rig.velocity = Vector3.up * speed;
        }
        if(Input.GetMouseButtonDown(0)){
            currentAngle = 0f;
            
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
        var bullet = bulletPool.GetAvailaibleBullet();
        bullet.transform.rotation = angle;
        bullet.transform.position = bulletPivot.position;
        bullet.gameObject.SetActive(true);
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "CheckThrough")
        {
            point++;
            pointText.text = point.ToString();
            currentColumnPass += 1;
            
            if (currentColumnPass >= columnToNextLevel)
            {
                currentColumnPass = 0;
                currentLevel++;
                bulletCount = 1 + (currentLevel - 1) * 2;
                birdLevelText.text = currentLevel.ToString();
                bulletCountText.text = bulletCount.ToString();
            }
            nextLevelText.text = (columnToNextLevel - currentColumnPass).ToString();
        }
        else if (other.tag == "Bullet")
        {
            
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
