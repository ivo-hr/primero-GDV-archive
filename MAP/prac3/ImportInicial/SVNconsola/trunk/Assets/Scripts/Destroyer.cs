using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour

{
    public static bool didntCatch;

    // Start is called before the first frame update
    void Start()
    {
        didntCatch =  false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider destroyer)
    {
        Debug.Log("Destroyer has registered contact with: " + destroyer.gameObject.name);
        didntCatch = true;
    }
}
