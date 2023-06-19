using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifetimeController : MonoBehaviour
{
    [SerializeField]
    private float _lifeTime = 5.0f;
    #region properties
    private float _elapsedTime = 0.0f;
    #endregion
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Temporizador en componente aparte
        //Destroy object if life time is over
        _elapsedTime += Time.deltaTime;
        if (_elapsedTime >= _lifeTime)
        {
            Destroy(gameObject);
        }

    }
}
