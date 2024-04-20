using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeMapDisplay : MonoBehaviour
{
    public Renderer textureRender;

    public float treeTreshold;
    public float maxRng;
    public float minRng;
    public int seed;
    
    
    public void DrawTreeNoiseMap(float[,] noiseMap) {
        int width = noiseMap.GetLength (0);
        int height = noiseMap.GetLength (1);

        Texture2D texture = new Texture2D (width, height);

        Random.InitState(seed);
        
        Color[] colourMap = new Color[width * height];
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

                colourMap[y * width + x] = Color.green;
            }
        }
        texture.SetPixels (colourMap);
        texture.Apply ();

        textureRender.sharedMaterial.mainTexture = texture;
        textureRender.transform.localScale = new Vector3 (width, 1, height);
    }
}
