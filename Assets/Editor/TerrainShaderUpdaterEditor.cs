using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor (typeof (TerrainShaderUpdater))]
public class TerrainShaderUpdaterEditor : Editor {

	public override void OnInspectorGUI() {
		TerrainShaderUpdater mapGen = (TerrainShaderUpdater)target;

		if (DrawDefaultInspector ()) {
			if (mapGen.autoUpdate) {
				mapGen.updateMaterial();
				EditorUtility.SetDirty(target);
			}
		}
		
		if (GUILayout.Button ("Generate")) {
			mapGen.updateMaterial();
			EditorUtility.SetDirty(target);
		}
	}
}
