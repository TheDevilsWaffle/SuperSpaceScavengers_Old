/*////////////////////////////////////////////////////////////////////////
//SCRIPT: cs_SplashScreenController.cs
//AUTHOR: Travis Moore
////////////////////////////////////////////////////////////////////////*/

#pragma warning disable 0168 // variable declared but not used.
#pragma warning disable 0219 // variable assigned but not used.
#pragma warning disable 0414 // private field assigned but not used.

using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class cs_SplashScreenController : MonoBehaviour
{
    #region PROPERTIES

    //references
    public GameObject SplashScreenImage;
    public Sprite[] Array_SplashImages;

    [Header("SPLASH ANIMATION")]
    public float FadeTime;
    public float ScaleInFactor;
    public float ScaleInTime;

    [Header("SKIP SPLASH SCREEN CONTROLS")]
    KeyCode KBSkipKey = KeyCode.A;

    //attributes
    private Vector3 SplashScreenOriginalScale;
    private int CurrentImage;
    private int TotalImages;
    private float Timer;

    #endregion

    #region INITIALIZATION

    /*////////////////////////////////////////////////////////////////////
    //FUNCTION: Awake()
    ////////////////////////////////////////////////////////////////////*/
    void Awake()
    {
        if(SplashScreenImage == null)
        {
            Debug.LogWarning("SplashScreenImage is not set, please set GameObject in Inspector");
        }
    }

    /*////////////////////////////////////////////////////////////////////
    //FUNCTION: Start()
    ////////////////////////////////////////////////////////////////////*/
    void Start()
    {
        //initialize CurrentImage
        CurrentImage = 0;
        SplashScreenOriginalScale = SplashScreenImage.transform.localScale;

        //how many images in the array?
        TotalImages = Array_SplashImages.Length;

        SplashScreenImage.GetComponent<Image>().sprite = Array_SplashImages[0];

        //everything is set, start animating splashscreen
        AnimateFadeIn();
        AnimateScaleIn();
    }

    #endregion

    #region X_FUNCTIONS

    /*////////////////////////////////////////////////////////////////////
    //FUNCTION: AnimateFadeIn()
    ////////////////////////////////////////////////////////////////////*/
    void AnimateFadeIn()
    {
        print("AnimateFadeIn");
        LeanTween.alphaCanvas(SplashScreenImage.GetComponent<CanvasGroup>(), 1f, FadeTime).setOnComplete(AnimateFadeOut);
    }

    /*////////////////////////////////////////////////////////////////////
    //FUNCTION: AnimateScaleIn(GameObject)
    ////////////////////////////////////////////////////////////////////*/
    void AnimateScaleIn()
    {
        print("AnimateScaleIn");
        LeanTween.scale(SplashScreenImage.GetComponent<RectTransform>(), (SplashScreenImage.transform.localScale * ScaleInFactor), ScaleInTime).setOnComplete(EvaluateSplashScreensRemaining);
    }

    /*////////////////////////////////////////////////////////////////////
    //FUNCTION: AnimateFadeOut()
    ////////////////////////////////////////////////////////////////////*/
    void AnimateFadeOut()
    {
        print("AnimateFadeOut");
        LeanTween.alphaCanvas(SplashScreenImage.GetComponent<CanvasGroup>(), 0f, FadeTime).setDelay(FadeTime * 2);
    }

    #endregion

    #region ANIMATION

    /*////////////////////////////////////////////////////////////////////
    //FUNCTION: EvaluateSplashScreensRemaining()
    ////////////////////////////////////////////////////////////////////*/
    void EvaluateSplashScreensRemaining()
    {
        print("EvaluateSplashScreensRemaining");
        ++CurrentImage;
        if (CurrentImage < TotalImages)
        {
            ResetSplashScreenScale();
            print("CurrentImage number is now " + CurrentImage);
            SplashScreenImage.GetComponent<Image>().sprite = Array_SplashImages[CurrentImage];
            AnimateFadeIn();
            AnimateScaleIn();
        }

        else
        {
            print("NEXT LEVEL");
        }
    }

    /*////////////////////////////////////////////////////////////////////
    //FUNCTION: ResetSplashScreenScale()
    ////////////////////////////////////////////////////////////////////*/
    void ResetSplashScreenScale()
    {
        print("ResetSplashScreenScale");
        SplashScreenImage.transform.localScale = SplashScreenOriginalScale;
        SplashScreenImage.GetComponent<CanvasGroup>().alpha = 0f;
    }

    #endregion
}