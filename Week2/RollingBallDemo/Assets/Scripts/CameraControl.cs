using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public List<Transform> cameraPoints = new List<Transform>();
    public int currentCameraPoint = 0;

    public void ChangeCameraPoint(int changeValue)
    {
        currentCameraPoint += changeValue;
        if (currentCameraPoint < 0) 
        { 
            currentCameraPoint = cameraPoints.Count - 1; 
        }
        else if (currentCameraPoint >= cameraPoints.Count) 
        { 
            currentCameraPoint = 0; 
        }

        this.transform.position = cameraPoints[currentCameraPoint].position;
        this.transform.rotation = cameraPoints[currentCameraPoint].rotation;
    }
}
