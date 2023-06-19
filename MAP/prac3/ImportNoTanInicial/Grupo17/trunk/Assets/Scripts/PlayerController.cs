using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float unitPerSecs = 1f;
    Vector3 move = new Vector3(0f, 0f, 0f);
    const float anchoMundo = 6f;
    float moveX, mouseSens = 1f, mouseSensPub = 7f;
    // Start is called before the first frame update
    void Start()
    {
        //vava perfe
    }

    // Update is called once per frame
    void Update()
    {
        // MOVEMENT

        if (Input.GetMouseButton(0))                                           // mouse and key movement decider
        {
            moveX = Input.GetAxis("Mouse X");                                  // mouse movement (active by pressing left click)
            mouseSens = mouseSensPub;
        }
        else
        {
            moveX = Input.GetAxis("Horizontal");                               // key movement
            mouseSens = 1;
        }

        Vector3 move = new Vector3(moveX, 0, 0);                               // 
        move.Normalize();                                                      // movement calculator (with mouse sensibility)
        move = move * unitPerSecs * Time.deltaTime * mouseSens;                // 

        if (transform.position.x > (anchoMundo))
        {
            transform.position = new Vector3(6, -4, 0);
        }
        else if (transform.position.x < (-anchoMundo))
        {
            transform.position = new Vector3(-6, -4, 0);
        }
        else
        {
            transform.Translate(move);                                         // move!

        }
    }
    
}






