using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundGenerator : MonoBehaviour
{

    private int chunk_number_border = 3;
    private List<GameObject> chunk_list = new List<GameObject>();
    public Material ground_material;

    public float frequency = 0.1f;
    public float amplitude = 300;
    public int octaves = 6;
    public float lacunarity = 2.0f;
    public float persistence = 0.5f;
    public GameObject chunk_prefab;

    // Start is called before the first frame update
    void Start()
    {

        Perlin surface = new Perlin();


        for (int i = 0; i < chunk_number_border; i++)
        {
            for (int j = 0; j < chunk_number_border; j++)
            {



                GameObject chunk = GameObject.Instantiate(chunk_prefab) as GameObject;
                var mesh = chunk.GetComponent<MeshFilter>().mesh;
                Vector3 chunk_pos = new Vector3(j * 500, 0, i * 500);
                chunk.transform.localPosition = chunk_pos;
                Vector3[] vertices = mesh.vertices;

                for (int v = 0; v < 11; v++)
                {
                    for (int k = 0; k < 11; k++)
                    {
                        vertices[v*11+k].y += Mathf.PerlinNoise(v   * frequency, k *   frequency) * amplitude;
                        //Debug.Log("x : " + (v + j * 11) + " z : " + (k + i * 11));
                        //Debug.Log((v * 11 + k));
                    }
                    /*vertices[v].y += surface.Noise(vertices[v].x+j*9   * frequency, vertices[v].z+i*9   * frequency) * amplitude;
                    Debug.Log("x : " + (vertices[v].x + j * 10)  + " z : " + (vertices[v].z + i * 10));*/
                }

                /*for (int k = 0; k < octaves; k++)
                {
                    for (int v = 0; v < vertices.Length; v++)
                    {
                        vertices[v].y += surface.Noise(
                        vertices[v].x * frequency,
                        vertices[v].z * frequency) * amplitude;
                    }
                    frequency *= lacunarity;
                    amplitude *= persistence;
                }*/
                mesh.vertices = vertices;
                mesh.RecalculateBounds();
                mesh.RecalculateNormals();
                //GetComponent<MeshCollider>().sharedMesh = mesh;


                
                
                chunk_list.Add(chunk);
                //Instantiate(chunk);

            }
        }


        
        //var mesh = chunk_list[0].GetComponent<MeshFilter>().mesh;
        //Vector3[] vertices = mesh.vertices;
        
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
