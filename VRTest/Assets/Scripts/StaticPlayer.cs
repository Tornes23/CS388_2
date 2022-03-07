using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

static public class StaticPlayer
{
    static private Transform mPlayer;
    static private bool mHasKey = false;

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
}
