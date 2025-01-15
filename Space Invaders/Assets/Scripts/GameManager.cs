using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance {get; private set;}

    public Player player;

    public TMP_Text playerLivesText;
    public int playerScore {get; private set;}
    public TMP_Text playerScoreText;
    public int highScore {get; private set;}
    public TMP_Text highScoreText;
    public TMP_Text gameStateText;
    public GameObject gameOverScreen;
    public GameObject newScoreText;
    public GameObject pausePanel;

    private bool _pauseGame;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        pausePanel.SetActive(false);
        newScoreText.SetActive(false);
        gameOverScreen.SetActive(false);
        LoadHighScore();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Pause") && !_pauseGame)
        {
            Time.timeScale = 0;
            pausePanel.SetActive(true);
            _pauseGame = true;
        }
        else if (Input.GetButtonDown("Pause") && _pauseGame)
        {
            Time.timeScale = 1;
            pausePanel.SetActive(false);
            _pauseGame = false;
        }
        
    }

    public void GameOver()
    {
        gameOverScreen.SetActive(true);
        if (Enemy.enemyCount == 0)
        {
            gameStateText.text = "YOU WON!!!";
            AudioManager.Instance.PlayWinSFX();
        }
        else if (player.PlayerDied)
        {
            gameStateText.text = "YOU LOSE...";
            AudioManager.Instance.PlayLoseSFX();
        }
        if (playerScore > highScore)
        {
            highScore = playerScore;
            highScoreText.text = highScore.ToString();
            newScoreText.SetActive(true);
            SaveHighScore();
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void PlayerScores(int score)
    {
        SetPlayerScore(playerScore + score);
    }

    public void SetPlayerHealth(int hp)
    {
        playerLivesText.text = hp.ToString();
    }
    private void SetPlayerScore(int score)
    {
        playerScore = score;
        playerScoreText.text = playerScore.ToString();
        if (Enemy.enemyCount == 0)
        {
            GameOver();
        }
    }

    private void SaveHighScore()
    {
        PlayerPrefs.SetInt("HighScore", highScore);
    }

    private void LoadHighScore()
    {
        highScore = PlayerPrefs.GetInt("HighScore");
        highScoreText.text = highScore.ToString();
    }

        
}
