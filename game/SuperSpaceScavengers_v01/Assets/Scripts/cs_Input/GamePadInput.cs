///////////////////////////////////////////////////////////////////////////////////////////////////
//AUTHOR — Travis Moore
//SCRIPT — GamePadInput.cs
//COPYRIGHT — © 2016 DigiPen Institute of Technology
///////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using UnityEngine;
using System.Collections;
using XInputDotNetPure; // Required in C#

#region ENUMS

public enum GamePadButtonState { INACTIVE, PRESSED, HELD, RELEASED };

#endregion

#region STRUCTS

public struct GamePadInputData
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

#endregion

public class GamePadInput : MonoBehaviour
{
    #region FIELDS

    [Header("PLAYERS")]
    [Range(1, 4)]
    uint player = 1;

    [Range(0, 1)]
    [SerializeField]
    float TriggerDeadZone = 0.2f;

    [Range(0, 1)]
    [SerializeField]
    float AnalogStickDeadZone = 0.2f;


    bool playerIndexSet = false;
    PlayerIndex playerIndex;
    GamePadState state;
    GamePadState prevState;

    [HideInInspector]
    public static GamePadInputData GamePadInputStatus;

    #endregion

    #region INITIALIZATION

    void Awake()
    {
    }

    void Start()
    {
        //because programmers like to start with 0
        player -= 1;

        // Find a PlayerIndex, for a single player game
        // Will find the first controller that is connected and use it
        if (!playerIndexSet || !prevState.IsConnected)
        {
            PlayerIndex testPlayerIndex = (PlayerIndex)player;
            GamePadState testState = GamePad.GetState(testPlayerIndex);
            if (testState.IsConnected)
            {
                Debug.Log(string.Format("GamePad found {0}", testPlayerIndex));
                playerIndex = testPlayerIndex;
                playerIndexSet = true;
            }
        }
    }

    #endregion

    #region UPDATE

    /// <summary>
    /// Update()
    /// </summary>
    void Update()
    {
        //update the state
        prevState = state;
        state = GamePad.GetState(playerIndex);

        //check the gamepad buttons
        CheckGamePadStates(prevState, state);
    }


    #endregion

    #region METHODS

    /// <summary>
    /// Checks the INACTIVE, PRESSED, HELD, and RELEASED status of buttons
    /// </summary>
    /// <param name="_previous">last frame GamePad Input</param>
    /// <param name="_current">current frame GamePad Input</param>
    void CheckGamePadStates(GamePadState _previous, GamePadState _current)
    {
        //standard buttons
        #region Y BUTTON
        //RELEASED
        if (_previous.Buttons.Y == ButtonState.Pressed && _current.Buttons.Y == ButtonState.Released)
        {
            GamePadInputStatus.Y = GamePadButtonState.RELEASED;
        }
        //HELD
        else if (_previous.Buttons.Y == ButtonState.Pressed && _current.Buttons.Y == ButtonState.Pressed)
        {
            GamePadInputStatus.Y = GamePadButtonState.HELD;
        }
        //PRESSED
        else if (_previous.Buttons.Y == ButtonState.Released && _current.Buttons.Y == ButtonState.Pressed)
        {
            GamePadInputStatus.Y = GamePadButtonState.PRESSED;
        }
        //INACTIVE
        else
        {
            GamePadInputStatus.Y = GamePadButtonState.INACTIVE;
        }
        #endregion
        #region B BUTTON
        //RELEASED
        if (_previous.Buttons.B == ButtonState.Pressed && _current.Buttons.B == ButtonState.Released)
        {
            GamePadInputStatus.B = GamePadButtonState.RELEASED;
        }
        //HELD
        else if (_previous.Buttons.B == ButtonState.Pressed && _current.Buttons.B == ButtonState.Pressed)
        {
            GamePadInputStatus.B = GamePadButtonState.HELD;
        }
        //PRESSED
        else if (_previous.Buttons.B == ButtonState.Released && _current.Buttons.B == ButtonState.Pressed)
        {
            GamePadInputStatus.B = GamePadButtonState.PRESSED;
        }
        //INACTIVE
        else
        {
            GamePadInputStatus.B = GamePadButtonState.INACTIVE;
        }
        #endregion
        #region A BUTTON
        //RELEASED
        if (_previous.Buttons.A == ButtonState.Pressed && _current.Buttons.A == ButtonState.Released)
        {
            GamePadInputStatus.A = GamePadButtonState.RELEASED;
        }
        //HELD
        else if (_previous.Buttons.A == ButtonState.Pressed && _current.Buttons.A == ButtonState.Pressed)
        {
            GamePadInputStatus.A = GamePadButtonState.HELD;
        }
        //PRESSED
        else if (_previous.Buttons.A == ButtonState.Released && _current.Buttons.A == ButtonState.Pressed)
        {
            GamePadInputStatus.A = GamePadButtonState.PRESSED;
        }
        //INACTIVE
        else
        {
            GamePadInputStatus.A = GamePadButtonState.INACTIVE;
        }
        #endregion
        #region X BUTTON
        //RELEASED
        if (_previous.Buttons.X == ButtonState.Pressed && _current.Buttons.X == ButtonState.Released)
        {
            GamePadInputStatus.X = GamePadButtonState.RELEASED;
        }
        //HELD
        else if (_previous.Buttons.X == ButtonState.Pressed && _current.Buttons.X == ButtonState.Pressed)
        {
            GamePadInputStatus.X = GamePadButtonState.HELD;
        }
        //PRESSED
        else if (_previous.Buttons.X == ButtonState.Released && _current.Buttons.X == ButtonState.Pressed)
        {
            GamePadInputStatus.X = GamePadButtonState.PRESSED;
        }
        //INACTIVE
        else
        {
            GamePadInputStatus.X = GamePadButtonState.INACTIVE;
        }
        #endregion

        //shoulder buttons
        #region RIGHT BUMPER
        //RELEASED
        if (_previous.Buttons.LeftShoulder == ButtonState.Pressed && _current.Buttons.LeftShoulder == ButtonState.Released)
        {
            GamePadInputStatus.LB = GamePadButtonState.RELEASED;
        }
        //HELD
        else if (_previous.Buttons.LeftShoulder == ButtonState.Pressed && _current.Buttons.LeftShoulder == ButtonState.Pressed)
        {
            GamePadInputStatus.LB = GamePadButtonState.HELD;
        }
        //PRESSED
        else if (_previous.Buttons.LeftShoulder == ButtonState.Released && _current.Buttons.LeftShoulder == ButtonState.Pressed)
        {
            GamePadInputStatus.LB = GamePadButtonState.PRESSED;
        }
        //INACTIVE
        else
        {
            GamePadInputStatus.LB = GamePadButtonState.INACTIVE;
        }
        #endregion
        #region RIGHT BUMPER
        //RELEASED
        if (_previous.Buttons.RightShoulder == ButtonState.Pressed && _current.Buttons.RightShoulder == ButtonState.Released)
        {
            GamePadInputStatus.RB = GamePadButtonState.RELEASED;
        }
        //HELD
        else if (_previous.Buttons.RightShoulder == ButtonState.Pressed && _current.Buttons.RightShoulder == ButtonState.Pressed)
        {
            GamePadInputStatus.RB = GamePadButtonState.HELD;
        }
        //PRESSED
        else if (_previous.Buttons.RightShoulder == ButtonState.Released && _current.Buttons.RightShoulder == ButtonState.Pressed)
        {
            GamePadInputStatus.RB = GamePadButtonState.PRESSED;
        }
        //INACTIVE
        else
        {
            GamePadInputStatus.RB = GamePadButtonState.INACTIVE;
        }
        #endregion

        //triggers
        #region LEFT TRIGGER
        //RELEASED
        if (_previous.Triggers.Left > TriggerDeadZone && _current.Triggers.Left < TriggerDeadZone)
        {
            GamePadInputStatus.LT = GamePadButtonState.RELEASED;
            GamePadInputStatus.LTValue = _current.Triggers.Left;
        }
        //HELD
        else if (_previous.Triggers.Left > TriggerDeadZone && _current.Triggers.Left > TriggerDeadZone)
        {
            GamePadInputStatus.LT = GamePadButtonState.HELD;
            GamePadInputStatus.LTValue = _current.Triggers.Left;
        }
        //PRESSED
        else if (_previous.Triggers.Left < TriggerDeadZone && _current.Triggers.Left > TriggerDeadZone)
        {
            GamePadInputStatus.LT = GamePadButtonState.PRESSED;
            GamePadInputStatus.LTValue = _current.Triggers.Left;
        }
        //INACTIVE
        else
        {
            GamePadInputStatus.LT = GamePadButtonState.INACTIVE;
            GamePadInputStatus.LTValue = _current.Triggers.Left;
        }
        #endregion
        #region RIGHT TRIGGER
        //RELEASED
        if (_previous.Triggers.Right > TriggerDeadZone && _current.Triggers.Right < TriggerDeadZone)
        {
            GamePadInputStatus.RT = GamePadButtonState.RELEASED;
            GamePadInputStatus.RTValue = _current.Triggers.Right;
        }
        //HELD
        else if (_previous.Triggers.Right > TriggerDeadZone && _current.Triggers.Right > TriggerDeadZone)
        {
            GamePadInputStatus.RT = GamePadButtonState.HELD;
            GamePadInputStatus.RTValue = _current.Triggers.Right;
        }
        //PRESSED
        else if (_previous.Triggers.Right < TriggerDeadZone && _current.Triggers.Right > TriggerDeadZone)
        {
            GamePadInputStatus.RT = GamePadButtonState.PRESSED;
            GamePadInputStatus.RTValue = _current.Triggers.Right;
        }
        //INACTIVE
        else
        {
            GamePadInputStatus.RT = GamePadButtonState.INACTIVE;
            GamePadInputStatus.RTValue = _current.Triggers.Right;
        }
        #endregion

        //misc buttons
        #region SELECT
        //RELEASED
        if (_previous.Buttons.Back == ButtonState.Pressed && _current.Buttons.Back == ButtonState.Released)
        {
            GamePadInputStatus.Select = GamePadButtonState.RELEASED;
        }
        //HELD
        else if (_previous.Buttons.Back == ButtonState.Pressed && _current.Buttons.Back == ButtonState.Pressed)
        {
            GamePadInputStatus.Select = GamePadButtonState.HELD;
        }
        //PRESSED
        else if (_previous.Buttons.Back == ButtonState.Released && _current.Buttons.Back == ButtonState.Pressed)
        {
            GamePadInputStatus.Select = GamePadButtonState.PRESSED;
        }
        //INACTIVE
        else
        {
            GamePadInputStatus.Select = GamePadButtonState.INACTIVE;
        }
        #endregion
        #region START
        //RELEASED
        if (_previous.Buttons.Start == ButtonState.Pressed && _current.Buttons.Start == ButtonState.Released)
        {
            GamePadInputStatus.Start = GamePadButtonState.RELEASED;
        }
        //HELD
        else if (_previous.Buttons.Start == ButtonState.Pressed && _current.Buttons.Start == ButtonState.Pressed)
        {
            GamePadInputStatus.Start = GamePadButtonState.HELD;
        }
        //PRESSED
        else if (_previous.Buttons.Start == ButtonState.Released && _current.Buttons.Start == ButtonState.Pressed)
        {
            GamePadInputStatus.Start = GamePadButtonState.PRESSED;
        }
        //INACTIVE
        else
        {
            GamePadInputStatus.Start = GamePadButtonState.INACTIVE;
        }
        #endregion

        //dpad buttons
        #region DPAD UP
        //RELEASED
        if (_previous.DPad.Up == ButtonState.Pressed && _current.DPad.Up == ButtonState.Released)
        {
            GamePadInputStatus.DPadUp = GamePadButtonState.RELEASED;
        }
        //HELD
        else if (_previous.DPad.Up == ButtonState.Pressed && _current.DPad.Up == ButtonState.Pressed)
        {
            GamePadInputStatus.DPadUp = GamePadButtonState.HELD;
        }
        //PRESSED
        else if (_previous.DPad.Up == ButtonState.Released && _current.DPad.Up == ButtonState.Pressed)
        {
            GamePadInputStatus.DPadUp = GamePadButtonState.PRESSED;
        }
        //INACTIVE
        else
        {
            GamePadInputStatus.DPadUp = GamePadButtonState.INACTIVE;
        }
        #endregion
        #region DPAD RIGHT
        //RELEASED
        if (_previous.DPad.Right == ButtonState.Pressed && _current.DPad.Right == ButtonState.Released)
        {
            GamePadInputStatus.DPadRight = GamePadButtonState.RELEASED;
        }
        //HELD
        else if (_previous.DPad.Right == ButtonState.Pressed && _current.DPad.Right == ButtonState.Pressed)
        {
            GamePadInputStatus.DPadRight = GamePadButtonState.HELD;
        }
        //PRESSED
        else if (_previous.DPad.Right == ButtonState.Released && _current.DPad.Right == ButtonState.Pressed)
        {
            GamePadInputStatus.DPadRight = GamePadButtonState.PRESSED;
        }
        //INACTIVE
        else
        {
            GamePadInputStatus.DPadRight = GamePadButtonState.INACTIVE;
        }
        #endregion
        #region DPAD DOWN
        //RELEASED
        if (_previous.DPad.Down == ButtonState.Pressed && _current.DPad.Down == ButtonState.Released)
        {
            GamePadInputStatus.DPadDown = GamePadButtonState.RELEASED;
        }
        //HELD
        else if (_previous.DPad.Down == ButtonState.Pressed && _current.DPad.Down == ButtonState.Pressed)
        {
            GamePadInputStatus.DPadDown = GamePadButtonState.HELD;
        }
        //PRESSED
        else if (_previous.DPad.Down == ButtonState.Released && _current.DPad.Down == ButtonState.Pressed)
        {
            GamePadInputStatus.DPadDown = GamePadButtonState.PRESSED;
        }
        //INACTIVE
        else
        {
            GamePadInputStatus.DPadDown = GamePadButtonState.INACTIVE;
        }
        #endregion
        #region DPAD LEFT
        //RELEASED
        if (_previous.DPad.Left == ButtonState.Pressed && _current.DPad.Left == ButtonState.Released)
        {
            GamePadInputStatus.DPadLeft = GamePadButtonState.RELEASED;
        }
        //HELD
        else if (_previous.DPad.Left == ButtonState.Pressed && _current.DPad.Left == ButtonState.Pressed)
        {
            GamePadInputStatus.DPadLeft = GamePadButtonState.HELD;
        }
        //PRESSED
        else if (_previous.DPad.Left == ButtonState.Released && _current.DPad.Left == ButtonState.Pressed)
        {
            GamePadInputStatus.DPadLeft = GamePadButtonState.PRESSED;
        }
        //INACTIVE
        else
        {
            GamePadInputStatus.DPadLeft = GamePadButtonState.INACTIVE;
        }
        #endregion

        //analog sticks !REMEMBER that angles are funky (UP is 90° RIGHT = 0°, DOWN = -90°, and LEFT = 180°)
        #region LEFT ANALOG STICK
        //respect deadzones
        if (_current.ThumbSticks.Left.X < AnalogStickDeadZone ||
            _current.ThumbSticks.Left.X > AnalogStickDeadZone ||
            _current.ThumbSticks.Left.Y < AnalogStickDeadZone ||
            _current.ThumbSticks.Left.Y > AnalogStickDeadZone)
        {
            //store value of x and y, along with the angle (UP is 90° RIGHT = 0°, DOWN = -90°, and LEFT = 180°)
            GamePadInputStatus.LeftAnalogStick = new Vector2(_current.ThumbSticks.Left.X, _current.ThumbSticks.Left.Y);
            GamePadInputStatus.LeftAnalogStickAngle = Mathf.Atan2(_current.ThumbSticks.Left.Y, _current.ThumbSticks.Left.X) * Mathf.Rad2Deg;
        }
        #endregion

        //analog sticks !REMEMBER that angles are funky (UP is 90° RIGHT = 0°, DOWN = -90°, and LEFT = 180°)
        #region RIGHT ANALOG STICK
        //respect deadzones
        if (_current.ThumbSticks.Right.X < AnalogStickDeadZone ||
            _current.ThumbSticks.Right.X > AnalogStickDeadZone ||
            _current.ThumbSticks.Right.Y < AnalogStickDeadZone ||
            _current.ThumbSticks.Right.Y > AnalogStickDeadZone)
        {
            //store value of x and y, along with the angle (UP is 90° RIGHT = 0°, DOWN = -90°, and LEFT = 180°)
            GamePadInputStatus.RightAnalogStick = new Vector2(_current.ThumbSticks.Right.X, _current.ThumbSticks.Right.Y);
            GamePadInputStatus.RightAnalogStickAngle = Mathf.Atan2(_current.ThumbSticks.Right.Y, _current.ThumbSticks.Right.X) * Mathf.Rad2Deg;
        }
        #endregion
    }


    #endregion
}