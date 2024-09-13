using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{

    public CameraOrbitale cameraOrbitale;
    private float z = -10f;
    private float zMax = -5f;
    private float zMin = -15f;
    private float zSpeed = 1.5f;

    private const string MOUSEWHEEL = "Mouse ScrollWheel";
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 position = new Vector3(0f, 0f, z);
        transform.localPosition = position;
    }

    private void LateUpdate()
    {
        z += Input.GetAxis(MOUSEWHEEL) * zSpeed;
        if (z > zMax)
        {
            z = zMax;
        }
        if (z < zMin)
        {
            z = zMin;
        }

    }
}

