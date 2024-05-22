using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class Perlin_noise_terrain : MonoBehaviour
{
    // Start is called before the first frame update

    public int depth = 20;

    public int width = 256;
    public int height = 256;

    public float frequency = 20f;

    public float offsetX = 100f;
    public float offsetY = 100f;

    public float lacunarity;
    public float persistance;
    public float amplitude;
    public int octaves;

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


  

    TerrainData GenerateTerrain(TerrainData terrainData)
    {
        terrainData.heightmapResolution = width ;
        terrainData.size = new Vector3(width, depth, height);
        terrainData.SetHeights(0, 0, GenerateHeights());
        return terrainData;
    }

    float[,] GenerateHeights()
    {
        float[,] noiseMap = Noiser.GenerateNoiseMap(width, height, seed, frequency, octaves, persistance, lacunarity, new Vector2(offsetX,offsetY));
        Debug.Log(noiseMap);
        return noiseMap;
    }


    /*float[,] GenerateHeights()
    {
        float[,] heights = new float[width, height];
        for (int i = 0; i < octaves; i++)
        {
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    heights[x, y] += CalculateHeight(x, y);
                }
            }
            frequency *= lacunirity;
            amplitude *= persistence;
        }
        
        
        return heights;
    }*/

    float CalculateHeight (int x, int y)
    {
        float xCoord = (float) x / width * frequency + offsetX;
        float yCoord = (float) y / height * frequency + offsetY;
        return Mathf.PerlinNoise(xCoord, yCoord)*amplitude;
    }

    /*public int mapWidth;
    public int mapHeight;
    public float noiseScale;

    public int octaves;
    [Range(0, 1)]
    public float persistance;
    public float lacunarity;

    public int seed;
    public Vector2 offset;

    public bool autoUpdate;

    public void GenerateMap()
    {
        float[,] noiseMap = Noise.GenerateNoiseMap(mapWidth, mapHeight, seed, noiseScale, octaves, persistance, lacunarity, offset);


        MapDisplay display = FindObjectOfType<MapDisplay>();
        display.DrawNoiseMap(noiseMap);
    }*/

    

}
