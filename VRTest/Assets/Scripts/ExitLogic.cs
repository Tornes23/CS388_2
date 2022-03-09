using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class ExitLogic : MonoBehaviour
{
    public Image mBlack;
    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Activate()
    {
        mBlack.gameObject.SetActive(true);
        LeanTween.alpha(mBlack.rectTransform, 1.0F, 1.0F).setEase(LeanTweenType.linear).setOnComplete(FadeFinished);
    }

    void FadeFinished()
    {
        SceneManager.LoadScene("WinScreen");
    }
}
