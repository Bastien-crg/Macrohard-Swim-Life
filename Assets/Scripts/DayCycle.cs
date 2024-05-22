using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class DayCycle : MonoBehaviour
{

    public Light DirectionalLight;
    public LightingPreset Preset;
    [Range(0, 100)]
    public float TimeOfDay;

    private void Update()
    {
        if (Preset == null)
        {
            return;
        }
        if (Application.isPlaying)
        {
            TimeOfDay += Time.deltaTime;
            TimeOfDay %= 100;
            UpdateLighting(TimeOfDay / 100f);
        } 
        else
        {
            UpdateLighting(TimeOfDay / 100f);


        }
    }

    private void UpdateLighting(float timePercent)
    {
        RenderSettings.ambientLight = Preset.AmbientColor.Evaluate(timePercent);
        RenderSettings.fogColor = Preset.FogColor.Evaluate(timePercent);

        if (DirectionalLight != null)
        {
            DirectionalLight.color = Preset.DirectionColor.Evaluate(timePercent);
            DirectionalLight.intensity = Preset.LightIntensity.Evaluate(timePercent);
            DirectionalLight.transform.localRotation = Quaternion.Euler(new Vector3((timePercent * 360f) - 90f, 170f, 0f));
        }
    }


    /*private void OnValidate()
    {
        if (DirectionalLight != null)
        {
            return;
        }
        if (RenderSettings.sun != null)
        {
            DirectionalLight = RenderSettings.sun;
        }
        else
        {
            Light[] lights = GameObject.FindObjectOfType<Light>();
        }
    }*/


    /*private float duration = 1.0f;
    private Color color0 = Color.white;
    private Color color1 = Color.red;
    public float speed = 100.0f;
    private Vector3 angle;
    private float rotation = 0f;
    public enum Axis
    {
        X,
        Y,
        Z
    }
    public Axis axis = Axis.X;
    public bool direction = true;
    private Light lt;

    void Start()
    {
        angle = transform.localEulerAngles;
        lt = this.GetComponent<Light>();
    }

    void Update()
    {
        switch (axis)
        {
            case Axis.X:
                transform.localEulerAngles = new Vector3(Rotation(), angle.y, angle.z);
                break;
            case Axis.Y:
                transform.localEulerAngles = new Vector3(angle.x, Rotation(), angle.z);
                break;
            case Axis.Z:
                transform.localEulerAngles = new Vector3(angle.x, angle.y, Rotation());
                break;
        }
        float t = Mathf.PingPong(Time.time, duration) / duration;
        lt.color = Color.Lerp(color0, color1, t);
    }

    float Rotation()
    {
        rotation += speed * Time.deltaTime;
        if (rotation >= 360f)
            rotation -= 360f; // this will keep it to a value of 0 to 359.99...
        return direction ? rotation : -rotation;
    }*/
}
