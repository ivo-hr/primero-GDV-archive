using UnityEngine;

public class CharacterAttackController : MonoBehaviour
{
    #region parameters
    /// <summary>
    /// Force applied to enemy when shot impacts
    /// </summary>
    [SerializeField]
    private float _impactForce = 100.0f;
    #endregion
    #region references
    /// <summary>
    /// Reference to self Transform
    /// </summary>
    private Transform _myTransform;
    /// <summary>
    /// Reference to object that will act as source of the shots
    /// </summary>
    [SerializeField]
    private GameObject _shotOriginObject;
    /// <summary>
    /// Reference to the transform of the object that will act as source of the shots
    /// </summary>
    private Transform _shotOriginTransform;
    #endregion
    #region properties
    /// <summary>
    /// LayerMask used for enemies detection.
    /// </summary>
    private LayerMask _myLayerMask;
    /// <summary>
    /// The RaycastHit necessary to use Raycasts
    /// </summary>
    private RaycastHit _hit;
    /// <summary>
    /// The source point of the raycast
    /// </summary>
    private Vector3 _originPoint;
    /// <summary>
    /// The object which Raycast hits
    /// </summary>
    private GameObject _victim;
    /// <summary>
    /// Direction of the raycast
    /// </summary>
    private Vector3 _dirOfRay;
    #endregion
    #region methods
    /// <summary>
    /// Tries to shot a target from origin point. Causes damage and applies force to target
    ///if successful.
    /// </summary>
    /// <param name="originPoint">Shoot origin point</param>
    /// <param name="targetPoint">Shoot target point</param>
    public void Shoot(Vector3 targetPoint)
    {
        bool forceApplied = false;
        
        _originPoint = _shotOriginTransform.position;

        _dirOfRay = targetPoint - _originPoint;

        if (Physics.Raycast(_originPoint, _dirOfRay, out _hit, Camera.main.farClipPlane, _myLayerMask))
        {
            _victim = _hit.collider.gameObject;

            if (!forceApplied)
            {
                _hit.rigidbody.AddForce((_dirOfRay.normalized + Vector3.up) * _impactForce);
                forceApplied = true;
            }

            _victim.GetComponent<EnemyLifeComponent>().Damage();
        }
    }
    /// <summary>
    /// Called by the GameManager when the player is created
    /// </summary>
    public void OriginObjAssign(GameObject originObj)
    {
        _shotOriginObject = originObj;
        _shotOriginTransform = _shotOriginObject.transform;
    }
    #endregion

 /// <summary>
 /// LayerMask and Camera initialization
 /// </summary>
 void Start()
    {
        _myTransform = transform;
        _myLayerMask = LayerMask.GetMask("Enemy");
    }
}