using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMenuInputsTemp : MonoBehaviour
{
    public GameEvent pauseEvent;

    private void Update()
    {
        if (Input.GetKeyDown("escape"))
        {
            Debug.Log("pressed escape");
            pauseEvent.Raise();
        }
    }
    
}
