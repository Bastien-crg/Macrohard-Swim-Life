using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class Perlin_noise_terrain : MonoBehaviour
{
    // Start is called before the first frame update

    public int depth = 20;

    public int width = 256;
    public int height = 256;

    public float scale = 20f;

    public float offsetX = 100f;
    public float offsetY = 100f;

    public int seed;

    public bool use_seed = true;

    public GameEvent LoadTerrrainMat;

    void Start()
    {
        // Start's code has been moved in awake because terrain has to be modified before we place trees
        LoadTerrrainMat.Raise();
    }

    private void Awake()
    {
        if (use_seed) Random.InitState(seed);
        offsetX = Random.Range(0f, 9999f);
        offsetY = Random.Range(0f, 9999f);
        Terrain terrain = GetComponent<Terrain>();
        terrain.terrainData = GenerateTerrain(terrain.terrainData);
    }


    float[,] airportArea(float[,] heights)
    {
        for (int i = 0; i < 80; i++)
        {
            for (int j = 0; j < 340; j++)
            {
                heights[width/2+i, width/2+j] = 0.55f;
            }
        }
        return heights;
    }

    TerrainData GenerateTerrain(TerrainData terrainData)
    {
        terrainData.heightmapResolution = width + 1;
        terrainData.size = new Vector3(width, depth, height);
        terrainData.SetHeights(0, 0, GenerateHeights());
        return terrainData;
    }

    float[,] GenerateHeights()
    {
        float[,] heights = new float[width, height];
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                heights[x, y] = CalculateHeight(x, y);
            }
        }
        return heights;
    }

    float CalculateHeight (int x, int y)
    {
        float xCoord = (float) x / width * scale + offsetX;
        float yCoord = (float) y / height * scale + offsetY;
        return Mathf.PerlinNoise(xCoord, yCoord);
    }
    
}
