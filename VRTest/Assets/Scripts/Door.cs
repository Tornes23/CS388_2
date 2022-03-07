using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    bool mbOpen = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(mbOpen && transform.position.y <= 10.0F)
            transform.position += new Vector3(0.0F, 0.01f, 0.0F);
    }

    public void Activate()
    {
        if(StaticPlayer.HasKey())
            mbOpen = true;
    }
}
