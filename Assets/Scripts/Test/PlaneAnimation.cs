﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneAnimation : MonoBehaviour {

    public Transform propeller;
    public float propSpeed = 100;

    public float smoothTime = .5f;
    [Header ("Aileron (Roll)")]
    public Transform aileronLeft;
    public Transform aileronRight;
    public float aileronMax = 20;
    [Header ("Elevator (Pitch)")]
    public Transform elevator;
    public float elevatorMax = 20;
    [Header ("Rudder (Yaw)")]
    public Transform rudder;
    public float rudderMax = 20;

    // Smoothing vars
    float smoothedRoll;
    float smoothRollV;
    float smoothedPitch;
    float smoothPitchV;
    float smoothedYaw;
    float smoothYawV;

    Plane plane;
    AircratController ACControlller;

    void Start () {
        plane = GetComponent<Plane> ();
        ACControlller = GetComponent<AircratController>();
    }

    void Update () {
        // https://en.wikipedia.org/wiki/Aircraft_principal_axes
        // propeller.Rotate (Vector3.forward * propSpeed * Time.deltaTime);
        propeller.Rotate(Vector3.forward * ACControlller.EnginePower*2 * Time.deltaTime);

        // Roll
        // float targetRoll = plane.Roll;
        float targetRoll = ACControlller.inputRoll;
        smoothedRoll = Mathf.SmoothDamp (smoothedRoll, targetRoll, ref smoothRollV, Time.deltaTime * smoothTime);
        aileronLeft.localEulerAngles = new Vector3 (-smoothedRoll * aileronMax, aileronLeft.localEulerAngles.y, aileronLeft.localEulerAngles.z);
        aileronRight.localEulerAngles = new Vector3 (smoothedRoll * aileronMax, aileronRight.localEulerAngles.y, aileronRight.localEulerAngles.z);

        // Pitch
        // float targetPitch = plane.Pitch;
        float targetPitch = ACControlller.inputPitch;
        smoothedPitch = Mathf.SmoothDamp (smoothedPitch, targetPitch, ref smoothPitchV, Time.deltaTime * smoothTime);
        elevator.localEulerAngles = new Vector3 (-smoothedPitch * elevatorMax, elevator.localEulerAngles.y, elevator.localEulerAngles.z);

        // Yaw
        //float targetYaw = plane.Yaw;
        float targetYaw = ACControlller.inputYaw;
        smoothedYaw = Mathf.SmoothDamp (smoothedYaw, targetYaw, ref smoothYawV, Time.deltaTime * smoothTime);
        rudder.localEulerAngles = new Vector3 (rudder.localEulerAngles.x, -smoothedYaw * rudderMax, rudder.localEulerAngles.z);
    }
}