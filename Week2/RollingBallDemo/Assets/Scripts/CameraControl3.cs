using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl3 : MonoBehaviour
{
    public List<Transform> cameraPositions = new List<Transform>();

    private int currentPositionIdx = 0;

    public void ChangeCameraPosition(int changeValue)
    {
        currentPositionIdx += changeValue;
        if (currentPositionIdx < 0)
        {
            currentPositionIdx = cameraPositions.Count - 1;
        }
        else if (currentPositionIdx >= cameraPositions.Count)
        {
            currentPositionIdx = 0;
        }

        this.transform.position = cameraPositions[currentPositionIdx].position;
        this.transform.rotation = cameraPositions[currentPositionIdx].rotation;
    }
}
