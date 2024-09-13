using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraOrbitale : MonoBehaviour
{

    private float x = 0f;
    private float y = 1f;
    private float yMax = 60f;
    private float yMin = -2f;

    private const string MOUSEX = "Mouse X";
    private const string MOUSEY = "Mouse Y";
   

    public Deplacement deplacement;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = deplacement.transform.position ;
    }

    private void LateUpdate()
    {

        if (Input.GetMouseButton(0)) 
        {
            x += Input.GetAxis(MOUSEX);
            y += Input.GetAxis(MOUSEY);
            if (y > yMax)
            {
                y = yMax;
            }
            if (y < yMin)
            {
                y = yMin;
            }

            Quaternion rotation = Quaternion.Euler(y, x, 0);
            transform.rotation = rotation;
        }

        if (Input.GetMouseButton(1))
        {
            x += Input.GetAxis(MOUSEX);
            y += Input.GetAxis(MOUSEY);
            if (y > yMax)
            {
                y = yMax;
            }
            if (y < yMin)
            {
                y = yMin;
            }
            Quaternion rotation = Quaternion.Euler(y, x, 0);
            transform.rotation = rotation;
            Vector3 camera = transform.forward;
            camera = new Vector3(camera.x, 0f, camera.z);
            deplacement.transform.forward = camera;

        }

    }
}
