using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementButton : MonoBehaviour
{
    Transform mPlayer;
    public float mWalkingTime;
    void Start()
    {
        mPlayer = StaticPlayer.GetPlayer();
    }

    public void Activate()
    {
        LeanTween.move(mPlayer.gameObject, new Vector3(transform.position.x, mPlayer.position.y, transform.position.z), mWalkingTime);
    }
}
