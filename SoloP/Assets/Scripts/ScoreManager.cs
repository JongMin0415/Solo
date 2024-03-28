using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ScoreManager : MonoBehaviour
{
    public int player1Score = 0;
    public int player2Score = 0;

    public Text player1ScoreText; // �÷��̾� 1�� ���ھ ǥ���� UI Text ���
    public Text player2ScoreText; // �÷��̾� 2�� ���ھ ǥ���� UI Text ���
    public Text countdownText; // ī��Ʈ�ٿ��� ǥ���� UI Text ���

    private float countdownDuration = 5f; // ī��Ʈ�ٿ� �ð�
    private float gameTime = 10f; // ���� ���� �ð�
    private float countdownTimer; // ���� ī��Ʈ�ٿ� �ð�
    private float gameTimer; // ���� ���� �ð�

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
        // ���� ���� �� ���ھ� ��
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
        // ���� ����� �Ǵ� ���� ���� �߰�
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