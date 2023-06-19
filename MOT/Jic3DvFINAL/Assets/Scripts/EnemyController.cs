using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    #region parameters
    /// <summary>
    /// Maximum spawn height
    /// </summary>
    [SerializeField]
    private float _spawnHeight = 10f;
    #endregion
    #region references
    /// <summary>
    /// Reference to local RigidBody.
    /// </summary>
    private Rigidbody _myRigidBody;
    #endregion
    #region methods
    /// <summary>
    /// Deactivate gravity on enemies.
    /// </summary>
    public void StopEnemy()
    {
        _myRigidBody.useGravity = false;
    }
    /// <summary>
    /// Activates enemy and sets random initial velocity for RigidBody.
    /// </summary>
    public void StartEnemy()
    {
        _myRigidBody.useGravity = true;

        bool forceApplied = false;
        if (!forceApplied)
        {
            _myRigidBody.AddForce(Vector3.down * Random.Range(2, 5));
            forceApplied = true;
        }
    }
    #endregion
    /// <summary>
    /// Initialization includes:
    /// - Registration of Enemy on GameManager.
    /// - Random initial translation.
    /// - References initialization.
    /// - Stopping enemy.
    /// </summary>
    void Start()
    {
        _myRigidBody = GetComponent<Rigidbody>();
        
        
        GameManager.Instance.RegisterEnemy(this);

        transform.position = new Vector3(Random.Range(5, 85), Random.Range(transform.lossyScale.x, 7), Random.Range(-40, 40));

        StopEnemy();
    }
    /// <summary>
    /// Changes the enemy's size
    /// </summary>
    /// <param name="size">Direct number of the resizing</param>
    public void ChangeSize(int size)
    {
        transform.localScale = new Vector3(size, size, size);
    }
}

