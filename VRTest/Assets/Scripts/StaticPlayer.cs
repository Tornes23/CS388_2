using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

static public class StaticPlayer
{
    static private Transform mPlayer;
    static private bool mHasKey = false;
    static private Vector3 mLeftCamPos;
    static private Vector3 mRightCamPos;
    static private float mFishEyeEffect = 0.65F;

    static public Transform GetPlayer()
    {
        if (mPlayer == null)
        {
            mPlayer = GameObject.Find("Player").transform;
        }
        return mPlayer;
    }

    static public void PickedKey(bool to_set) { mHasKey = to_set; }
    static public bool HasKey() { return mHasKey; }

    static public void SetFishEye(float value)
    {
        mFishEyeEffect = value;
    }
    static public float GetFishEye() { return mFishEyeEffect; }
    static public Vector3 GetLCamPos() { return mLeftCamPos; }
    static public Vector3 GetRCamPos() { return mRightCamPos; }
    static public void SetCamPos(Vector3 left, Vector3 right)
    {
        mLeftCamPos = left;
        mRightCamPos = right;
    }
}
