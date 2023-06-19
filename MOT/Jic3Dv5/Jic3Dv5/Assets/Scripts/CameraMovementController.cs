using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovementController : MonoBehaviour
{
    #region parameters
    /// <summary>
    /// Desired offset from target.
    /// </summary>
    [SerializeField]
    private Vector3 _offset = new Vector3(0, 1.0f, 2.0f);
    /// <summary>
    /// Desired vertical offset for LookAt point from target.
    /// </summary>
    [SerializeField]
    private float _lookAtHeightOffset = 1.0f;
    /// <summary>
    /// Factor to regulate how fast camera reaches desired position on horizontal plane.
    /// </summary>
    [SerializeField]
    private float _springFactor = 1.0f;
    /// <summary>
    /// Factor to regulate how fast camera reaches desired vertical position.
    /// </summary>
    [SerializeField]
    private float _springJumpFactor = 1.0f;
    #endregion
    #region references
    /// <summary>
    /// Reference to camera target object.
    /// </summary>
    [SerializeField]
    private GameObject _targetObject;
    /// <summary>
    /// Reference to Transform of camera target object.
    /// </summary>
    private Transform _targetTransform;
    private float _oldTgRot;
    /// <summary>
    /// Reference to local Transform.
    /// </summary>
    private Transform _myTransform;
    #endregion
    #region properties
    private Vector3 _targetLookAtPosition;
    #endregion
    
 /// <summary>
 /// References initialization
 /// </summary>
 void Start()
    {
        _myTransform = transform;

    }

    private void Update()
    {
        if (_targetObject != null) _oldTgRot = _targetTransform.rotation.y;
    }
    /// <summary>
    /// Updates camera position according to target position. Uses linear interpolation for
    /// smooth approach.
    /// Updates camera rotation according to target position and LookAt offset.
    /// </summary>
    void LateUpdate()
     {
        
        if (_targetObject != null)
        {
            _targetLookAtPosition = _targetTransform.position;
            _targetLookAtPosition.y += _lookAtHeightOffset;

            //_myTransform.Rotate(_targetTransform.rotation.eulerAngles,  Space.World);
            
            _myTransform.LookAt(_targetLookAtPosition);

            if (_oldTgRot != _targetTransform.rotation.y)
            {
                _offset = Quaternion.AngleAxis(_targetTransform.rotation.y, Vector3.up) * _offset;
            }
            

            _myTransform.position =
                Vector3.Lerp(_myTransform.position, _targetLookAtPosition + _offset
                , _springFactor * Time.deltaTime);

            

        }
    }


public void PlayerAssign(GameObject player)
    {
        _targetObject = player;
        _targetTransform = _targetObject.transform;
        
    }
}

