using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdController : MonoBehaviour
{
    public BulletController bulletPrefab;
    public Rigidbody rig;
    public float speed;
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
            var newBullet = Instantiate(bulletPrefab, bulletPrefab.transform.position, bulletPrefab.transform.rotation);
            newBullet.gameObject.SetActive(true);
        }
    }
    void OnTriggerEnter(Collider other)
    {
        Time.timeScale = 0f;
        LineController.IsRunning = false;
        Debug.Log("Game OVER ");
    }

}
