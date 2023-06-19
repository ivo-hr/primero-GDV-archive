using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Danyo : MonoBehaviour
{
    Color newColor = new Color(1f, 1f, 1f);
    float dano = 0;
    

    /*int damageOutOf100 = 100;
    public Camera cam;
    Color newColor = new Color(0.01f, 0.01f, 0.01f);*/
    // Start is called before the first frame update
    void Start()
    {
        Camera cam = gameObject.GetComponent<Camera>();
        cam.backgroundColor = newColor;
        Camera.main.backgroundColor = newColor;
        

        /*cam = GetComponent<Camera>();
        cam.clearFlags = CameraClearFlags.SolidColor;*/
    }

    // Update is called once per frame
    void Update()
    {
        if (dano == 100)
        { Camera.main.backgroundColor = newColor; }
        if (Destroyer.didntCatch = false)
        { ; }
    }
    
    
    /*void LateUpdate()
    {
        
        if (Destroyer.didntCatch == true)
        {
            damageOutOf100 += 10;
            Debug.Log("DAMAGED");
            cam.backgroundColor = newColor * damageOutOf100;
            Destroyer.didntCatch = false;
        }
        
        else if (damageOutOf100 > 0)
        {
            InvokeRepeating("Heal", 1f, 1f);
            Debug.Log("HEALING");
            cam.backgroundColor = newColor * damageOutOf100;
        }
        else if (damageOutOf100 == 0)
        {
            Debug.Log("FULL HEALTH");
            cam.backgroundColor = newColor * damageOutOf100;
        }


        //cam.backgroundColor = Color.Lerp(Color.black, Color.white, (damageOutOf100 / 100));



    }

    void Heal()
    {
        damageOutOf100 -= 1;
    }*/
}
    