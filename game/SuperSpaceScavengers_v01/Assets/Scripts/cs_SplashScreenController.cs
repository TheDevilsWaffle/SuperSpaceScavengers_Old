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
    public float PersistDuration;
    public float FadeInDuration;
    public float FadeOutDuration;

    [Header("SKIP SPLASH SCREEN CONTROLS")]
    KeyCode KBSkipKey = KeyCode.A;

    //attributes
    private int CurrentImage;
    private int TotalImages;
    private float Timer;
    private bool SplashScreenIsAnimating;


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
        SplashScreenIsAnimating = false;

        //how many images in the array?
        TotalImages = Array_SplashImages.Length;

        SplashScreenImage.GetComponent<Image>().sprite = Array_SplashImages[0];
    }

    #endregion

    #region UPDATE

    /*////////////////////////////////////////////////////////////////////
    //FUNCTION: Update()
    ////////////////////////////////////////////////////////////////////*/
    void Update()
    {
        //only update if we have splash images to show
        if (TotalImages > 0 && !SplashScreenIsAnimating)
        {
            //is timer > PersistDuration
            if (Timer > PersistDuration)
                FadeOutSplashScreen();

            //update timer
            Timer += Time.deltaTime;
        }
        else
            Debug.LogWarning("There are no splash images to show");
    }

    #endregion

    #region X_FUNCTIONS

    /*////////////////////////////////////////////////////////////////////
    //FUNCTION: FadeOutSplashScreen()
    ////////////////////////////////////////////////////////////////////*/
    void FadeOutSplashScreen()
    {
        SplashScreenIsAnimating = true;
        LeanTween.alphaCanvas(SplashScreenImage.GetComponent<CanvasGroup>(), 0f, FadeOutDuration).setOnComplete(FadeInSplashScreen);
    }

    /*////////////////////////////////////////////////////////////////////
    //FUNCTION: FadeInSplashScreen()
    ////////////////////////////////////////////////////////////////////*/
    void FadeInSplashScreen()
    {
        ++CurrentImage;
        if (CurrentImage < TotalImages)
        {
            SplashScreenImage.GetComponent<Image>().sprite = Array_SplashImages[CurrentImage];
            LeanTween.alphaCanvas(SplashScreenImage.GetComponent<CanvasGroup>(), 1f, FadeInDuration).setOnComplete(ResetTimer);
        }

        else
            print("NEXT LEVEL");

    }

    /*////////////////////////////////////////////////////////////////////
    //FUNCTION: ResetTimer()
    ////////////////////////////////////////////////////////////////////*/
    void ResetTimer()
    {
        Timer = 0f;
        SplashScreenIsAnimating = false;
    }

    /*////////////////////////////////////////////////////////////////////
    //FUNCTION: FUNC_04()
    ////////////////////////////////////////////////////////////////////*/
    void FUNC_04()
    {
        //CONTENT HERE
    }

    /*////////////////////////////////////////////////////////////////////
    //FUNCTION: FUNC_05()
    ////////////////////////////////////////////////////////////////////*/
    void FUNC_05()
    {
        //CONTENT HERE
    }

    #endregion

    #region ANIMATION

    /*////////////////////////////////////////////////////////////////////
    //FUNCTION: FUNC_06()
    ////////////////////////////////////////////////////////////////////*/
    void FUNC_06()
    {
        //CONTENT HERE
    }

    /*////////////////////////////////////////////////////////////////////
    //FUNCTION: FUNC_07()
    ////////////////////////////////////////////////////////////////////*/
    void FUNC_07()
    {
        //CONTENT HERE
    }

    #endregion
}