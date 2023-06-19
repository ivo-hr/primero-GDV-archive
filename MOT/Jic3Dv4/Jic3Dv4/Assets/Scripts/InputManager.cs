using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    #region references
    /// <summary>
    /// Reference to local component CharacterMovementManager
    /// </summary>
    private CharacterMovementManager _myCharacterMovementManager;
    /// <summary>
    /// Reference to local component CharacterAttackController
    /// </summary>
    //private CharacterAttackController _myCharacterAttackController;
    #endregion
    #region properties
    /// <summary>
    /// Stores horizontal input
    /// </summary>
    private float _horizontalInput;
    /// <summary>
    /// Stores vertical input
    /// </summary>
    private float _verticalInput;
    /// <summary>
    /// Stores mouse input
    /// </summary>
    private float _mouseInput;

    private float _jumpInput;
    #endregion
    /// <summary>
    /// Initializes references
    /// </summary>
    void Start()
    {
        _myCharacterMovementManager = GetComponent<CharacterMovementManager>();
    }
    /// <summary>
    /// Get input and calls required methods
    /// from components CharacterMovementManager and CharacterAttackController
    /// </summary>
    void Update()
    {
        _horizontalInput = Input.GetAxis("Horizontal");
        _verticalInput = Input.GetAxis("Vertical");
        _mouseInput = Input.GetAxis("Fire1");
        _jumpInput = Input.GetAxis("Jump");

        _myCharacterMovementManager.SetMovementDirection(_horizontalInput, _verticalInput);
        _myCharacterMovementManager.SetMovementRotation(Input.GetAxis("Strafe"));

        if (_jumpInput != 0)
        {
            _myCharacterMovementManager.JumpRequest();
        }
    }

}
