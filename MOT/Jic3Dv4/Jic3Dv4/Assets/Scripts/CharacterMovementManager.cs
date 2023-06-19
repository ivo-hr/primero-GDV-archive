using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovementManager : MonoBehaviour
{
    #region parameters
    /// <summary>
    /// Character movement speed
    /// </summary>
    [SerializeField]
    private float _speed = 1.0f;
    /// <summary>
    /// Character vertical jump speed
    /// </summary>
    [SerializeField]
    private float _jumpSpeed = 1.0f;
    /// <summary>
    /// Gravity value applied to player
    /// </summary>
    [SerializeField]
    private float _gravity = 1.0f;
    /// <summary>
    /// Maximum falling speed
    /// </summary>
    [SerializeField]
    private float _fallSpeed = 10.0f;
    /// <summary>
    /// Speed for rotation
    /// </summary>
    [SerializeField]
    private float _rotationSpeed = 1.0f;
    #endregion
    #region references
    /// <summary>
    /// Reference to local transform component
    /// </summary>
    private Transform _myTransform;
    /// <summary>
    /// Reference to local CharacterController component
    /// </summary>
    private CharacterController _myCharacterController;
    #endregion
    #region properties
    /// <summary>
    /// Stores desired movement direction
    /// </summary>
    private Vector3 _movementDirection;
    /// <summary>
    /// Stores desired rotation factor, determined by CharacterInputManager
    /// </summary>
    private float _rotationFactor;
    /// <summary>
    /// Stores current vertical speed value
    /// </summary>
    private float _verticalSpeed;
    #endregion
    #region methods
    /// <summary>
    /// Sets desired direction for player.
    /// </summary>
    /// <param name="horizontal">Right component for desired direction</param>
    /// <param name="vertical">Forward component for desired direction</param>
    public void SetMovementDirection(float horizontal, float vertical)
    {
        _movementDirection = (vertical * _myTransform.right - horizontal * _myTransform.forward) * _speed;
    }
    /// <summary>
    /// Sets desired rotation for the player
    /// </summary>
    /// <param name="rotation">Desired rotation</param>
    public void SetMovementRotation(float rotation)
    {

        transform.Rotate(new Vector3 (0, rotation * _rotationSpeed), Space.Self);
    }

    /// <summary>
    /// Sets _verticalSpeed to _jumpSpeed,
    /// only if Character is grounded.
    /// </summary>
    public void JumpRequest()
    {
        if (_myCharacterController.isGrounded)
        {
            _verticalSpeed = 0; // grounded character has vSpeed = 0...
            if (Input.GetKeyDown("space"))
            { // unless it jumps:
                _verticalSpeed = _jumpSpeed;
            }
        }
    }
    #endregion
    /// <summary>
    /// Initializes references to local components
    /// </summary>
    void Start()
    {
        _myCharacterController = GetComponent<CharacterController>();
        _myTransform = transform;
    }
    /// <summary>
    /// Manages player movement, including translation and gravity
    /// </summary>
    void Update()
    {
        if (_verticalSpeed < _fallSpeed) _verticalSpeed -= _gravity * Time.deltaTime;

        _movementDirection.y = _verticalSpeed;

        _myCharacterController.Move(_movementDirection * Time.deltaTime);
    }

}
