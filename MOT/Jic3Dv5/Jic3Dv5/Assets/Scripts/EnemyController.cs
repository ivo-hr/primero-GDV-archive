using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
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

        //transform.position = new Vector3(Random.Range());
    }
}

