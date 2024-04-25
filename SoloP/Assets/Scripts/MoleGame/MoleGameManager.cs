using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum GameState
{
    Ready,
    Play,
    End
}

public class MoleGameManager : MonoBehaviour
{
    public GameState GS;
    public Hole[] hole;
    public Text scoreText;
    public Text limitText;
    public Text readyText;
    public Text finishText;

    public GameObject ReadyGui;
    public GameObject PlayGui;
    public GameObject finishGui;

    public AudioClip ReadySound;
    public AudioClip PlayGuiSound;
    public AudioClip FiniSound;

    public int score;
    int readyInt;
    float ready;
    float limit;
}
