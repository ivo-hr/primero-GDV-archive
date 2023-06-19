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
    /// /// <summary>
    /// Stores rotation input
    /// </summary>
    private float _rotationInput;
    [SerializeField]
    private float _shotDelay = 0.5f;
    /// <summary>
    /// Current time since delay
    /// </summary>
    private float _currentShotDel;

    ///<summary>
    ///Camera of the game
    ///</summary>
    private Camera _myCamera;
    #endregion
    /// <summary>
    /// Initializes references
    /// </summary>
    void Start()
    {
        _myCharacterMovementManager = GetComponent<CharacterMovementManager>();
        _myCharacterAttackController = GetComponent<CharacterAttackController>();

        _myCamera = Camera.main;
    }
    /// <summary>
    /// Get input and calls required methods
    /// from components CharacterMovementManager and CharacterAttackController
    /// and controls the delay between shots
    /// </summary>
    void Update()
    {
        _currentShotDel -= Time.deltaTime;
        
        _horizontalInput = Input.GetAxis("Horizontal");
        _verticalInput = Input.GetAxis("Vertical");
        _mouseInput = Input.GetAxis("Fire1");
        _jumpInput = Input.GetAxis("Jump");
        _rotationInput = Input.GetAxis("Strafe");

        _myCharacterMovementManager.SetMovementDirection(_horizontalInput, _verticalInput);
        _myCharacterMovementManager.SetMovementRotation(_rotationInput);

        if (_jumpInput != 0)
        {
            _myCharacterMovementManager.JumpRequest();
        }

        if (_mouseInput != 0 && _currentShotDel < 0)
        {
            _myCharacterAttackController.Shoot(_myCamera.ScreenToWorldPoint(Input.mousePosition + Vector3.forward * _myCamera.farClipPlane));
            _currentShotDel = _shotDelay;
        }
    }

}
