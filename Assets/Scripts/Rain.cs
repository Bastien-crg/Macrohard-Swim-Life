using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rain : MonoBehaviour
{
    public Transform target;
    public float offsetY;

    // Update is called once per frame
    void Update()
    {
        transform.position = target.transform.position + new Vector3(0, offsetY, 0);
    }
}
