using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    #region references
    /// <summary>
    /// Reference to local component CharacterMovementManager
    /// </summary>
    //private CharacterMovementManager _myCharacterMovementManager;
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
    #endregion
    /// <summary>
    /// Initializes references
    /// </summary>
    void Start()
    {
        //TODO
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
    }

}
