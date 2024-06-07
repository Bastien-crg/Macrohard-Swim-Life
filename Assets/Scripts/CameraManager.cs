using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public GameObject cameraGO;
    public GameObject thirdPersonCameraController;
    public GameObject WindShield;
    public Transform[] cameraPositions;
    public int[] fixedCamerasIndexes;
    public int firstPersonCamerasIndex;
    private int currentCamera;

    
    
    private void NextCamera()
    {
        currentCamera = (currentCamera + 1) % cameraPositions.Length;
        
        thirdPersonCameraController.SetActive(!fixedCamerasIndexes.Contains(currentCamera));
        WindShield.SetActive(currentCamera != firstPersonCamerasIndex);
        
        cameraGO.transform.position = cameraPositions[currentCamera].position;
        cameraGO.transform.rotation = cameraPositions[currentCamera].rotation;
    }
    
    // Start is called before the first frame update
    void Start()
    {
        currentCamera = -1; // next camera will set the camera 0
        NextCamera();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("r"))
        {
            NextCamera();
        }
    }
}
