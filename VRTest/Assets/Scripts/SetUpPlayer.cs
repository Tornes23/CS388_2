using System.Collections;
using System.Collections.Generic;
using UnityStandardAssets.ImageEffects;
using UnityEngine;

public class SetUpPlayer : MonoBehaviour
{
    public GameObject mLeftCam;
    public GameObject mRightCam;
    public Fisheye mLeftFish;
    public Fisheye mRightFish;
    // Start is called before the first frame update
    void Start()
    {
        mLeftCam.transform.localPosition = StaticPlayer.GetLCamPos();
        mRightCam.transform.localPosition = StaticPlayer.GetRCamPos();

        float value = StaticPlayer.GetFishEye();
        mRightFish.strengthX = value;
        mRightFish.strengthY = value;
        mLeftFish.strengthX = value;
        mLeftFish.strengthY = value;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
