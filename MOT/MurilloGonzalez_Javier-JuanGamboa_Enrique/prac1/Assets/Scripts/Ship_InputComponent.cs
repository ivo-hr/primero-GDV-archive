using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship_InputComponent : MonoBehaviour
{
    #region references
    private Ship_MovementController _myShipMovementController;
    private Ship_AttackController _myShipAttackController;
    #endregion

    [SerializeField]
    private float[] _scrLimits = new float[2];

    private Transform _myShipPos;
    // Start is called before the first frame update
    void Start()
    {
        _myShipMovementController = GetComponent<Ship_MovementController>();
        _myShipAttackController = GetComponent<Ship_AttackController>();

        _scrLimits[0] = 7;
        _scrLimits[1] = 5;

        _myShipPos = gameObject.transform;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 movementDirection = Vector3.zero;

        //Movement detection
        if (Input.GetKey(KeyCode.W) && _myShipPos.position.y <= _scrLimits[1])
        {
            movementDirection.y = 1.0f;

        }
        else if (Input.GetKey(KeyCode.S) && _myShipPos.position.y >= -_scrLimits[1])
        {
            movementDirection.y = -1.0f;

        }

        if (Input.GetKey(KeyCode.A) && _myShipPos.position.x >= -_scrLimits[0])
        {
            movementDirection.x = -1.0f;

        }
        else if (Input.GetKey(KeyCode.D) && _myShipPos.position.x <= _scrLimits[0])
        {
            movementDirection.x = 1.0f;

        }

        _myShipMovementController.SetDirection(movementDirection);

        //Attack detection
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _myShipAttackController.Shoot();
        }

    }
}
