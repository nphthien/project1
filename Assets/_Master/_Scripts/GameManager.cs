using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public LineController prefab;
    public float durationCreateLine = 1f;
    private float currentTime=0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
        if(currentTime >= 1f){
            //Create line
            currentTime = 0f;
            var newLine = Instantiate(prefab);
            newLine.gameObject.SetActive(true);
        }
    }
}
