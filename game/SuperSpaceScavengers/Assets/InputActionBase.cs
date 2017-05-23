///////////////////////////////////////////////////////////////////////////////////////////////////
//AUTHOR — Travis Moore
//SCRIPT — InputActionBase.cs
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

public class InputActionBase : MonoBehaviour
{
    #region FIELDS
    [Header("BUTTON")]
    [SerializeField]
    protected XBoxButtons button;

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
    protected virtual void Awake()
    {
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
    protected virtual void SetSubscriptions()
    {
        Events.instance.AddListener<EVENT_GAMEPAD_P1>(RespondToInput);
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
    ///////////////////////////////////////////////////////////////////////////////////////////////
    protected virtual void RespondToInput(EVENT_GAMEPAD_P1 _event)
    {
        switch (button)
        {
            case XBoxButtons.Y:
                if(_event.gamepad.y.Status == InputStatus.RELEASED)
                {
                    OnReleased(_event.gamepad.y);
                }
                else if(_event.gamepad.y.Status == InputStatus.HELD)
                {
                    OnHeld(_event.gamepad.y);
                }
                else if(_event.gamepad.y.Status == InputStatus.PRESSED)
                {
                    OnPressed(_event.gamepad.y);
                }
                else
                {
                    OnInactive(_event.gamepad.y);
                }
                break;
            case XBoxButtons.B:
                if (_event.gamepad.b.Status == InputStatus.RELEASED)
                {
                    OnReleased(_event.gamepad.b);
                }
                else if (_event.gamepad.b.Status == InputStatus.HELD)
                {
                    OnHeld(_event.gamepad.b);
                }
                else if (_event.gamepad.b.Status == InputStatus.PRESSED)
                {
                    OnPressed(_event.gamepad.b);
                }
                else
                {
                    OnInactive(_event.gamepad.b);
                }
                break;
            case XBoxButtons.A:
                if (_event.gamepad.a.Status == InputStatus.RELEASED)
                {
                    OnReleased(_event.gamepad.a);
                }
                else if (_event.gamepad.a.Status == InputStatus.HELD)
                {
                    OnHeld(_event.gamepad.a);
                }
                else if (_event.gamepad.a.Status == InputStatus.PRESSED)
                {
                    OnPressed(_event.gamepad.a);
                }
                else
                {
                    OnInactive(_event.gamepad.a);
                }
                break;
            case XBoxButtons.X:
                if (_event.gamepad.x.Status == InputStatus.RELEASED)
                {
                    OnReleased(_event.gamepad.x);
                }
                else if (_event.gamepad.x.Status == InputStatus.HELD)
                {
                    OnHeld(_event.gamepad.x);
                }
                else if (_event.gamepad.x.Status == InputStatus.PRESSED)
                {
                    OnPressed(_event.gamepad.x);
                }
                else
                {
                    OnInactive(_event.gamepad.x);
                }
                break;
            case XBoxButtons.SELECT:
                if (_event.gamepad.select.Status == InputStatus.RELEASED)
                {
                    OnReleased(_event.gamepad.select);
                }
                else if (_event.gamepad.select.Status == InputStatus.HELD)
                {
                    OnHeld(_event.gamepad.select);
                }
                else if (_event.gamepad.select.Status == InputStatus.PRESSED)
                {
                    OnPressed(_event.gamepad.select);
                }
                else
                {
                    OnInactive(_event.gamepad.select);
                }
                break;
            case XBoxButtons.START:
                if (_event.gamepad.start.Status == InputStatus.RELEASED)
                {
                    OnReleased(_event.gamepad.start);
                }
                else if (_event.gamepad.start.Status == InputStatus.HELD)
                {
                    OnHeld(_event.gamepad.start);
                }
                else if (_event.gamepad.start.Status == InputStatus.PRESSED)
                {
                    OnPressed(_event.gamepad.start);
                }
                else
                {
                    OnInactive(_event.gamepad.start);
                }
                break;
            case XBoxButtons.LT:
                if (_event.gamepad.lt.Status == InputStatus.RELEASED)
                {
                    OnReleased(_event.gamepad.lt);
                }
                else if (_event.gamepad.lt.Status == InputStatus.HELD)
                {
                    OnHeld(_event.gamepad.lt);
                }
                else if (_event.gamepad.lt.Status == InputStatus.PRESSED)
                {
                    OnPressed(_event.gamepad.lt);
                }
                else
                {
                    OnInactive(_event.gamepad.lt);
                }
                break;
            case XBoxButtons.RT:
                if (_event.gamepad.rt.Status == InputStatus.RELEASED)
                {
                    OnReleased(_event.gamepad.rt);
                }
                else if (_event.gamepad.rt.Status == InputStatus.HELD)
                {
                    OnHeld(_event.gamepad.rt);
                }
                else if (_event.gamepad.rt.Status == InputStatus.PRESSED)
                {
                    OnPressed(_event.gamepad.rt);
                }
                else
                {
                    OnInactive(_event.gamepad.rt);
                }
                break;
            case XBoxButtons.LB:
                if (_event.gamepad.lb.Status == InputStatus.RELEASED)
                {
                    OnReleased(_event.gamepad.lb);
                }
                else if (_event.gamepad.lb.Status == InputStatus.HELD)
                {
                    OnHeld(_event.gamepad.lb);
                }
                else if (_event.gamepad.lb.Status == InputStatus.PRESSED)
                {
                    OnPressed(_event.gamepad.lb);
                }
                else
                {
                    OnInactive(_event.gamepad.lb);
                }
                break;
            case XBoxButtons.RB:
                if (_event.gamepad.rb.Status == InputStatus.RELEASED)
                {
                    OnReleased(_event.gamepad.rb);
                }
                else if (_event.gamepad.rb.Status == InputStatus.HELD)
                {
                    OnHeld(_event.gamepad.rb);
                }
                else if (_event.gamepad.rb.Status == InputStatus.PRESSED)
                {
                    OnPressed(_event.gamepad.rb);
                }
                else
                {
                    OnInactive(_event.gamepad.rb);
                }
                break;
            case XBoxButtons.DP_UP:
                if (_event.gamepad.dp_up.Status == InputStatus.RELEASED)
                {
                    OnReleased(_event.gamepad.dp_up);
                }
                else if (_event.gamepad.dp_up.Status == InputStatus.HELD)
                {
                    OnHeld(_event.gamepad.dp_up);
                }
                else if (_event.gamepad.dp_up.Status == InputStatus.PRESSED)
                {
                    OnPressed(_event.gamepad.dp_up);
                }
                else
                {
                    OnInactive(_event.gamepad.dp_up);
                }
                break;
            case XBoxButtons.DP_RIGHT:
                if (_event.gamepad.dp_right.Status == InputStatus.RELEASED)
                {
                    OnReleased(_event.gamepad.dp_right);
                }
                else if (_event.gamepad.dp_right.Status == InputStatus.HELD)
                {
                    OnHeld(_event.gamepad.dp_right);
                }
                else if (_event.gamepad.dp_right.Status == InputStatus.PRESSED)
                {
                    OnPressed(_event.gamepad.dp_right);
                }
                else
                {
                    OnInactive(_event.gamepad.dp_right);
                }
                break;
            case XBoxButtons.DP_DOWN:
                if (_event.gamepad.dp_down.Status == InputStatus.RELEASED)
                {
                    OnReleased(_event.gamepad.dp_down);
                }
                else if (_event.gamepad.start.Status == InputStatus.HELD)
                {
                    OnHeld(_event.gamepad.dp_down);
                }
                else if (_event.gamepad.dp_down.Status == InputStatus.PRESSED)
                {
                    OnPressed(_event.gamepad.dp_down);
                }
                else
                {
                    OnInactive(_event.gamepad.dp_down);
                }
                break;
            case XBoxButtons.DP_LEFT:
                if (_event.gamepad.dp_left.Status == InputStatus.RELEASED)
                {
                    OnReleased(_event.gamepad.dp_left);
                }
                else if (_event.gamepad.dp_left.Status == InputStatus.HELD)
                {
                    OnHeld(_event.gamepad.dp_left);
                }
                else if (_event.gamepad.dp_left.Status == InputStatus.PRESSED)
                {
                    OnPressed(_event.gamepad.dp_left);
                }
                else
                {
                    OnInactive(_event.gamepad.dp_left);
                }
                break;
            case XBoxButtons.LS:
                if (_event.gamepad.ls.Status == InputStatus.RELEASED)
                {
                    OnReleased(_event.gamepad.ls);
                }
                else if (_event.gamepad.ls.Status == InputStatus.HELD)
                {
                    OnHeld(_event.gamepad.ls);
                }
                else if (_event.gamepad.ls.Status == InputStatus.PRESSED)
                {
                    OnPressed(_event.gamepad.ls);
                }
                else
                {
                    OnInactive(_event.gamepad.ls);
                }
                break;
            case XBoxButtons.RS:
                if (_event.gamepad.rs.Status == InputStatus.RELEASED)
                {
                    OnReleased(_event.gamepad.rs);
                }
                else if (_event.gamepad.rs.Status == InputStatus.HELD)
                {
                    OnHeld(_event.gamepad.rs);
                }
                else if (_event.gamepad.rs.Status == InputStatus.PRESSED)
                {
                    OnPressed(_event.gamepad.rs);
                }
                else
                {
                    OnInactive(_event.gamepad.rs);
                }
                break;
            case XBoxButtons.L3:
                if (_event.gamepad.l3.Status == InputStatus.RELEASED)
                {
                    OnReleased(_event.gamepad.l3);
                }
                else if (_event.gamepad.l3.Status == InputStatus.HELD)
                {
                    OnHeld(_event.gamepad.l3);
                }
                else if (_event.gamepad.l3.Status == InputStatus.PRESSED)
                {
                    OnPressed(_event.gamepad.l3);
                }
                else
                {
                    OnInactive(_event.gamepad.l3);
                }
                break;
            case XBoxButtons.R3:
                if (_event.gamepad.r3.Status == InputStatus.RELEASED)
                {
                    OnReleased(_event.gamepad.r3);
                }
                else if (_event.gamepad.r3.Status == InputStatus.HELD)
                {
                    OnHeld(_event.gamepad.r3);
                }
                else if (_event.gamepad.r3.Status == InputStatus.PRESSED)
                {
                    OnPressed(_event.gamepad.r3);
                }
                else
                {
                    OnInactive(_event.gamepad.r3);
                }
                break;
            default:
                break;
        }
    }

    protected virtual void OnReleased(InputData _input)
    {

    }
    protected virtual void OnHeld(InputData _input)
    {

    }
    protected virtual void OnPressed(InputData _input)
    {

    }
    protected virtual void OnInactive(InputData _input)
    {

    }
    #endregion

    #region ONDESTORY
    ///////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>
    /// OnDestroy
    /// </summary>
    ///////////////////////////////////////////////////////////////////////////////////////////////
    protected virtual void OnDestroy()
    {
        //remove event listeners
        Events.instance.RemoveListener<EVENT_GAMEPAD_P1>(RespondToInput);
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
        if(Input.GetKeyDown(KeyCode.Keypad0))
        {

        }
        //Keypad 1
        if(Input.GetKeyDown(KeyCode.Keypad1))
        {
            
        }
        //Keypad 2
        if(Input.GetKeyDown(KeyCode.Keypad2))
        {
            
        }
        //Keypad 3
        if(Input.GetKeyDown(KeyCode.Keypad3))
        {
            
        }
        //Keypad 4
        if(Input.GetKeyDown(KeyCode.Keypad4))
        {
            
        }
        //Keypad 5
        if(Input.GetKeyDown(KeyCode.Keypad5))
        {
            
        }
        //Keypad 6
        if(Input.GetKeyDown(KeyCode.Keypad6))
        {
            
        }
    }
    #endregion
}