using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineController : MonoBehaviour
{
   private static float speed = 0.1f;
   public static bool IsRunning {
       set{
           if(value == true){
               speed = 0.03f;
           }
           else {
               speed =0f;
           }
       }
   }
   public static Vector2 bound = new Vector2(-2.1f, 2.4f);
    // Start is called before the first frame update
    void Start()
    {
        //gameObject
        float y = Random.Range(bound.x, bound.y);
        Vector3 currentPosition =  transform.position;
        currentPosition.y = y;
        transform.position = currentPosition;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.left * speed;
    }
}
