using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pointer : MonoBehaviour
{
    private Ray mRay;
    public GameObject mPoint;
    
    // Start is called before the first frame update
    void Start()
    {
        mRay = new Ray();
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        mRay.origin = transform.position;
        mRay.direction = transform.forward;
        Debug.DrawRay(mRay.origin, mRay.direction, Color.red, 1000.0f);

        if (Physics.Raycast(mRay, out hit))
        {
            if (hit.collider != null && hit.collider.tag != mPoint.tag)
            {
                mPoint.transform.position = hit.point;
            }
        }

    }
}
