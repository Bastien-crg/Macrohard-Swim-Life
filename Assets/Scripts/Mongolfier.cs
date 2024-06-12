using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mongolfier : MonoBehaviour
{

    public ParticleSystem particleSystem;
    public GameObject mesh;
    // Start is called before the first frame update
    void Start()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        var emission = particleSystem.emission;
        emission.enabled = true;
        particleSystem.Play();
        mesh.SetActive(false);
        Invoke(nameof(DestroyObj),2);
    }

    void DestroyObj()
    {
        Destroy(gameObject);
    }
}
