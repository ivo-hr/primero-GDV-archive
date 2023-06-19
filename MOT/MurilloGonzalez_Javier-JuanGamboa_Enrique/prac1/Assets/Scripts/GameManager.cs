using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private bool _isGameRunning;
    static private GameManager _instance;  //TBD

    static public GameManager instance;  //TBD

    [SerializeField]
    private GameObject[] _squads;

    [SerializeField]
    private float sqdSpawnTimer;
    [SerializeField]
    private float sqdSpawnY;
    private float oldTime;
    [SerializeField]
    private float[] sqdSpawnX = new float[2];
    [SerializeField]
    private Text scoreNumber;
    [SerializeField]
    private GameObject Canvas;
    [SerializeField]
    private float bottomLine;
    [SerializeField]
    private GameObject player;
    private int score = 0;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        _isGameRunning = true;
        oldTime = Time.deltaTime;
        Canvas.GetComponent<Canvas>().enabled = false;
        player.SetActive(true);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Time.realtimeSinceStartup > oldTime + sqdSpawnTimer && _isGameRunning)
        {
            Instantiate(_squads[Random.Range(0, _squads.Length)], new Vector3(Random.Range(sqdSpawnX[0], sqdSpawnX[1]), sqdSpawnY, 0), Quaternion.Euler(180, 0 , 0));
            
            oldTime = Time.realtimeSinceStartup;
        }
        
    }

    public void OnEnemyDies(int scoreToAdd)
    {
        score += scoreToAdd;
        
        scoreNumber.text =  "" + score;
    }

    public void OnEnemyReachesBottomLine()
    {
        if (gameObject.transform.position.y <= -bottomLine && _isGameRunning)
        {
            GameOver();
        }
    }
    
    public void OnPlayerDies()
    {
        GameOver();
    }

    private void GameOver()
    {
        Canvas.GetComponent<Canvas>().enabled = true;
        player.SetActive(false);
        _isGameRunning = false;
    }

    
}
