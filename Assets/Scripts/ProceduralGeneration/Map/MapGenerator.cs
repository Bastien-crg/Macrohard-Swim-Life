using UnityEngine;
using System.Collections;

public class MapGenerator : MonoBehaviour {

	public int mapWidth;
	public int mapHeight;
	public float noiseScale;

	public int octaves;
	[Range(0,1)]
	public float persistance;
	public float lacunarity;

	public int seed;
	public Vector2 offset;

	public bool autoUpdate;

	public void GenerateMap() {
		Debug.Log(mapWidth + " " + mapHeight + " " + seed + " " + noiseScale + " " + octaves + " " + persistance + " " + lacunarity);
		float[,] n = Noiser.GenerateNoiseMap (mapWidth, mapHeight, seed, noiseScale, octaves, persistance, lacunarity, offset);
		Debug.Log(n[0, 0] + " " + n[0, 1] + " " + n[0, 2] + " " + n[0, 3] + " " + n[0, 4] + " " + n[0, 5] + " " + n[0, 6]);
		Debug.Log(n[1, 0] + " " + n[1, 1] + " " + n[1, 2] + " " + n[1, 3] + " " + n[1, 4] + " " + n[1, 5] + " " + n[1, 6]);
		Debug.Log(n[2, 0] + " " + n[2, 1] + " " + n[2, 2] + " " + n[2, 3] + " " + n[2, 4] + " " + n[2, 5] + " " + n[2, 6]);
		Debug.Log(n[3, 0] + " " + n[3, 1] + " " + n[3, 2] + " " + n[3, 3] + " " + n[3, 4] + " " + n[3, 5] + " " + n[3, 6]);
		Debug.Log(n[4, 0] + " " + n[4, 1] + " " + n[4, 2] + " " + n[4, 3] + " " + n[4, 4] + " " + n[4, 5] + " " + n[4, 6]);


		MapDisplay display = FindObjectOfType<MapDisplay> ();
		display.DrawNoiseMap (n);

		TreeMapDisplay treeDisplay = FindObjectOfType<TreeMapDisplay>();
		treeDisplay.DrawTreeNoiseMap(n);
	}

	void OnValidate() {
		if (mapWidth < 1) {
			mapWidth = 1;
		}
		if (mapHeight < 1) {
			mapHeight = 1;
		}
		if (lacunarity < 1) {
			lacunarity = 1;
		}
		if (octaves < 0) {
			octaves = 0;
		}
	}

}
