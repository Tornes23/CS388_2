using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementButton : MonoBehaviour
{
    Transform mPlayer;

    void Start()
    {
        //get static reference
        //mPlayer = Getparen<Transform>();
    }

    public void Activate()
    {
        Debug.Log(mPlayer.name);
        mPlayer.position = transform.position;
    }
}
