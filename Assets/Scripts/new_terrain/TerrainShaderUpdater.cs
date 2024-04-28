using System;
using System.Linq;
using UnityEngine;

public class TerrainShaderUpdater : MonoBehaviour
{
    private const int textureSize = 512;
    private const TextureFormat textureFormat = TextureFormat.RGB565;

    public Material material;
    public GameObject terrainGameObject;
    public bool autoUpdate;

    public Layer[] layers;

    public void updateMaterial()
    {
        var terrain = terrainGameObject.GetComponent<Terrain>();
        material.SetInt ("layerCount", layers.Length);
        material.SetColorArray ("baseColours", layers.Select(x => x.tint).ToArray());
        material.SetFloatArray ("baseStartHeights", layers.Select(x => x.startHeight).ToArray());
        material.SetFloatArray ("baseBlends", layers.Select(x => x.blendStrength).ToArray());
        material.SetFloatArray ("baseColourStrength", layers.Select(x => x.tintStrength).ToArray());
        material.SetFloatArray ("baseTextureScales", layers.Select(x => x.textureScale).ToArray());
        Texture2DArray texturesArray = GenerateTextureArray (layers.Select (x => x.texture).ToArray ());
        material.SetTexture ("baseTextures", texturesArray);
        material.SetFloat("minHeight", 0);
        material.SetFloat("maxHeight", terrain.terrainData.size.y);
        
        // Hack Force updating terrain material
        var mat = terrain.materialTemplate;
        terrain.materialTemplate = null;
        terrain.materialTemplate = mat;
    }

    private Texture2DArray GenerateTextureArray(Texture2D[] textures)
    {
        var textureArray = new Texture2DArray(textureSize, textureSize, textures.Length, textureFormat, true);
        for (var i = 0; i < textures.Length; i++) textureArray.SetPixels(textures[i].GetPixels(), i);
        textureArray.Apply();
        return textureArray;
    }

    [Serializable]
    public class Layer
    {
        public Texture2D texture;
        public Color tint;
        [Range(0,1)]
        public float tintStrength;
        [Range(0,1)]
        public float startHeight;
        [Range(0,1)]
        public float blendStrength;
        public float textureScale;
    }
}