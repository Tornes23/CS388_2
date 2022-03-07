using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pointer : MonoBehaviour
{
    private Ray mRay;
    public GameObject mPoint;
    public float mActivationTime = 2.0F;
    GameObject mActivableRef;
    public GameObject mBar;
    
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
                    CancelInvoke("ActivateBar");
                    mActivableRef = obj;
                    Invoke("Interact", mActivationTime);
                    Invoke("ActivateBar", 0.0F);
                }

            }
            else
            {
                mActivableRef = null;
                CancelInvoke("Interact");
                CancelInvoke("ActivateBar");
            }
        }
        else
        {
            mActivableRef = null;
            CancelInvoke("Interact");
            CancelInvoke("ActivateBar");
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

    public void ActivateBar()
    {
        mBar.SendMessage("Activate", SendMessageOptions.DontRequireReceiver);
    }
}
