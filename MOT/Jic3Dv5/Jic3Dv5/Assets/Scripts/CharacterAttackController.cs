using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAttackController : MonoBehaviour
{
    #region parameters
    /// <summary>
    /// Force applied to enemy when shot impacts
    /// </summary>
    [SerializeField]
    private float _impactForce = 100.0f;
    #endregion
    #region references
    /// <summary>
    /// Reference to self Transform
    /// </summary>
    private Transform _myTransform;
    /// <summary>
    /// Reference to object that will act as source of the shots
    /// </summary>
    [SerializeField]
    private GameObject _shotOriginObject;
    /// <summary>
    /// Reference to the transform of the object that will act as source of the shots
    /// </summary>
    private Transform _shotOriginTransform;
    #endregion
    #region properties
    /// <summary>
    /// LayerMask used for enemies detection.
    /// </summary>
    private LayerMask _myLayerMask;

    private RaycastHit _hit;
    private Vector3 _originPoint;
    private GameObject _victim;
    private Vector3 _dirOfRay;
    #endregion
    #region methods
    /// <summary>
    /// Tries to shot a target from origin point. Causes damage and applies force to target
    ///if successful.
    /// </summary>
    /// <param name="originPoint">Shoot origin point</param>
    /// <param name="targetPoint">Shoot target point</param>
    public void Shoot(Vector3 targetPoint)
    {
        bool forceApplied = false;
        
        _originPoint = _shotOriginObject.transform.position;

        _dirOfRay = targetPoint - _originPoint;
        Debug.DrawRay(_originPoint, _dirOfRay, Color.red, 1000);
        if (Physics.Raycast(_originPoint, _dirOfRay, out _hit))
        {
            _victim = _hit.collider.gameObject;
            Debug.Log("Shot fired onto" + _victim.name);

            if (_victim.GetComponent<EnemyLifeComponent>() != null)
            {
               Debug.Log("Shot hit");
                _victim.GetComponent<EnemyLifeComponent>().Damage();

                //_victim.transform.Translate(_dirOfRay.normalized * _impactForce);
                if (!forceApplied)
                {
                    _hit.rigidbody.AddForce(_dirOfRay.normalized * _impactForce);
                    forceApplied = true;
                }
            }
        }
    }

    public void OriginObjAssign(GameObject originObj)
    {
        _shotOriginObject = originObj;
    }
    #endregion

 /// <summary>
 /// LayerMask and Camera initialization
 /// </summary>
 void Start()
    {
        _myTransform = transform;
        _myLayerMask = gameObject.layer;
        Debug.LogWarning("LayerMask: " + _myLayerMask);
    }
}