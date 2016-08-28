///////////////////////////////////////////////////////////////////////////////////////////////////
//AUTHOR — Travis Moore
//SCRIPT — GamePadInputData.cs
//COPYRIGHT — © 2016 DigiPen Institute of Technology
///////////////////////////////////////////////////////////////////////////////////////////////////

using UnityEngine;
using System.Collections;

public class GamePadInputData : MonoBehaviour
{
    //standard buttons
    GamePadButtonState y;
    public GamePadButtonState Y
    {
        get { return y; }
        set { y = value; }
    }
    GamePadButtonState b;
    public GamePadButtonState B
    {
        get { return b; }
        set { b = value; }
    }
    GamePadButtonState a;
    public GamePadButtonState A
    {
        get { return a; }
        set { a = value; }
    }
    GamePadButtonState x;
    public GamePadButtonState X
    {
        get { return x; }
        set { x = value; }
    }

    //shoulder buttons
    GamePadButtonState lb;
    public GamePadButtonState LB
    {
        get { return lb; }
        set { lb = value; }
    }
    GamePadButtonState rb;
    public GamePadButtonState RB
    {
        get { return rb; }
        set { rb = value; }
    }

    //misc buttons
    GamePadButtonState select;
    public GamePadButtonState Select
    {
        get { return select; }
        set { select = value; }
    }
    GamePadButtonState start;
    public GamePadButtonState Start
    {
        get { return start; }
        set { start = value; }
    }

    //trigger buttons
    GamePadButtonState lt;
    public GamePadButtonState LT
    {
        get { return lt; }
        set { lt = value; }
    }
    float ltValue;
    public float LTValue
    {
        get { return ltValue; }
        set { ltValue = value; }
    }
    GamePadButtonState rt;
    public GamePadButtonState RT
    {
        get { return rt; }
        set { rt = value; }
    }
    float rtValue;
    public float RTValue
    {
        get { return rtValue; }
        set { rtValue = value; }
    }

    //dpad
    GamePadButtonState dpad_up;
    public GamePadButtonState DPadUp
    {
        get { return dpad_up; }
        set { dpad_up = value; }
    }
    GamePadButtonState dpad_right;
    public GamePadButtonState DPadRight
    {
        get { return dpad_right; }
        set { dpad_right = value; }
    }
    GamePadButtonState dpad_down;
    public GamePadButtonState DPadDown
    {
        get { return dpad_down; }
        set { dpad_down = value; }
    }
    GamePadButtonState dpad_left;
    public GamePadButtonState DPadLeft
    {
        get { return dpad_left; }
        set { dpad_left = value; }
    }

    //analog sticks
    Vector2 leftAnalogStick;
    public Vector2 LeftAnalogStick
    {
        get { return leftAnalogStick; }
        set { leftAnalogStick = value; }
    }
    float leftAnalogStick_angle;
    public float LeftAnalogStickAngle
    {
        get { return leftAnalogStick_angle; }
        set { leftAnalogStick_angle = value; }
    }
    Vector2 rightAnalogStick;
    public Vector2 RightAnalogStick
    {
        get { return rightAnalogStick; }
        set { rightAnalogStick = value; }
    }
    float rightAnalogStickAngle;
    public float RightAnalogStickAngle
    {
        get { return rightAnalogStickAngle; }
        set { rightAnalogStickAngle = value; }
        }
}
