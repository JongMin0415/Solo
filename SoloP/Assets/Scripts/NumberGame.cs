using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NumberGame : MonoBehaviour
{
    public Text[] numberTexts; // UI Text 요소 배열
    public GameObject gameOverPanel; // 게임 종료 시 활성화할 UI 패널

    private List<int> numbers = new List<int>(); // 1부터 15까지의 숫자 리스트
    private int currentNumber = 1; // 현재 클릭해야 할 숫자의 값

    void Start()
    {
        InitializeNumbers(); // 숫자 초기화
        ShuffleNumbers(); // 숫자 섞기
        SetNumberPositions(); // 숫자 위치 설정
    }

    // 1부터 15까지의 숫자를 리스트에 추가하는 함수
    void InitializeNumbers()
    {
        for (int i = 1; i <= 15; i++)
        {
            numbers.Add(i);
        }
    }

    // 숫자를 랜덤하게 섞는 함수
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

    // 숫자를 UI Text 요소에 배치하는 함수
    void SetNumberPositions()
    {
        for (int i = 0; i < numberTexts.Length; i++)
        {
            numberTexts[i].text = numbers[i].ToString();
        }
    }

    // 숫자 클릭 이벤트 처리 함수
    public void OnNumberClicked(Text clickedText)
    {
        int clickedNumber = int.Parse(clickedText.text); // 클릭된 숫자 가져오기

        // 클릭한 숫자가 현재 클릭해야 할 숫자와 같은지 확인
        if (clickedNumber == currentNumber)
        {
            clickedText.gameObject.SetActive(false); // 클릭한 숫자 숨기기
            currentNumber++; // 다음 숫자로 이동

            // 모든 숫자를 클릭했으면 게임 종료
            if (currentNumber > 15)
            {
                EndGame();
            }
        }
    }

    // 게임 종료 처리 함수
    void EndGame()
    {
        gameOverPanel.SetActive(true); // 게임 종료 UI 활성화
    }
}