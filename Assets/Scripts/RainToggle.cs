using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainToggle : MonoBehaviour
{

    public GameEvent startRainEvent;
    public GameEvent stopRainEvent;

    public void Toggle(bool enable)
    {
        if (enable)
        {
            startRainEvent.Raise();
            return;
        }
        stopRainEvent.Raise();
    }

}
