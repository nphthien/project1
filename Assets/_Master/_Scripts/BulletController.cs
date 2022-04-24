using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float speed = 5f;
    public bool isAvailable = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.right* Time.deltaTime * speed;
    }
    private void OnBecameInvisible()
    {
        isAvailable = true;
        gameObject.SetActive(false);
    }
}
