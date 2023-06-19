using UnityEngine;

public class GizmoController : MonoBehaviour
{
    #region references
    /// <summary>
    /// Reference to Transform of Main Camera.
    /// </summary>
    private Transform _cameraTransform;
    /// <summary>
    /// Reference to own Transform.
    /// </summary>
    private Transform _myTransform;
    #endregion
    #region properties
    /// <summary>
    /// Store own initial rotation.
    /// </summary>
    Quaternion _initialRotation;
    #endregion

    /// <summary>
    /// Finds Main Camera and initializes references.
    /// </summary>
    void Start()
    {
        _cameraTransform = Camera.main.transform;

        _myTransform = transform;

        _initialRotation = _myTransform.rotation;
    }
    /// <summary>
    /// Positions life text in front of own object, according to camera.
    /// Uses lookat method to make it look at camera.
    /// </summary>
    void Update()
    {
        _myTransform.LookAt(_cameraTransform);

        _myTransform.localPosition = (_cameraTransform.position - GetComponentInParent<Transform>().position).normalized * 0.5f;
    }
}
