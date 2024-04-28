using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerlinTreePlacer : MonoBehaviour
{
    public GameObject terrainGameObject;
    
    public float noiseScale;

    public int octaves;
    [Range(0,1)]
    public float persistance;
    public float lacunarity;

    public int seed;
    public Vector2 offset;

    public float treeTreshold;
    public float maxRng;
    public float minRng;
    public int treeSeed;
    public float maxY;
    public float minY;
    public GameObject tree;
    
    public bool autoUpdate;

    public void GenerateMap()
    {
        Terrain terrain = terrainGameObject.GetComponent<Terrain>();
        Vector3 terrainSize = terrain.terrainData.size;
        
        float[,] noiseMap = Noiser.GenerateNoiseMap ((int) terrainSize.x, (int) terrainSize.z, seed, noiseScale, octaves, persistance, lacunarity, offset);

        int width = noiseMap.GetLength (0);
        int height = noiseMap.GetLength (1);
        
        Random.InitState(treeSeed);
        
        // Trees is an empty game object which will hold each individual tree
        GameObject Trees = new GameObject("Trees");

        for (int y = 0; y < height; y++) {
            for (int x = 0; x < width; x++)
            {
                float terrainY = terrain.terrainData.GetHeight(x, y);
                if (terrainY < minY || terrainY > maxY) continue;
                
                // Invert the perlin value to consider blacks as high values
                float perlinValue = 1.0f - noiseMap[x, y];
                
                if (perlinValue < treeTreshold) continue;
                
                // how luckily we will draw a tree
                // convert perlin value from range [0,1] to range [minRng, maxRng]
                // this make sure we are less likely to draw a tree if the perlin value is not high
                float rng = (1.0f - perlinValue) * (maxRng - minRng) + minRng;
                if (Random.Range(0.0f, 1.0f) > rng) continue;
 
                Instantiate(tree, new Vector3(x, terrainY, y), gameObject.transform.rotation, Trees.gameObject.transform);
            }
        }
    }

    void OnValidate() {
        if (lacunarity < 1) {
            lacunarity = 1;
        }
        if (octaves < 0) {
            octaves = 0;
        }
    }
}
