using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MoleState
{
    Ready,
    none,
    Open,
    Idle,
    Close,
    Catch
}

public class Hole : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        switch(MS){
            case MoleState.None:
            None_Ing();
            break;
            case MoleState.Open:
            Open_Ing();
            break;
            case MoleState.Idle:
            Idle_Ing();
            break;
            case MoleState.Close:
            Close_Ing();
            break;
        }
    }

    public void None_On()
    {
        AniCount = 0;
        MS + MoleState.None;

        timeForCount = 0;
        timeToWait = Randomge (1.0f, 3.0f);
        if(!active){
            Ms = MoleState.Ready;
        }
    }

    public void OnMouseDown()
    {
        if(Ms == MoleState.Idle || MS == MoleState.Open) {
            Catch_On();
        }
    }
}
