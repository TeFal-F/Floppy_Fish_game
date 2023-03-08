using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogicScript : MonoBehaviour
{
    public int playerScore;
    public bool gotNewScore;
    private bool firstTry;
    public Text scoreText;
    public Text highScoreText;
    public GameObject pauseMenu;
    public Player player;
    public bool pauseOn = false;
    public bool gameoverOn = false;
    public GameObject gameStartText;
    public GameObject gameOverScreen;
    public GameObject highestScore;
    public GameObject score;
    [Header("Best Score SFX")]
    [SerializeField] private AudioClip bestScoreSound;

    public void Awake()
    {
        highScoreText.text = PlayerPrefs.GetInt("HighestScore", 0).ToString();
        if (highScoreText.text == "0")
        {
            firstTry = true;
        }
        else
        {
            firstTry = false;
        }
    }
    public void Start()
    {
        gotNewScore = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && player.playerIsAlive)
        {
            if (pauseOn)
            {
                PauseGameOff();
            }
            else
            {
                PauseGameOn();
            }
        }
    }

    public void PauseGameOff()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        pauseOn = false;
    }

    public void PauseGameOn()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        pauseOn = true;
    }

    public void Gameover()
    {
        gameOverScreen.SetActive(true);
        highestScore.SetActive(true);
        //Time.timeScale = 0f;
        gameoverOn = true;
    }

    public void GameoverOff()
    {
        gameOverScreen.SetActive(false);
        highestScore.SetActive(false);
        //Time.timeScale = 1f;
        gameoverOn = false;
        RestartGame();
    }

    [ContextMenu("Increase Number")]
    public void AddScore(int scoreToAdd)
    {
        playerScore += scoreToAdd;
        scoreText.text = playerScore.ToString();
        if (playerScore > PlayerPrefs.GetInt("HighestScore", 0))
        {
            if (gotNewScore == false)
            {
                gotNewScore = true;
                if (firstTry == false)
                {
                    SoundManager.instance.PlaySFX(bestScoreSound);
                }
            }
            PlayerPrefs.SetInt("HighestScore", playerScore);
            highScoreText.text = playerScore.ToString();
        }
    }

    [ContextMenu("Reset Score")]
    public void ResetScore()
    {
        PlayerPrefs.DeleteKey("HighestScore");
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GameStart()
    {
        gameStartText.SetActive(false);
        score.SetActive(true);
        return;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
