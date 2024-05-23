using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardManager : MonoBehaviour
{
    public int boardSize = 15;
    public GameObject cellPrefab;
    public GameObject[,] cells;

    void Start()
    {
        cells = new GameObject[boardSize, boardSize];
        float cellSize = 1.0f;  // 셀의 크기
        for (int x = 0; x < boardSize; x++)
        {
            for (int y = 0; y < boardSize; y++)
            {
                GameObject cell = Instantiate(cellPrefab, new Vector3(x * cellSize, y * cellSize, 0), Quaternion.identity);
                cell.transform.SetParent(transform);
                cells[x, y] = cell;
            }
        }

        // 카메라 조정
        CameraAdjuster cameraAdjuster = FindObjectOfType<CameraAdjuster>();
        if (cameraAdjuster != null)
        {
            cameraAdjuster.boardSize = boardSize;
            cameraAdjuster.AdjustCamera();
        }
    }
}