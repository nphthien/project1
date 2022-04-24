using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColumnController : MonoBehaviour
{
    public int health = 5;
    
    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Bullet"){
            other.gameObject.GetComponent<BulletController>().isAvailable = true;
            other.gameObject.SetActive(false);
            health--;
            if(health <= 0) {
                Destroy(gameObject);
            }
        }
    }
}
