using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    Vector3 Angles;
    public float sensitivityX;
    public float sensitivityY;
    public GameObject RightCam;
    public GameObject LeftCam;
    public GameObject PCCam;

    // Start is called before the first frame update
    void Start()
    {
#if UNITY_STANDALONE_WIN
        //GetComponent<GyroscopeControl>().enabled = false;
        RightCam.SetActive(false);
        LeftCam.SetActive(false);
        PCCam.SetActive(true);
#endif

#if UNITY_ANDROID
        GetComponent<GyroscopeControl>().enabled = true;
        RightCam.SetActive(true);
        LeftCam.SetActive(true);
        PCCam.SetActive(false);
#endif
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
