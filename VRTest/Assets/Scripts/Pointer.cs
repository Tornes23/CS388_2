using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pointer : MonoBehaviour
{
    private Ray mRay;
    public GameObject mPoint;
    public float mActivationTime = 2.0F;
    GameObject mActivableRef;
    
    // Start is called before the first frame update
    void Start()
    {
        mRay = new Ray();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        RaycastHit hit = new RaycastHit();

        if (CastRay(ref hit))
        {
            GameObject obj = hit.transform.gameObject;
            if (obj.CompareTag("Activable"))
            {
                if (mActivableRef == null || obj != mActivableRef)
                {
                    CancelInvoke("Interact");
                    mActivableRef = obj;
                    Invoke("Interact", mActivationTime);
                }

            }
            else
            {
                mActivableRef = null;
                CancelInvoke("Interact");
            }
        }
        else
        {
            mActivableRef = null;
            CancelInvoke("Interact");
        }
    }

    bool CastRay(ref RaycastHit hit)
    {
        mRay.origin = transform.position;
        mRay.direction = transform.forward;

        if (Physics.Raycast(mRay, out hit, 500.0F))
        {
            mPoint.transform.position = hit.point;
            return true;
        }
        
        return false;
    }

    public void Interact()
    {
        if (mActivableRef != null)
            mActivableRef.SendMessage("Activate", SendMessageOptions.DontRequireReceiver);
    }
}
