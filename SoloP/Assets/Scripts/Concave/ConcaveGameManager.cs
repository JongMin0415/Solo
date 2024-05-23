using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConcaveGameManager : MonoBehaviour
{
    public GameObject blackStonePrefab;
    public GameObject whiteStonePrefab;
    private bool isBlackTurn = true;
    private BoardManager boardManager;
    public Text winText;

    void Start()
    {
        boardManager = FindObjectOfType<BoardManager>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2Int gridPoint = new Vector2Int(Mathf.RoundToInt(worldPoint.x), Mathf.RoundToInt(worldPoint.y));

            if (IsValidMove(gridPoint))
            {
                PlaceStone(gridPoint);

                if (CheckForWin(gridPoint))
                {
                    string winner = isBlackTurn ? "Black" : "White";  // winner 변수 정의
                    Debug.Log(winner + " wins!");
                    ShowWinMessage(winner);  // winner 변수 전달
                }

                isBlackTurn = !isBlackTurn;
            }
        }
    }

    bool IsValidMove(Vector2Int point)
    {
        if (point.x < 0 || point.x >= boardManager.boardSize || point.y < 0 || point.y >= boardManager.boardSize)
            return false;

        return boardManager.cells[point.x, point.y].transform.childCount == 0;
    }

    void PlaceStone(Vector2Int point)
    {
        GameObject stonePrefab = isBlackTurn ? blackStonePrefab : whiteStonePrefab;
        Instantiate(stonePrefab, new Vector3(point.x, point.y, 0), Quaternion.identity, boardManager.cells[point.x, point.y].transform);
    }

    bool CheckForWin(Vector2Int point)
    {
        return CheckDirection(point, Vector2Int.right) + CheckDirection(point, Vector2Int.left) + 1 >= 5 ||
               CheckDirection(point, Vector2Int.up) + CheckDirection(point, Vector2Int.down) + 1 >= 5 ||
               CheckDirection(point, new Vector2Int(1, 1)) + CheckDirection(point, new Vector2Int(-1, -1)) + 1 >= 5 ||
               CheckDirection(point, new Vector2Int(1, -1)) + CheckDirection(point, new Vector2Int(-1, 1)) + 1 >= 5;
    }

    int CheckDirection(Vector2Int start, Vector2Int direction)
    {
        int count = 0;
        Vector2Int checkPoint = start + direction;
        while (IsValidPoint(checkPoint) && HasSameStone(checkPoint))
        {
            count++;
            checkPoint += direction;
        }
        return count;
    }

    bool IsValidPoint(Vector2Int point)
    {
        return point.x >= 0 && point.x < boardManager.boardSize && point.y >= 0 && point.y < boardManager.boardSize;
    }

    bool HasSameStone(Vector2Int point)
    {
        if (boardManager.cells[point.x, point.y].transform.childCount > 0)
        {
            GameObject stone = boardManager.cells[point.x, point.y].transform.GetChild(0).gameObject;
            return (isBlackTurn && stone.CompareTag("BlackStone")) || (!isBlackTurn && stone.CompareTag("WhiteStone"));
        }
        return false;
    }

    void ShowWinMessage(string winner)
    {
        winText.text = winner + " wins!";
        winText.gameObject.SetActive(true);
    }
}