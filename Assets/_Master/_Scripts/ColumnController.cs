using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColumnController : MonoBehaviour
{
    public int health = 5;
    
    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Bullet"){
            Destroy(other.gameObject);
            health--;
            if(health <= 0) {
                Destroy(gameObject);
            }
        }
    }
}
