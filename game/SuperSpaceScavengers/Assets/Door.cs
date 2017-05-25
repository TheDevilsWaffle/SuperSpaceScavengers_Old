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
public enum DoorStatus
{
    OPEN,
    CLOSED,
    LOCKED,
    DAMAGED,
    DISABLED,
    DESTROYED
};
public enum DoorType
{
    MANUAL,
    AUTO
}
public enum PowerStatus
{
    UNPOWERED,
    POWERED
};
#endregion

#region EVENTS
public class EVENT_PLAYER_INTERACTION_DOOR : GameEvent
{
    public Door door;
    public EVENT_PLAYER_INTERACTION_DOOR(Door _door)
    {
        door = _door;
    }
}
#endregion

public class Door : MonoBehaviour
{
    #region FIELDS

    [Header("STATUS")]
    [SerializeField]
    DoorStatus status = DoorStatus.CLOSED;
    public DoorStatus Status
    {
        get { return status; }
    }
    [SerializeField]
    DoorType type = DoorType.AUTO;
    public DoorType Type
    {
        get { return type; }
    }
    [SerializeField]
    PowerStatus power = PowerStatus.POWERED;
    [SerializeField]
    Vector3 openAmount = new Vector3(2f, 0f, 0f);

    [Header("OPEN")]
    [SerializeField]
    float openTime = 2f;
    [SerializeField]
    LeanTweenType openEase = LeanTweenType.easeInBack;
    [SerializeField]
    float openDelay = 0.25f;
    [SerializeField]
    string openText = "OPEN";

    [Header("CLOSE")]
    [SerializeField]
    float closeTime = 2f;
    [SerializeField]
    LeanTweenType closeEase = LeanTweenType.easeOutBack;
    [SerializeField]
    float closeDelay = 1f;
    [SerializeField]
    string closeText = "CLOSE";

    //refs
    GameObject model;
    Transform model_tr;
    Vector3 model_pos;
    Vector3 closedPos;
    GameObject ui;
    SpriteRenderer sprite;
    TextMesh text;

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
        model = transform.GetChild(0).gameObject;
        model_tr = model.GetComponent<Transform>();
        ui = transform.GetChild(1).gameObject;
        sprite = ui.transform.GetChild(0).GetComponent<SpriteRenderer>();
        text = ui.transform.GetChild(1).GetComponent<TextMesh>();

        //set/check initial values
        model_pos = model_tr.localPosition;
        closedPos = model_pos;
    }
    ///////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>
    /// Awake
    /// </summary>
    ///////////////////////////////////////////////////////////////////////////////////////////////
    void Awake()
    {
        //LeanTween.move(ui, new Vector3(0f, 0.1f, 0f), 1f).setEase(LeanTweenType.easeInOutQuad).setLoopType(LeanTweenType.pingPong);
        ui.gameObject.SetActive(false);
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
    /// <summary>
    /// sets the door status
    /// </summary>
    /// <param name="_status">OPEN, CLOSED, LOCKED, DAMAGED, DISABLED, DESTROYED</param>
    ///////////////////////////////////////////////////////////////////////////////////////////////
    void SetDoorStatus(DoorStatus _status)
    {
        status = _status;
    }
    #endregion

    #region PUBLIC METHODS
    ///////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>
    /// opens the door using the open properties
    /// </summary>
    ///////////////////////////////////////////////////////////////////////////////////////////////
    public void OpenDoor()
    {
        //Debug.Log("OpenDoor()");

        //check if powered and already closed
        if (power == PowerStatus.POWERED)
        {
            if (status == DoorStatus.CLOSED)
            {
                //open and animate
                SetDoorStatus(DoorStatus.OPEN);

                LeanTween.cancelAll(this.gameObject);
                LeanTween.moveLocal(model, openAmount, openTime)
                            .setDelay(openDelay)
                            .setEase(openEase);
            }
        }
    }
    ///////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>
    /// closes the door using the close properties
    /// </summary>
    ///////////////////////////////////////////////////////////////////////////////////////////////
    public void CloseDoor()
    {
        //Debug.Log("CloseDoor()");

        //check if powered and openned already
        if (power == PowerStatus.POWERED)
        {
            if (status == DoorStatus.OPEN)
            {
                //close and animate
                SetDoorStatus(DoorStatus.CLOSED);

                LeanTween.cancelAll(this.gameObject);
                LeanTween.moveLocal(model, closedPos, closeTime)
                            .setDelay(closeDelay)
                            .setEase(closeEase);
            }
        }
    }
    #endregion

    #region TRIGGERS
    ///////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>
    /// OnTriggerEnter
    /// </summary>
    /// <param name="_other"></param>
    ///////////////////////////////////////////////////////////////////////////////////////////////
    void OnTriggerEnter(Collider _other)
    {
        if(_other.tag == "Player")
        {
            Events.instance.Raise(new EVENT_PLAYER_INTERACTION_DOOR(GetComponent<Door>()));
        }
    }
    ///////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>
    /// OnTriggerStay
    /// </summary>
    /// <param name="_other"></param>
    ///////////////////////////////////////////////////////////////////////////////////////////////
    void OnTriggerStay(Collider _other)
    {
        if (type == DoorType.AUTO)
        {
            if (_other.tag == "Player")
            {
                //Debug.Log(_other.gameObject.name + " has stayed in the trigger zone of " + this.gameObject.name);

                OpenDoor();
            }
        }
        else if(type == DoorType.MANUAL)
        {
            if (_other.tag == "Player")
            {
                ui.SetActive(true);
                if (status == DoorStatus.CLOSED)
                    text.text = openText;
                else
                    text.text = closeText;
            }
        }
    }
    ///////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>
    /// OnTriggerExit
    /// </summary>
    /// <param name="_other"></param>
    ///////////////////////////////////////////////////////////////////////////////////////////////
    void OnTriggerExit(Collider _other)
    {
        if (type == DoorType.AUTO)
        {
            if (_other.tag == "Player")
            {
                //Debug.Log(_other.gameObject.name + " has exited the trigger zone of " + this.gameObject.name);

                //broadcast event
                Events.instance.Raise(new EVENT_PLAYER_INTERACTION_DOOR(null));

                CloseDoor();
            }
        }
    }
    #endregion
}