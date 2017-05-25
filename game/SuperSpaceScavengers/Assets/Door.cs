///////////////////////////////////////////////////////////////////////////////////////////////////
//AUTHOR — Travis Moore
//SCRIPT — Door.cs
///////////////////////////////////////////////////////////////////////////////////////////////////

//#pragma warning disable 0169
//#pragma warning disable 0649
//#pragma warning disable 0108
//#pragma warning disable 0414

using UnityEngine;
using System.Collections;
//using System.Collections.Generic;
using UnityEngine.UI;

#region ENUMS
public enum DoorOrientation
{
    HORIZONTAL,
    VERTICAL
};
public enum DoorStatus
{
    OPEN,
    CLOSED,
    LOCKED,
    DAMAGED,
    DISABLED,
    DESTROYED
};
public enum PowerStatus
{
    MECHANICAL,
    UNPOWERED,
    POWERED
};
#endregion

#region EVENTS
//public class EVENT_EXAMPLE : GameEvent
//{
//    public EVENT_EXAMPLE() { }
//}
#endregion

public class Door : MonoBehaviour
{
    #region FIELDS
    [Header("STATUS")]
    [SerializeField]
    DoorStatus status = DoorStatus.CLOSED;
    [SerializeField]
    PowerStatus power = PowerStatus.POWERED;
    [SerializeField]
    DoorOrientation orientation = DoorOrientation.HORIZONTAL;
    [SerializeField]
    float openAmount = 2f;

    [Header("OPEN")]
    [SerializeField]
    float openTime = 2f;
    [SerializeField]
    LeanTweenType openEase = LeanTweenType.easeInBack;
    [SerializeField]
    float openDelay = 0.25f;

    [Header("CLOSE")]
    [SerializeField]
    float closeTime = 2f;
    [SerializeField]
    LeanTweenType closeEase = LeanTweenType.easeOutBack;
    [SerializeField]
    float closeDelay = 1f;
    #endregion

    #region INITIALIZATION
    ///////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>
    /// OnValidate
    /// </summary>
    ///////////////////////////////////////////////////////////////////////////////////////////////
    void OnValidate()
    {
        //refs

        //set/check initial values
    }
    ///////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>
    /// Awake
    /// </summary>
    ///////////////////////////////////////////////////////////////////////////////////////////////
    void Awake()
    {

    }
    ///////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>
    /// Start
    /// </summary>
    ///////////////////////////////////////////////////////////////////////////////////////////////
    void Start()
    {

    }
    #endregion

    #region PRIVATE METHODS
    ///////////////////////////////////////////////////////////////////////////////////////////////
    public void OpenDoor()
    {
        if(power == PowerStatus.POWERED || power == PowerStatus.MECHANICAL)
        {
            if(status == DoorStatus.CLOSED)
            {
                SetDoorStatus(DoorStatus.OPEN);

                LeanTween.cancelAll(this.gameObject);

                if(orientation == DoorOrientation.HORIZONTAL)
                {
                    LeanTween.moveLocalX(this.gameObject, openAmount, openTime)
                             .setDelay(openDelay)
                             .setEase(openEase);
                }
                else if (orientation == DoorOrientation.VERTICAL)
                {
                    LeanTween.moveLocalY(this.gameObject, openAmount, openTime)
                             .setDelay(openDelay)
                             .setEase(openEase);
                }
            }
        }
    }
    void SetDoorStatus(DoorStatus _status)
    {
        status = _status;
    }
    #endregion

    #region PUBLIC METHODS
    ///////////////////////////////////////////////////////////////////////////////////////////////

    #endregion
}