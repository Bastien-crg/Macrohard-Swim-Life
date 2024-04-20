using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor (typeof (PerlinTreePlacer))]
public class PerlinTreePlacerEditor : Editor {

	public override void OnInspectorGUI() {
		PerlinTreePlacer mapGen = (PerlinTreePlacer)target;

		if (DrawDefaultInspector ()) {
			if (mapGen.autoUpdate) {
				mapGen.GenerateMap ();
			}
		}

		if (GUILayout.Button ("Generate")) {
			mapGen.GenerateMap ();
		}
	}
}
