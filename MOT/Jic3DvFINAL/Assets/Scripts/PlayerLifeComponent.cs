using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLifeComponent : MonoBehaviour
{
    #region parameters
    /// <summary>
    /// Initial life for the player
    /// </summary>
    [SerializeField]
    private int _maxLife = 3;
    /// <summary>
    /// Life points lost when player receives damage
    /// </summary>
    [SerializeField]
    private int _hitDamage = 1;
    #endregion
    #region properties
    /// <summary>
    /// Stores current life points
    /// </summary>
    private int _currentLife;
    #endregion
    #region methods
    /// <summary>
    /// Called on collision with other objects.
    /// If collided object is an enemy, the player receives damage.
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<EnemyController>() != null)
        {
            Damage();
            Debug.Log("Ive been hit in my left ball :(");
        }
            
    }
    /// <summary>
    /// Method called when player receives damage.
    /// </summary>
    public void Damage()
    {
        _currentLife -= _hitDamage;
        GameManager.Instance.OnPlayerDamage(_currentLife);
    } 

    /// <summary>
    /// Returns the maximum life to the GameManager
    /// </summary>
    /// <returns>Current player's maximum life</returns>
    public int PlayerMaxLife()
    {
        return _maxLife;
    }
    #endregion
    /// <summary>
    /// Initializes current life of the player
    /// </summary>
    void Start()
    {
        _currentLife = _maxLife;
    }
}
