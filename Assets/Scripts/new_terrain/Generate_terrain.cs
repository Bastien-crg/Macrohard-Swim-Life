using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class MakeTerrain : MonoBehaviour
{
    public float frequency = 0.1f;
    public float amplitude = 300;
    public int octaves = 6;
    public float lacunarity = 2.0f;
    public float persistence = 0.5f;


    [ContextMenu("Change Ground !")]
    void Start()
    {
        
        Perlin surface = new Perlin();
        Mesh mesh = this.GetComponent<MeshFilter>().mesh;
        Vector3[] vertices = mesh.vertices;
        Debug.Log(vertices.Length);
        for (int i = 0; i < octaves; i++)
        {
            for (int v = 0; v < vertices.Length; v++)
            {
                vertices[v].y += surface.Noise(
                vertices[v].x * frequency,
                vertices[v].z * frequency) * amplitude;
            }
            frequency *= lacunarity;
            amplitude *= persistence;
        }
        mesh.vertices = vertices;
        mesh.RecalculateBounds();
        mesh.RecalculateNormals();
        GetComponent<MeshCollider>().sharedMesh = mesh;
    }
}
