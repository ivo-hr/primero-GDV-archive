using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public float minRitmoCreacion;
    public float maxRitmoCreacion;
    public GameObject Letter;
    float horaCreacion;
    private float intervalo;


    void Crearletras()
    {
        Vector3 letterX = new Vector3(Random.Range(-7.0f, 7.0f), (float)5.5, 0);
        Instantiate(Letter, letterX, Quaternion.identity);

        
    }
    
    // Start is called before the first frame update
    void Start()
    {
        horaCreacion = Time.time;


        InvokeRepeating("Crearletras", 1, (Random.Range(minRitmoCreacion, maxRitmoCreacion)));
        //transform.Translate(letterX);
        //Invoke("Crearletras", 2);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
