using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship_InputComponent : MonoBehaviour
{
    #region references
    private Ship_MovementController _myShipMovementController;
    private Ship_AttackController _myShipAttackController;
    #endregion


    // Start is called before the first frame update
    void Start()
    {
        _myShipMovementController = GetComponent<Ship_MovementController>();
        _myShipAttackController = GetComponent<Ship_AttackController>();
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 movementDirection = Vector3.zero;

        //Movement detection
        if (Input.GetKey(KeyCode.W))
        {
            movementDirection.y = 1.0f;

        }
        else if (Input.GetKey(KeyCode.S))
        {
            movementDirection.y = -1.0f;

        }

        if (Input.GetKey(KeyCode.A))
        {
            movementDirection.x = -1.0f;

        }
        else if (Input.GetKey(KeyCode.D))
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
