///////////////////////////////////////////////////////////////////////////////////////////////////
//AUTHOR — Travis Moore
//SCRIPT — ColliderInteractions.cs
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
public class EVENT_PLAYER_INTERACTION_DOOR : GameEvent
{
    public Transform door;
    public EVENT_PLAYER_INTERACTION_DOOR(Transform _door)
    {
        door = _door;
    }
}
#endregion

public class ColliderInteractions : MonoBehaviour
{
    #region FIELDS

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
        //listen to events

        //SetSubscriptions();
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
    void SetSubscriptions()
    {
        //Events.instance.AddListener<>();
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

    void OnCollisionEnter(Collision _collision)
    {
        print(_collision.gameObject.transform.root.gameObject.name);
        if (_collision.gameObject.transform.root.gameObject.tag == "Door")
        {
            Events.instance.Raise(new EVENT_PLAYER_INTERACTION_DOOR(_collision.gameObject.transform.root.gameObject.transform));
        }
    }
    void OnCollisionExit(Collision _collision)
    {
        if (_collision.gameObject.transform.root.gameObject.tag == "Door")
        {
            Events.instance.Raise(new EVENT_PLAYER_INTERACTION_DOOR(null));
        }
    }

    #region PUBLIC METHODS
    ///////////////////////////////////////////////////////////////////////////////////////////////

    #endregion

    #region PRIVATE METHODS
    ///////////////////////////////////////////////////////////////////////////////////////////////

    #endregion

    #region ONDESTORY
    ///////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>
    /// OnDestroy
    /// </summary>
    ///////////////////////////////////////////////////////////////////////////////////////////////
    void OnDestroy()
    {
        //remove event listeners
        //Events.instance.RemoveListener<>();
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