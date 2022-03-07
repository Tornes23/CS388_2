using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadingBar : MonoBehaviour
{
    bool mbVisible;
    Image mBar;
    public Text mPercentage;
    public Text mDescription;
    float mTimer;
    float mMaxTime;

    // Start is called before the first frame update
    void Start()
    {
        mBar = GetComponent<Image>();
        mBar.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (mbVisible)
        {
            mTimer += Time.deltaTime;
            mBar.fillAmount = mTimer / mMaxTime;
            float percentage = mBar.fillAmount * 100.0F;
            mPercentage.text = percentage.ToString();
        }
    }

    public void Activate()
    {
        mBar.enabled = true;
        mbVisible = true;
        mTimer = 0.0F;
    }

 
}
