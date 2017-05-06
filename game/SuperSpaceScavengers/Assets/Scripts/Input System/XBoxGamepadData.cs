///////////////////////////////////////////////////////////////////////////////////////////////////
//AUTHOR — Travis Moore
//SCRIPT — XBoxGamepadData.cs
///////////////////////////////////////////////////////////////////////////////////////////////////

using UnityEngine;
using System.Collections;

public class XBoxGamepadData
{
    #region ANALOG STICKS
    public InputData ls;
    public InputData l3;
    public InputData rs;
    public InputData r3;
    #endregion
    #region DPAD
    public InputData dp_up;
    public InputData dp_right;
    public InputData dp_down;
    public InputData dp_left;
    #endregion
    #region BUTTONS
    public InputData y;
    public InputData b;
    public InputData a;
    public InputData x;
    public InputData select;
    public InputData start;
    #endregion
    #region BUMPERS
    public InputData lb;
    public InputData rb;
    #endregion
    #region TRIGGERS
    public InputData lt;
    public InputData rt;
    #endregion

    #region INITIALIZE
    ///////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>
    /// OnValidate
    /// </summary>
    ///////////////////////////////////////////////////////////////////////////////////////////////
    void OnValidate()
    {
        ls.SetName("Left Stick");
        rs.SetName("Right Stick");
        l3.SetName("L3");
        r3.SetName("R3");

        dp_up.SetName("DPAD Up");
        dp_right.SetName("DPAD Right");
        dp_down.SetName("DPAD Down");
        dp_left.SetName("DPAD Left");

        y.SetName("Y");
        b.SetName("B");
        a.SetName("A");
        x.SetName("X");
        select.SetName("Select");
        start.SetName("Start");

        lb.SetName("Left Bumper");
        rb.SetName("Right Bumper");

        lt.SetName("Left Trigger");
        rt.SetName("Right Trigger");
    }
    #endregion
}
