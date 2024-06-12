using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{

    public ParticleSystem particleSystem;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Destroy()
    {
        Instantiate(particleSystem, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
