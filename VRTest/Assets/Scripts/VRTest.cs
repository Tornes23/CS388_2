using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.ImageEffects;

public class VRTest : MonoBehaviour
{
    public GameObject mCanvas;

    private bool test = false;
    private float maxTime = 5.0f;
    private float time = 0.0f;


    public GameObject RightCamera;
    public GameObject LeftCamera;
    private Fisheye rightFish;
    private Fisheye leftFish;
    public Slider mSliderXY;
    public Slider mSliderDistance;

    // Start is called before the first frame update
    void Start()
    {
        Input.gyro.enabled = true;

        rightFish = RightCamera.GetComponent<Fisheye>();
        leftFish  = LeftCamera.GetComponent<Fisheye>();
    }

    // Update is called once per frame
    void Update()
    {
        //string text;
        //text = "Att: " + Input.gyro.attitude + "\n";
        //text += "Gra: " + Input.gyro.gravity + "\n";
        //text += "Acc: " + Input.acceleration;
        //DebugLog.DrawDebugText(text);

        rightFish.strengthX = mSliderXY.value;
        rightFish.strengthY = mSliderXY.value;
        leftFish.strengthX = mSliderXY.value;
        leftFish.strengthY = mSliderXY.value;

        RightCamera.transform.localPosition = new Vector3(mSliderDistance.value, RightCamera.transform.localPosition.y, RightCamera.transform.localPosition.z);
        LeftCamera.transform.localPosition = new Vector3(-(mSliderDistance.value), LeftCamera.transform.localPosition.y, LeftCamera.transform.localPosition.z);

        if (test)
        {
            time += Time.deltaTime;
            if (time >= maxTime)
            {
                GoBack();
            }
        }

    }

    public void Done()
    {
        mCanvas.SetActive(false);
    }

    public void Test()
    {
        mCanvas.SetActive(false);
        test = true;
        time = 0.0f;
    }

    private void GoBack()
    {
        mCanvas.SetActive(true);
        test = false;
    }
}
