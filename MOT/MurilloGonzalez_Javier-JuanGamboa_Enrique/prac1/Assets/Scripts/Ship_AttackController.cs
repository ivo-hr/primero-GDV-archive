using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship_AttackController : MonoBehaviour
{
    [SerializeField]
    private GameObject myShot;
    [SerializeField]
    private float shotStartDist;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }



    public void Shoot() 
    {
        Instantiate(myShot,transform.position + new Vector3 (0, shotStartDist, 0), Quaternion.identity);
    }
}
