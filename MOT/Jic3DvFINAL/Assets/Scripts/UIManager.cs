using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    #region references
    /// <summary>
    /// Reference to object containing Text Component to display number of live enemies.
    /// </summary>
    [SerializeField]
    private GameObject _enemiesLeftObject;
    /// <summary>
    /// Text Component to display number of live enemies.
    /// </summary>
    private Text _enemiesLeftText;
    /// <summary>
    /// Reference to object containing Text Component to display remaining match time.
    /// </summary>
    [SerializeField]
    private GameObject _timeDisplayObject;
    /// <summary>
    /// Text Component to display remaining match time.
    /// </summary>
    private Text _timeDisplayText;
    /// <summary>
    /// Reference to object containint Text Component to display player's life points.
    /// </summary>
    [SerializeField]
    private GameObject _playerLifeObject;
    /// <summary>
    /// Text Component to display player's life points.
    /// </summary>
    private Text _playerLifeText;
    /// <summary>
    /// Reference to object containing Main Menu objects
    /// </summary>
    [SerializeField]
    private GameObject _mainMenu;
    /// <summary>
    /// Reference to object containing Game Over objects
    /// </summary>
    [SerializeField]
    private GameObject _gameOver;
    /// <summary>
    /// Reference to object containing objects for Player's Victory
    /// </summary>
    [SerializeField]
    private GameObject _playerVictory;
    /// <summary>
    /// Reference to object containing Continue Button
    /// </summary>
    [SerializeField]
    private GameObject _continueButton;
    #endregion
    #region methods
    /// <summary>
    /// Updates number of remaining enemies
    /// </summary>
    /// <param name="newEnemiesLeft"></param>
    public void UpdateEnemiesLeft(int newEnemiesLeft)
    {
        _enemiesLeftText.text = "malos: " + newEnemiesLeft;
    }
    /// <summary>
    /// Updates displayed remaining time.
    /// </summary>
    /// <param name="newTime">Current time to be displayed.</param>
    public void UpdateTime(int newTime)
    {
        _timeDisplayText.text = "tiempo: " + newTime;
    }
    /// <summary>
    /// Updates displayer player's life points.
    /// </summary>
    /// <param name="newLife">Current life points to be displayed.</param>
    public void UpdatePlayerLife(int newLife)
    {
        _playerLifeText.text = "vida: " + newLife;
    }

    /// <summary>
    /// Allows to activate and deactivate Game Over menu.
    /// </summary>
    /// <param name="enabled">New active state for Game Over menu.</param>
    public void SetGameOver(bool enabled)
    {
        _gameOver.SetActive(enabled);
        _continueButton.SetActive(enabled);
    }
    /// <summary>
    /// Allows to activate and deactivate Player's victory menu.
    /// </summary>
    /// <param name="enabled">New active state for Player's Victory menu.</param>
    public void SetPlayerVictory(bool enabled)
    {
        _playerVictory.SetActive(enabled);
        _continueButton.SetActive(enabled);
    }
    /// <summary>
    /// Allows to activate and deactivate Main menu.
    /// </summary>
    /// <param name="enabled">New active state for Main menu.</param>
    public void SetMainMenu(bool enabled)
    {
        _mainMenu.SetActive(enabled);
    }
    /// <summary>
    /// Allows to activate or deactivate Continue button.
    /// </summary>
    /// <param name="enabled">New active state for Continue button.</param>
    public void SetContinueButton(bool enabled)
    {
        _continueButton.SetActive(enabled);
    }
    /// <summary>
    /// Calls Game Manager method to Quit Game.
    /// </summary>
    public void QuitGame()
    {
        GameManager.Instance.QuitGame();
    }
    /// <summary>
    /// Calls Game Manager method to Start Match.
    /// </summary>
    public void StartMatch()
    {
        Debug.Log("Start: ive been called!");
        _mainMenu.SetActive(false);
        GameManager.Instance.StartMatch();
    }
    /// <summary>
    /// Calls Game Manager method to Continue to a new match.
    /// </summary>
    public void Continue()
    {
        _continueButton.SetActive(false);
        SetGameOver(false);
        SetPlayerVictory(false);
        SetPlayerVictory(false);
        
        SetMainMenu(true);
        GameManager.Instance.Continue();
    }
    /// <summary>
    /// Initializes own references.
    /// </summary>
    private void Awake()
    {
        _enemiesLeftText = _enemiesLeftObject.GetComponent<Text>();
        _timeDisplayText = _timeDisplayObject.GetComponent<Text>();
        _playerLifeText = _playerLifeObject.GetComponent<Text>();
        _mainMenu.SetActive(true);
        _continueButton.SetActive(false);
    }
    #endregion
}
