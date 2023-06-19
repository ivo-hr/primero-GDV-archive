using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquadMovementComponent : MonoBehaviour
{
    private float _initialDirection = 1f;
    [SerializeField]
    private float _verticalSpeed;
    [SerializeField]
    private float _horizontalSpeed;
    [SerializeField]
    private float _scrLimits = 7;

    private float _vPos, _hPos;
    private Transform _mySquadTransform;
    // Start is called before the first frame update
    void Start()
    {

        _mySquadTransform = transform;
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        _vPos = _verticalSpeed * -1f * Time.deltaTime + _mySquadTransform.position.y;
        _hPos = _horizontalSpeed * _initialDirection * Time.deltaTime + _mySquadTransform.position.x;

        if (_mySquadTransform.position.x <= -_scrLimits) _initialDirection = +1;

        else if (_mySquadTransform.position.x >= _scrLimits) _initialDirection = -1;

        _mySquadTransform.position = new Vector2(_hPos, _vPos);
    }
}
