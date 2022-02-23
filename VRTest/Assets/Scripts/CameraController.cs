using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    Vector3 Angles;
    public float sensitivityX;
    public float sensitivityY;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(1))
        {
            float rotationY = Input.GetAxis("Mouse Y") * sensitivityX;
            float rotationX = Input.GetAxis("Mouse X") * sensitivityY;
            if (rotationY > 0)
            { 
                Angles = new Vector3(Mathf.MoveTowards(Angles.x, -80, rotationY), Angles.y + rotationX, 0);
            }
            else
            { 
                Angles = new Vector3(Mathf.MoveTowards(Angles.x, 80, -rotationY), Angles.y + rotationX, 0);transform.localEulerAngles = Angles;
            }
        }
        
    }
}
