using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneController : MonoBehaviour
{
    [Header("Plane parameters")]
    [Tooltip("How much the throttle ramps up or down")]
    public float throttleIncrement = 0.1f;
    [Tooltip("Maximum engine thrust")]
    public float maxThrust = 200f;
    [Tooltip("How responsive is the plane")]
    public float responsiveness = 10f;

    private float throttle;
    private float roll;
    private float pitch;
    private float yaw;

    private float responseModifier
    {
        get
        {
            return (rb.mass / 10f) * responsiveness;
        }
    }

    Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void HandleInputs()
    {
        roll = Input.GetAxis("Horizontal");
        pitch = Input.GetAxis("Vertical");
        yaw = Input.GetAxis("Yaw");

        if (Input.GetKey(KeyCode.Space)) throttle += throttleIncrement;
        else if (Input.GetKey(KeyCode.LeftControl)) throttle -= throttleIncrement;
        throttle = Mathf.Clamp(throttle, 0, maxThrust);

    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        HandleInputs();
    }

    private void FixedUpdate()
    {
        Debug.Log(transform.right);
        
        rb.AddForce(transform.forward * maxThrust * throttle);
        rb.AddTorque(transform.up * yaw * responsiveness);
        rb.AddTorque(transform.right * pitch * responsiveness);
        rb.AddTorque(transform.forward * roll * responsiveness);

    }
}
