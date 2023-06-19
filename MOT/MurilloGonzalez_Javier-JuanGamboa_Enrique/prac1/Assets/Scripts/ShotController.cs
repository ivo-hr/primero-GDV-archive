using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotController : MonoBehaviour
{
    #region parameters
    [SerializeField]
    private float _shotSpeed = 1.0f;
    #endregion

    #region methods
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Enemy_LifeComponent hitEnemy = collision.GetComponent<Enemy_LifeComponent>();
        if (hitEnemy)
        {
            hitEnemy.Damage();
        }
        
        Destroy(gameObject);
 
    }
    #endregion
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Movement applied to shot
        transform.Translate(_shotSpeed * Vector3.up * Time.deltaTime);

        
    }

    
}
