using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerlinTreePlacer : MonoBehaviour
{
    public int terrainWidth;
    public int terrainHeight;
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
    public GameObject tree;
    
    public bool autoUpdate;

    public void GenerateMap()
    {
        //TODO Gather terrain size from the terrain
        float[,] noiseMap = Noiser.GenerateNoiseMap (terrainWidth, terrainHeight, seed, noiseScale, octaves, persistance, lacunarity, offset);

        int width = noiseMap.GetLength (0);
        int height = noiseMap.GetLength (1);
        
        Random.InitState(treeSeed);
        
        for (int y = 0; y < height; y++) {
            for (int x = 0; x < width; x++)
            {
                // Invert the perlin value to consider blacks as high values
                float perlinValue = 1.0f - noiseMap[x, y];
                
                if (perlinValue < treeTreshold) continue;
                
                // how luckily we will draw a tree
                // convert perlin value from range [0,1] to range [minRng, maxRng]
                // this make sure we are less likely to draw a tree if the perlin value is not high
                float rng = (1.0f - perlinValue) * (maxRng - minRng) + minRng;
                if (Random.Range(0.0f, 1.0f) > rng) continue;
 
                // TODO Gather Y from x and y of the terrain
                // TODO set Y min and max limitations
                Instantiate(tree, new Vector3(x, 0, y), gameObject.transform.rotation);
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
