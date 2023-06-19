using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship_LifeComponent : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Enemy_LifeComponent hitEnemy = collision.GetComponent<Enemy_LifeComponent>();
        if (hitEnemy)
        {
            GameManager.instance.OnPlayerDies();
        }

        Destroy(gameObject);
    }
}
