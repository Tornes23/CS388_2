using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

static public class StaticPlayer
{
    static private Transform mPlayer;

    static public Transform GetPlayer()
    {
        if (mPlayer == null)
        {
            mPlayer = GameObject.Find("Player").transform;
        }
        return mPlayer;
    }
}
