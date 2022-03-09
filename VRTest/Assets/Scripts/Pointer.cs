using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pointer : MonoBehaviour
{
    private Ray mRay;
    public GameObject mPoint;
    public float mActivationTime = 2.0F;
    public float mTimer = 0.0F;
    GameObject mActivableRef;
    public GameObject mBackBar;
    public GameObject mBar;

    // Start is called before the first frame update
    void Start()
    {
        mRay = new Ray();
        mBackBar.SetActive(false);
        mBar.SetActive(false);
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
                
                if(mActivableRef != null && obj == mActivableRef)
                {
                    mTimer += Time.deltaTime;
                    if (mTimer <= mActivationTime)
                    {
                        mBar.transform.localScale = new Vector3(mTimer / mActivationTime, 0.2F, mTimer / mActivationTime);
                    }
                    else
                        mTimer = 0.0F;
                }

            }
            else
            {
                mActivableRef = null;
                CancelInvoke("Interact");
                mBackBar.SetActive(false);
                mBar.SetActive(false);
            }
        }
        else
        {
            mActivableRef = null;
            CancelInvoke("Interact");
            mBackBar.SetActive(false);
            mBar.SetActive(false);
        }
    }

    bool CastRay(ref RaycastHit hit)
    {
        mRay.origin = transform.position;
        mRay.direction = transform.forward;

        if (Physics.Raycast(mRay, out hit, 500.0F))
        {
            mPoint.transform.position = hit.point;
            mPoint.transform.LookAt(transform.position);

            if (mActivableRef == null || hit.transform.gameObject != mActivableRef)
            {
                mBackBar.SetActive(true);
                mBar.SetActive(true);
                mTimer = 0.0F;
                mBar.transform.localScale = new Vector3(0, 0.2F, 0);
            }

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
