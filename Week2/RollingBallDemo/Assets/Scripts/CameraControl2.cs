using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl2 : MonoBehaviour
{
    public List<Transform> cameraPos = new List<Transform>();
    
    private int currentPositionIdx = 0;

    public void ChangedCameraPosition(int changeValue)
    {
        currentPositionIdx += changeValue;
        if (currentPositionIdx < 0)
        {
            currentPositionIdx = cameraPos.Count - 1;
        }
        else if (currentPositionIdx >= cameraPos.Count)
        {
            currentPositionIdx = 0;
        }

        this.transform.position = cameraPos[currentPositionIdx].position;
        this.transform.rotation = cameraPos[currentPositionIdx].rotation;
    }
}
