using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    #region parameters
    /// <summary>
    /// Desired duration for match.
    /// </summary>
    [SerializeField]
    private float _matchDuration = 60.0f;
    #endregion
    #region references
    /// <summary>
    /// Unique GameManager instance (Singleton Pattern).
    /// </summary>
    static private GameManager _instance;
    /// <summary>
    /// Public accesor for GameManager instance.
    /// </summary>
    static public GameManager Instance 
    {
        get
        {
            return _instance;
        }
    }
    
    /// <summary>
    /// Reference to UI Manager.
    /// </summary>
    [SerializeField]
    private UIManager _myUIManager;
    /// <summary>
    /// Reference to player.
    [SerializeField]
    private GameObject _player;
    private GameObject currPlayer;

    [SerializeField]
    private CameraMovementController _cam;
    #endregion
    #region properties
    /// <summary>
    /// List containing all live enemies.
    /// </summary>
    private List<EnemyController> _listOfEnemies;
    /// <summary>
    /// Remaining time to finish match.
    /// </summary>
    private float _timeLeft;
    /// <summary>
    /// Integer version of remaining time to finish match, dispayed on UI.
    /// </summary>
    private int _displayTimeLeft;

    private bool _playing = false;
    #endregion

    #region methods
 /// <summary>
 /// Initializes GameManager instance and list of enemies.
 /// </summary>
 private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }

        
        
    }
    /// <summary>
    /// Public method for enemies to register on Game Manager.
    /// </summary>
    /// <param name="enemyToAdd"></param>
    public void RegisterEnemy(EnemyController enemyToAdd)
    {
        _listOfEnemies.Add(enemyToAdd);
    }
    /// <summary>
    /// Public method to manage enemies death.
    /// </summary>
    /// <param name="deadEnemy"></param>
    public void OnEnemyDies(EnemyController deadEnemy)
    {
        _listOfEnemies.Remove(deadEnemy);
    }
    /// <summary>
    /// Public method to manage player being hurted.
    /// </summary>
    /// <param name="lifePoints"></param>
    public void OnPlayerDamage(int lifePoints)
    {
        //TODO
    }
    /// <summary>
    /// Called on player's victory.
    /// Sets UI Manager accordingly and deactivates player.
    /// </summary>
    private void OnPlayerVictory()
    {
        Destroy(currPlayer);
        _playing = false;
        _myUIManager.SetPlayerVictory(true);
    }

    /// <summary>
    /// Called on player's defeat.
    /// Set UI Manager accordingly, deactivates enemies and player.
    /// </summary>
    public void OnPlayerDefeat()
    {
        Destroy(currPlayer);
        _playing = false;
        _myUIManager.SetGameOver(true);
    }

 /// <summary>
 /// Initializes match.
 /// Activates player and enemies and performs initialization stuff.
 /// </summary>
 public void StartMatch()
    {
        _playing = true;
        
        currPlayer = Instantiate(_player, new Vector3 (10, 10, 10), Quaternion.identity);

        _cam.PlayerAssign(currPlayer);
        //TODO
    }
    /// <summary>
    /// Reloads scene after match.
    /// </summary>
    public void Continue()
    {
        _timeLeft = _matchDuration;
        _playing = false;

        SceneManager.LoadScene("JICScene");

    }
    /// <summary>
    /// Allows to quit game.
    /// </summary>
    public void QuitGame()
    {
        //TODO
    }
    #endregion
    /// <summary>
    /// Finds UI Manager and Player.
    /// Deactivates player and GameManager.
    /// </summary>
    void Start()
    {
        _timeLeft = _matchDuration;

        _playing = false;
        
        //We'll use SerializeField to assign _player and _myUIManager because Find is slow (very slow)
    }
    /// <summary>
    /// Checks victory and defeat conditions, calling required methods.
    /// Updates time on UI Manager.
    /// </summary>
    void Update()
    {
        if (_playing)
        {
            _timeLeft -= Time.deltaTime;
            _myUIManager.UpdateTime((int)(_timeLeft));
        }
    }
}
