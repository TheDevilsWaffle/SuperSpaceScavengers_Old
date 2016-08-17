using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public enum ButtonStatus { Active, Inactive, OnHover, Disabled };

public class ButtonBase : MonoBehaviour
{
    [HideInInspector]
    public ButtonStatus currentStatus = ButtonStatus.Inactive;

    protected Vector3 pos
    {
        get { return transform.localPosition ; }
        set { transform.localPosition = value; }
    }
    protected Vector3 sca
    {
        get { return transform.localScale; }
        set { transform.localScale = value; }
    }
    protected Quaternion rot
    {
        get { return transform.localRotation; }
        set { transform.localRotation = value; }
    }
    protected Vector3 posOriginal
    {
        get { return transform.position; }
    }
    protected Vector3 scaOriginal
    {
        get { return transform.localScale; }
    }
    protected Quaternion rotOriginal
    {
        get { return transform.localRotation; }
    }
    public string levelToLoad;
    public Canvas canvasToLoad;
    public float delayBeforeLoad = 2.0f;

    [Header("BUTTON")]
    public Color buttonColor_Active;
    public Color buttonColor_Inactive;
    public Color buttonColor_OnHover;
    public Color buttonColor_Disabled;
    [HideInInspector]
    public Image buttonImage;
    
    [Header("TEXT")]
    public Color textColor_Active;
    public Color textColor_Inactive;
    public Color textColor_OnHover;
    public Color textColor_Disabled;
    [HideInInspector]
    public Text buttonText;

    [Header("ANIMATION")]
    public AnimationBase buttonAnimations;

    [Header("NODE MAP")]
    public ButtonBase up;
    public ButtonBase right;
    public ButtonBase down;
    public ButtonBase left;

    [HideInInspector]
    public bool isActive;

    protected virtual void Awake()
    {
        sca = gameObject.transform.localScale;
        rot = gameObject.transform.localRotation;
    }
    protected virtual void Start(){}
    public virtual void Active()
    {
        currentStatus = ButtonStatus.Active;
        buttonAnimations.ButtonActive(buttonImage, buttonText, textColor_Active, buttonColor_Active, posOriginal, scaOriginal, rotOriginal);
    }
    public virtual void Inactive()
    {
        currentStatus = ButtonStatus.Inactive;
        buttonAnimations.ButtonInactive(buttonImage, buttonText, textColor_Inactive, buttonColor_Inactive, posOriginal, scaOriginal, rotOriginal);       
    }
    public virtual void OnHover()
    {
        currentStatus = ButtonStatus.OnHover;
        buttonAnimations.ButtonOnHover(buttonImage, buttonText, textColor_OnHover, buttonColor_OnHover, posOriginal, scaOriginal, rotOriginal);
    }
    public virtual void Disabled()
    {
        currentStatus = ButtonStatus.Disabled;
        buttonAnimations.ButtonDisabled(buttonImage, buttonText, textColor_Disabled, buttonColor_Disabled, posOriginal, scaOriginal, rotOriginal);
    }

}
