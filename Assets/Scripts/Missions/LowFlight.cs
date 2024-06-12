using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Slider = UnityEngine.UI.Slider;

public class LowFlight : MonoBehaviour
{
    public Transform playerPosition;
    public float rayLength;
    public LayerMask collisionLayer;

    public float maxScoreGain;
    public float minScoringHeight;

    public TextMeshProUGUI scoreValueTMP;
    public Slider scoreSlider;
    
    private Vector3 rayDirection = new Vector3(0, -1, 0);
    private float score = 0;

    private bool hasCrashed = false;
    public GameEvent endEvent;

    private void Start()
    {
        scoreSlider.minValue = 0;
        scoreSlider.maxValue = minScoringHeight;
    }

    private void FixedUpdate()
    {
        if (hasCrashed) return;
        
        RaycastHit hitInfo;
        bool hasHit = Physics.Raycast(playerPosition.position, rayDirection, out hitInfo, rayLength, collisionLayer);
        if (!hasHit) return;

        if (hitInfo.distance > minScoringHeight) return;
        score += ComputeScore(hitInfo.distance);
        
        scoreSlider.value = minScoringHeight - hitInfo.distance;
        scoreValueTMP.text = score.ToString("N0");
    }

    private float ComputeScore(float distance)
    {
        if (distance > minScoringHeight) return 0;
        float rawScore = maxScoreGain * (1 - (distance / minScoringHeight));
        return Time.fixedDeltaTime * rawScore;
    }

    public void OnPlaneCollision(Component sender, object data)
    {
        hasCrashed = true;
        endEvent.Raise(null, "You crashed with a score of " + score);
    }
}