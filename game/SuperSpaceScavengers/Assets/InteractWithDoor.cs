///////////////////////////////////////////////////////////////////////////////////////////////////
//AUTHOR — Travis Moore
//SCRIPT — InteractWithDoor.cs
///////////////////////////////////////////////////////////////////////////////////////////////////

//#pragma warning disable 0169
//#pragma warning disable 0649
//#pragma warning disable 0108
//#pragma warning disable 0414

using UnityEngine;
using System.Collections;
//using System.Collections.Generic;
//using UnityEngine.UI;

#region ENUMS
//public enum EnumStatus
//{
//	
//};
#endregion

#region EVENTS
//public class EVENT_EXAMPLE : GameEvent
//{
//    public EVENT_EXAMPLE() { }
//}
#endregion

public class InteractWithDoor : InputActionBase
{
    #region FIELDS
    Transform door;
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
    protected override void Awake()
    {
        base.Awake();
        //listen to events
        SetSubscriptions();
    }
    ///////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>
    /// Start
    /// </summary>
    ///////////////////////////////////////////////////////////////////////////////////////////////
    void Start()
    {

    }
    ///////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>
    /// SetSubscriptions
    /// </summary>
    ///////////////////////////////////////////////////////////////////////////////////////////////
    protected override void SetSubscriptions()
    {
        base.SetSubscriptions();
        Events.instance.AddListener<EVENT_PLAYER_INTERACTION_DOOR>(ReadyDoor);
    }
    #endregion

    #region UPDATE
    ///////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>
    /// Update()
    /// </summary>
    ///////////////////////////////////////////////////////////////////////////////////////////////
    void Update()
    {

#if false
        UpdateTesting();
#endif

    }
    #endregion

    #region PUBLIC METHODS
    ///////////////////////////////////////////////////////////////////////////////////////////////

    #endregion

    #region PRIVATE METHODS
    void ReadyDoor(EVENT_PLAYER_INTERACTION_DOOR _event)
    {
        door = _event.door;
    }
    ///////////////////////////////////////////////////////////////////////////////////////////////
    protected override void OnReleased(InputData _input)
    {
        
    }
    ///////////////////////////////////////////////////////////////////////////////////////////////
    protected override void OnPressed(InputData _input)
    {
        //print(_input.Name + " was pressed!");
        if(door != null)
        {
            door.Translate(door.position - new Vector3(2f, 0, 0));
        }
    }
    ///////////////////////////////////////////////////////////////////////////////////////////////
    protected override void OnHeld(InputData _input)
    {
        //print(_input.Name + " is held!");
    }
    ///////////////////////////////////////////////////////////////////////////////////////////////
    protected override void OnInactive(InputData _input)
    {
        //print(_input.Name + " is inactive!");
    }
    #endregion

    #region ONDESTORY
    ///////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>
    /// OnDestroy
    /// </summary>
    ///////////////////////////////////////////////////////////////////////////////////////////////
    protected override void OnDestroy()
    {
        base.OnDestroy();

        //remove event listeners
        Events.instance.RemoveListener<EVENT_PLAYER_INTERACTION_DOOR>(ReadyDoor);
    }
    #endregion

    #region TESTING
    ///////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>
    /// UpdateTesting
    /// </summary>
    ///////////////////////////////////////////////////////////////////////////////////////////////
    void UpdateTesting()
    {
        //Keypad 0
        if (Input.GetKeyDown(KeyCode.Keypad0))
        {

        }
        //Keypad 1
        if (Input.GetKeyDown(KeyCode.Keypad1))
        {

        }
        //Keypad 2
        if (Input.GetKeyDown(KeyCode.Keypad2))
        {

        }
        //Keypad 3
        if (Input.GetKeyDown(KeyCode.Keypad3))
        {

        }
        //Keypad 4
        if (Input.GetKeyDown(KeyCode.Keypad4))
        {

        }
        //Keypad 5
        if (Input.GetKeyDown(KeyCode.Keypad5))
        {

        }
        //Keypad 6
        if (Input.GetKeyDown(KeyCode.Keypad6))
        {

        }
    }
    #endregion
}