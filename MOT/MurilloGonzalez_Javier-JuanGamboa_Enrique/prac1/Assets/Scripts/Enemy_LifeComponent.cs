using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_LifeComponent : MonoBehaviour
{
    [SerializeField]
    private int score;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void Damage()
    {
        Destroy(gameObject);
        GameManager.instance.OnEnemyDies(score);
    }
}

