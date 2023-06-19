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
    private CharacterAttackController _myCharacterAttackController;
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
    /// <summary>
    /// Stores jump input
    /// </summary>
    private float _jumpInput;
    /// <summary>
    /// Delay between shots
    /// </summary>
    [SerializeField]
    private float _shotDelay = 0.5f;
    private float _currentShotDel;
    #endregion
    /// <summary>
    /// Initializes references
    /// </summary>
    void Start()
    {
        _myCharacterMovementManager = GetComponent<CharacterMovementManager>();
        _myCharacterAttackController = GetComponent<CharacterAttackController>();
    }
    /// <summary>
    /// Get input and calls required methods
    /// from components CharacterMovementManager and CharacterAttackController
    /// </summary>
    void Update()
    {
        _currentShotDel -= Time.deltaTime;
        
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
        if (_mouseInput != 0 && _currentShotDel < 0)
        {
            
            Debug.Log("mouse pressed in pos:" + Input.mousePosition);
            _myCharacterAttackController.Shoot(Camera.main.ScreenToWorldPoint(Input.mousePosition + Vector3.forward * 1000));
            _currentShotDel = _shotDelay;
        }
    }

}
