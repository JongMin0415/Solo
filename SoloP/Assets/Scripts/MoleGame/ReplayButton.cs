using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReplayButton : MonoBehaviour
{
    void OnMouseDown()
    {
        GameObject.Find ("GameManagerObject").SendMessage ("Start", SendMessageOptions.DontRequireReceiver);
    }
}
