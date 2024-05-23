using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAdjuster : MonoBehaviour
{
    public int boardSize = 15;
    private Camera mainCamera;

    void Start()
    {
        mainCamera = Camera.main;
        AdjustCamera();
    }

    public void AdjustCamera()
    {
        if (mainCamera.orthographic)
        {
            mainCamera.orthographicSize = boardSize / 2f;
            mainCamera.transform.position = new Vector3(boardSize / 2f - 0.5f, boardSize / 2f - 0.5f, -10f);
        }
        else
        {
            Debug.LogWarning("Camera is not orthographic. Adjusting position might not work as expected.");
        }
    }
}