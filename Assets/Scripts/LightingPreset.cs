using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName ="Lighting Preset", menuName ="Scriptable/Lighting Preset", order =1)]
public class LightingPreset : ScriptableObject
{
    public Gradient AmbientColor;
    public Gradient DirectionColor;
    public Gradient FogColor;
    public AnimationCurve LightIntensity;
}
