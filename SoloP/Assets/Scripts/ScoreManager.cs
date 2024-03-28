using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ScoreManager : MonoBehaviour
{
    public int player1Score = 0;
    public int player2Score = 0;

    public Text player1ScoreText; // 플레이어 1의 스코어를 표시할 UI Text 요소
    public Text player2ScoreText; // 플레이어 2의 스코어를 표시할 UI Text 요소
    public Text countdownText; // 카운트다운을 표시할 UI Text 요소

    private float countdownDuration = 5f; // 카운트다운 시간
    private float gameTime = 10f; // 게임 진행 시간
    private float countdownTimer; // 현재 카운트다운 시간
    private float gameTimer; // 현재 게임 시간

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
        // 게임 종료 후 스코어 비교
        if (player1Score > player2Score)
        {
            Debug.Log("Player 1 Wins!");
        }
        else if (player2Score > player1Score)
        {
            Debug.Log("Player 2 Wins!");
        }
        else
        {
            Debug.Log("It's a tie!");
        }
        // 게임 재시작 또는 종료 로직 추가
    }

    public void IncreasePlayer1Score()
    {
        if (gameStarted)
        {
            player1Score++;
            UpdateScoreUI();
        }
    }

    public void IncreasePlayer2Score()
    {
        if (gameStarted)
        {
            player2Score++;
            UpdateScoreUI();
        }
    }
}