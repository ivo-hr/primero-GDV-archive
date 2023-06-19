using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cae : MonoBehaviour
{
    //Declaro variables      
    public float unitPerSecs, minVel = 0.01f, maxVel = 0.15f;
    float incrY;

    // Start is called before the first frame update
    void Start()
    {
        incrY = -(Random.Range(minVel, maxVel));
    }

    // Update is called once per frame
    void Update()
    {
        
        Vector2 move = new Vector2(0, incrY);

        move.Normalize();

        move = move * unitPerSecs * Time.deltaTime;
        transform.Translate(move);
    }
}
