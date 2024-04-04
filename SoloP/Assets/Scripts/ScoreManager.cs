using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public int player1Score = 0;
    public int player2Score = 0;

    public Text player1ScoreText;
    public Text player2ScoreText;
    public Text countdownText;
    public Text winnerText;

    private float countdownDuration = 5f;
    private float gameTime = 10f;
    private float countdownTimer;
    private float gameTimer;
    private bool gameStarted = false;

    void Start()
    {
        countdownTimer = countdownDuration;
        gameTimer = gameTime;
        UpdateScoreUI();
        UpdateCountdownUI();
    }

    void Update()
    {
        if (!gameStarted)
        {
            Countdown();
        }
        else
        {
            UpdateGameTimer();
        }

        if (gameStarted)
        {
            if (Input.GetKeyDown(KeyCode.LeftControl))
            {
                IncreasePlayer1Score();
            }
            else if (Input.GetKeyDown(KeyCode.RightControl))
            {
                IncreasePlayer2Score();
            }
        }
    }

    void Countdown()
    {
        countdownTimer -= Time.deltaTime;
        if (countdownTimer <= 0)
        {
            gameStarted = true;
            countdownText.text = "";
            return;
        }

        UpdateCountdownUI();
    }

    void UpdateGameTimer()
    {
        gameTimer -= Time.deltaTime;
        if (gameTimer <= 0)
        {
            EndGame();
            return;
        }

        UpdateGameTimerUI();
    }

    void UpdateCountdownUI()
    {
        countdownText.text = Mathf.CeilToInt(countdownTimer).ToString();
        if (countdownTimer <= 0)
        {
            StartCoroutine(DisableCountdownUI());
        }
    }

    IEnumerator DisableCountdownUI()
    {
        yield return new WaitForSeconds(5f);
        countdownText.gameObject.SetActive(false);
    }

    void UpdateGameTimerUI()
    {
        player1ScoreText.text = "Player 1 Score: " + player1Score.ToString();
        player2ScoreText.text = "Player 2 Score: " + player2Score.ToString();
        countdownText.text = "Time Left: " + Mathf.CeilToInt(gameTimer).ToString();
    }

    void UpdateScoreUI()
    {
        player1ScoreText.text = "Player 1 Score: " + player1Score.ToString();
        player2ScoreText.text = "Player 2 Score: " + player2Score.ToString();
    }

void EndGame()
{
    if (player1Score > player2Score)
    {
        winnerText.text = "Player 1 Wins!";
    }
    else if (player2Score > player1Score)
    {
        winnerText.text = "Player 2 Wins!";
    }
    else
    {
        winnerText.text = "It's a tie!";
    }
    winnerText.gameObject.SetActive(true);
    gameStarted = false;
}

    public void IncreasePlayer1Score()
    {
        if (gameStarted)
        {
            player1Score++;
            UpdateScoreUI();
        }
        else
        {
            Debug.Log("³¡");
        }
    }

    public void IncreasePlayer2Score()
    {
        if (gameStarted)
        {
            player2Score++;
            UpdateScoreUI();
        }
        else
        {
            Debug.Log("³¡");
        }
    }
}