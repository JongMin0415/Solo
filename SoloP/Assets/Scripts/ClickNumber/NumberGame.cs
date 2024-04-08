using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NumberGame : MonoBehaviour
{
    public Text[] numberTexts; // UI Text ��� �迭
    public GameObject gameOverPanel; // ���� ���� �� Ȱ��ȭ�� UI �г�

    private List<int> numbers = new List<int>(); // 1���� 15������ ���� ����Ʈ
    private int currentNumber = 1; // ���� Ŭ���ؾ� �� ������ ��

    void Start()
    {
        InitializeNumbers(); // ���� �ʱ�ȭ
        ShuffleNumbers(); // ���� ����
        SetNumberPositions(); // ���� ��ġ ����
    }

    // 1���� 15������ ���ڸ� ����Ʈ�� �߰��ϴ� �Լ�
    void InitializeNumbers()
    {
        for (int i = 1; i <= 15; i++)
        {
            numbers.Add(i);
        }
    }

    // ���ڸ� �����ϰ� ���� �Լ�
    void ShuffleNumbers()
    {
        for (int i = 0; i < numbers.Count; i++)
        {
            int temp = numbers[i];
            int randomIndex = Random.Range(i, numbers.Count);
            numbers[i] = numbers[randomIndex];
            numbers[randomIndex] = temp;
        }
    }

    // ���ڸ� UI Text ��ҿ� ��ġ�ϴ� �Լ�
    void SetNumberPositions()
    {
        for (int i = 0; i < numberTexts.Length; i++)
        {
            numberTexts[i].text = numbers[i].ToString();
        }
    }

    // ���� Ŭ�� �̺�Ʈ ó�� �Լ�
    public void OnNumberClicked(Text clickedText)
    {
        int clickedNumber = int.Parse(clickedText.text); // Ŭ���� ���� ��������

        // Ŭ���� ���ڰ� ���� Ŭ���ؾ� �� ���ڿ� ������ Ȯ��
        if (clickedNumber == currentNumber)
        {
            clickedText.gameObject.SetActive(false); // Ŭ���� ���� �����
            currentNumber++; // ���� ���ڷ� �̵�

            // ��� ���ڸ� Ŭ�������� ���� ����
            if (currentNumber > 15)
            {
                EndGame();
            }
        }
    }

    // ���� ���� ó�� �Լ�
    void EndGame()
    {
        gameOverPanel.SetActive(true); // ���� ���� UI Ȱ��ȭ
    }
}