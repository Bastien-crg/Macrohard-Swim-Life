using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneCollision : MonoBehaviour
{
    public GameEvent collisionEvent;
    public int layer;
    private void OnCollisionEnter(Collision other)
    {
        if (layer != other.gameObject.layer) return;
        collisionEvent.Raise();
    }
}
