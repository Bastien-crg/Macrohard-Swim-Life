﻿using UnityEngine;
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
		float[,] noiseMap = Noiser.GenerateNoiseMap (mapWidth, mapHeight, seed, noiseScale, octaves, persistance, lacunarity, offset);


		MapDisplay display = FindObjectOfType<MapDisplay> ();
		display.DrawNoiseMap (noiseMap);

		TreeMapDisplay treeDisplay = FindObjectOfType<TreeMapDisplay>();
		treeDisplay.DrawTreeNoiseMap(noiseMap);
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
