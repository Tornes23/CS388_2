using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementButton : MonoBehaviour
{
    void Start()
    {

    }

    public void Activate()
    {
        Debug.Log(StaticPlayer.GetPlayer().name);
        StaticPlayer.GetPlayer().position = new Vector3(transform.position.x, StaticPlayer.GetPlayer().position.y, transform.position.z);
    }
}
