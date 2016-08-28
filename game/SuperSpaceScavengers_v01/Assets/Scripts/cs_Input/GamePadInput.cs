///////////////////////////////////////////////////////////////////////////////////////////////////
//AUTHOR — Travis Moore
//SCRIPT — GamePadInput.cs
//COPYRIGHT — © 2016 DigiPen Institute of Technology
///////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using XInputDotNetPure; // Required in C#

#region ENUMS

public enum GamePadButtonState { INACTIVE, PRESSED, HELD, RELEASED };

#endregion

public class GamePadInput : MonoBehaviour
{
    #region FIELDS

    [Header("PLAYERS")]
    [Range(1, 4)]
    [SerializeField]
    uint numberOfplayers = 1;

    [Range(0, 1)]
    [SerializeField]
    float triggerDeadZone = 0.2f;

    [Range(0, 1)]
    [SerializeField]
    float analogStickDeadZone = 0.2f;

    GamePadState currentState;
    GamePadState previousState;

    [HideInInspector]
    public static List<GamePadInputData> players;

    #endregion

    #region INITIALIZATION

    void Awake()
    {
    }

    void Start()
    {
        //because programmers like to start with 0
        numberOfplayers -= 1;

        //create list of players
        players = new List<GamePadInputData>();
        
        //popluate list of players based on numberOfPlayers
        PopulatePlayers(numberOfplayers);

        // Find a PlayerIndex, for a single player game
        // Will find the first controller that is connected and use it
        /*
        if (!playerIndexSet || !prevState.IsConnected)
        {
            PlayerIndex testPlayerIndex = (PlayerIndex)numberOfplayers;
            GamePadState testState = GamePad.GetState(testPlayerIndex);
            if (testState.IsConnected)
            {
                Debug.Log(string.Format("GamePad found {0}", testPlayerIndex));
                playerIndex = testPlayerIndex;
                playerIndexSet = true;
            }
        }
        */
    }

    #endregion

    #region UPDATE

    /// <summary>
    /// Update()
    /// </summary>
    void Update()
    {
        uint _playerIndex = 0;
        //cycle through each player, check if they actually exist
        for (; _playerIndex <= numberOfplayers; ++_playerIndex)
        {
            //first test to make sure there's a controller there to update
            GamePadState _testState = GamePad.GetState((PlayerIndex)_playerIndex);

            if (_testState.IsConnected)
            {
                //update the previous and currentstate
                previousState = currentState;
                currentState = GamePad.GetState((PlayerIndex)_playerIndex);

                //check the gamepad buttons
                CheckGamePadStates((int)_playerIndex, previousState, currentState);
            }
            else
                Debug.LogError("ERROR! Player Index for Player " + _playerIndex + " no longer exists? " + GamePad.GetState((PlayerIndex)_playerIndex));

            //DEBUG — CHECK BUTTON STATUS
            print("PLAYER " + _playerIndex + ": " + players[(int)_playerIndex].LeftAnalogStick + 
                    " and the angle is = " + players[(int)_playerIndex].LeftAnalogStickAngle);
        }

    }


    #endregion

    #region METHODS

    /// <summary>
    /// Creates an array of GamePadInputData based on how many players are in the game
    /// </summary>
    /// <param name="_numberOfPlayers"># of players</param>
    void PopulatePlayers(uint _numberOfPlayers)
    {
        //cycle through the amount of players
        for (uint i = 0; i <= _numberOfPlayers; ++i)
        {
            players.Add(new GamePadInputData{ });
        }

        //DEBUG
        print("Players size = " + players.Count);
    }

    /// <summary>
    /// Checks the INACTIVE, PRESSED, HELD, and RELEASED status of buttons
    /// </summary>
    /// <param name="_previous">last frame GamePad Input</param>
    /// <param name="_current">current frame GamePad Input</param>
    void CheckGamePadStates(int _playerIndex, GamePadState _previous, GamePadState _current)
    {
        //standard buttons
        #region Y BUTTON
        //RELEASED
        if (_previous.Buttons.Y == ButtonState.Pressed && _current.Buttons.Y == ButtonState.Released)
        {
            //players[_playerIndex].Y = GamePadButtonState.RELEASED;

            players[_playerIndex].Y = GamePadButtonState.RELEASED;
        }
        //HELD
        else if (_previous.Buttons.Y == ButtonState.Pressed && _current.Buttons.Y == ButtonState.Pressed)
        {
            players[_playerIndex].Y = GamePadButtonState.HELD;
        }
        //PRESSED
        else if (_previous.Buttons.Y == ButtonState.Released && _current.Buttons.Y == ButtonState.Pressed)
        {
            players[_playerIndex].Y = GamePadButtonState.PRESSED;
        }
        //INACTIVE
        else
        {
            players[_playerIndex].Y = GamePadButtonState.INACTIVE;
        }
        #endregion
        #region B BUTTON
        //RELEASED
        if (_previous.Buttons.B == ButtonState.Pressed && _current.Buttons.B == ButtonState.Released)
        {
            players[_playerIndex].B = GamePadButtonState.RELEASED;
        }
        //HELD
        else if (_previous.Buttons.B == ButtonState.Pressed && _current.Buttons.B == ButtonState.Pressed)
        {
            players[_playerIndex].B = GamePadButtonState.HELD;
        }
        //PRESSED
        else if (_previous.Buttons.B == ButtonState.Released && _current.Buttons.B == ButtonState.Pressed)
        {
            players[_playerIndex].B = GamePadButtonState.PRESSED;
        }
        //INACTIVE
        else
        {
            players[_playerIndex].B = GamePadButtonState.INACTIVE;
        }
        #endregion
        #region A BUTTON
        //RELEASED
        if (_previous.Buttons.A == ButtonState.Pressed && _current.Buttons.A == ButtonState.Released)
        {
            players[_playerIndex].A = GamePadButtonState.RELEASED;
        }
        //HELD
        else if (_previous.Buttons.A == ButtonState.Pressed && _current.Buttons.A == ButtonState.Pressed)
        {
            players[_playerIndex].A = GamePadButtonState.HELD;
        }
        //PRESSED
        else if (_previous.Buttons.A == ButtonState.Released && _current.Buttons.A == ButtonState.Pressed)
        {
            players[_playerIndex].A = GamePadButtonState.PRESSED;
        }
        //INACTIVE
        else
        {
            players[_playerIndex].A = GamePadButtonState.INACTIVE;
        }
        #endregion
        #region X BUTTON
        //RELEASED
        if (_previous.Buttons.X == ButtonState.Pressed && _current.Buttons.X == ButtonState.Released)
        {
            players[_playerIndex].X = GamePadButtonState.RELEASED;
        }
        //HELD
        else if (_previous.Buttons.X == ButtonState.Pressed && _current.Buttons.X == ButtonState.Pressed)
        {
            players[_playerIndex].X = GamePadButtonState.HELD;
        }
        //PRESSED
        else if (_previous.Buttons.X == ButtonState.Released && _current.Buttons.X == ButtonState.Pressed)
        {
            players[_playerIndex].X = GamePadButtonState.PRESSED;
        }
        //INACTIVE
        else
        {
            players[_playerIndex].X = GamePadButtonState.INACTIVE;
        }
        #endregion

        //shoulder buttons
        #region RIGHT BUMPER
        //RELEASED
        if (_previous.Buttons.LeftShoulder == ButtonState.Pressed && _current.Buttons.LeftShoulder == ButtonState.Released)
        {
            players[_playerIndex].LB = GamePadButtonState.RELEASED;
        }
        //HELD
        else if (_previous.Buttons.LeftShoulder == ButtonState.Pressed && _current.Buttons.LeftShoulder == ButtonState.Pressed)
        {
            players[_playerIndex].LB = GamePadButtonState.HELD;
        }
        //PRESSED
        else if (_previous.Buttons.LeftShoulder == ButtonState.Released && _current.Buttons.LeftShoulder == ButtonState.Pressed)
        {
            players[_playerIndex].LB = GamePadButtonState.PRESSED;
        }
        //INACTIVE
        else
        {
            players[_playerIndex].LB = GamePadButtonState.INACTIVE;
        }
        #endregion
        #region RIGHT BUMPER
        //RELEASED
        if (_previous.Buttons.RightShoulder == ButtonState.Pressed && _current.Buttons.RightShoulder == ButtonState.Released)
        {
            players[_playerIndex].RB = GamePadButtonState.RELEASED;
        }
        //HELD
        else if (_previous.Buttons.RightShoulder == ButtonState.Pressed && _current.Buttons.RightShoulder == ButtonState.Pressed)
        {
            players[_playerIndex].RB = GamePadButtonState.HELD;
        }
        //PRESSED
        else if (_previous.Buttons.RightShoulder == ButtonState.Released && _current.Buttons.RightShoulder == ButtonState.Pressed)
        {
            players[_playerIndex].RB = GamePadButtonState.PRESSED;
        }
        //INACTIVE
        else
        {
            players[_playerIndex].RB = GamePadButtonState.INACTIVE;
        }
        #endregion

        //triggers
        #region LEFT TRIGGER
        //RELEASED
        if (_previous.Triggers.Left > triggerDeadZone && _current.Triggers.Left < triggerDeadZone)
        {
            players[_playerIndex].LT = GamePadButtonState.RELEASED;
            players[_playerIndex].LTValue = _current.Triggers.Left;
        }
        //HELD
        else if (_previous.Triggers.Left > triggerDeadZone && _current.Triggers.Left > triggerDeadZone)
        {
            players[_playerIndex].LT = GamePadButtonState.HELD;
            players[_playerIndex].LTValue = _current.Triggers.Left;
        }
        //PRESSED
        else if (_previous.Triggers.Left < triggerDeadZone && _current.Triggers.Left > triggerDeadZone)
        {
            players[_playerIndex].LT = GamePadButtonState.PRESSED;
            players[_playerIndex].LTValue = _current.Triggers.Left;
        }
        //INACTIVE
        else
        {
            players[_playerIndex].LT = GamePadButtonState.INACTIVE;
            players[_playerIndex].LTValue = _current.Triggers.Left;
        }
        #endregion
        #region RIGHT TRIGGER
        //RELEASED
        if (_previous.Triggers.Right > triggerDeadZone && _current.Triggers.Right < triggerDeadZone)
        {
            players[_playerIndex].RT = GamePadButtonState.RELEASED;
            players[_playerIndex].RTValue = _current.Triggers.Right;
        }
        //HELD
        else if (_previous.Triggers.Right > triggerDeadZone && _current.Triggers.Right > triggerDeadZone)
        {
            players[_playerIndex].RT = GamePadButtonState.HELD;
            players[_playerIndex].RTValue = _current.Triggers.Right;
        }
        //PRESSED
        else if (_previous.Triggers.Right < triggerDeadZone && _current.Triggers.Right > triggerDeadZone)
        {
            players[_playerIndex].RT = GamePadButtonState.PRESSED;
            players[_playerIndex].RTValue = _current.Triggers.Right;
        }
        //INACTIVE
        else
        {
            players[_playerIndex].RT = GamePadButtonState.INACTIVE;
            players[_playerIndex].RTValue = _current.Triggers.Right;
        }
        #endregion

        //misc buttons
        #region SELECT
        //RELEASED
        if (_previous.Buttons.Back == ButtonState.Pressed && _current.Buttons.Back == ButtonState.Released)
        {
            players[_playerIndex].Select = GamePadButtonState.RELEASED;
        }
        //HELD
        else if (_previous.Buttons.Back == ButtonState.Pressed && _current.Buttons.Back == ButtonState.Pressed)
        {
            players[_playerIndex].Select = GamePadButtonState.HELD;
        }
        //PRESSED
        else if (_previous.Buttons.Back == ButtonState.Released && _current.Buttons.Back == ButtonState.Pressed)
        {
            players[_playerIndex].Select = GamePadButtonState.PRESSED;
        }
        //INACTIVE
        else
        {
            players[_playerIndex].Select = GamePadButtonState.INACTIVE;
        }
        #endregion
        #region START
        //RELEASED
        if (_previous.Buttons.Start == ButtonState.Pressed && _current.Buttons.Start == ButtonState.Released)
        {
            players[_playerIndex].Start = GamePadButtonState.RELEASED;
        }
        //HELD
        else if (_previous.Buttons.Start == ButtonState.Pressed && _current.Buttons.Start == ButtonState.Pressed)
        {
            players[_playerIndex].Start = GamePadButtonState.HELD;
        }
        //PRESSED
        else if (_previous.Buttons.Start == ButtonState.Released && _current.Buttons.Start == ButtonState.Pressed)
        {
            players[_playerIndex].Start = GamePadButtonState.PRESSED;
        }
        //INACTIVE
        else
        {
            players[_playerIndex].Start = GamePadButtonState.INACTIVE;
        }
        #endregion

        //dpad buttons
        #region DPAD UP
        //RELEASED
        if (_previous.DPad.Up == ButtonState.Pressed && _current.DPad.Up == ButtonState.Released)
        {
            players[_playerIndex].DPadUp = GamePadButtonState.RELEASED;
        }
        //HELD
        else if (_previous.DPad.Up == ButtonState.Pressed && _current.DPad.Up == ButtonState.Pressed)
        {
            players[_playerIndex].DPadUp = GamePadButtonState.HELD;
        }
        //PRESSED
        else if (_previous.DPad.Up == ButtonState.Released && _current.DPad.Up == ButtonState.Pressed)
        {
            players[_playerIndex].DPadUp = GamePadButtonState.PRESSED;
        }
        //INACTIVE
        else
        {
            players[_playerIndex].DPadUp = GamePadButtonState.INACTIVE;
        }
        #endregion
        #region DPAD RIGHT
        //RELEASED
        if (_previous.DPad.Right == ButtonState.Pressed && _current.DPad.Right == ButtonState.Released)
        {
            players[_playerIndex].DPadRight = GamePadButtonState.RELEASED;
        }
        //HELD
        else if (_previous.DPad.Right == ButtonState.Pressed && _current.DPad.Right == ButtonState.Pressed)
        {
            players[_playerIndex].DPadRight = GamePadButtonState.HELD;
        }
        //PRESSED
        else if (_previous.DPad.Right == ButtonState.Released && _current.DPad.Right == ButtonState.Pressed)
        {
            players[_playerIndex].DPadRight = GamePadButtonState.PRESSED;
        }
        //INACTIVE
        else
        {
            players[_playerIndex].DPadRight = GamePadButtonState.INACTIVE;
        }
        #endregion
        #region DPAD DOWN
        //RELEASED
        if (_previous.DPad.Down == ButtonState.Pressed && _current.DPad.Down == ButtonState.Released)
        {
            players[_playerIndex].DPadDown = GamePadButtonState.RELEASED;
        }
        //HELD
        else if (_previous.DPad.Down == ButtonState.Pressed && _current.DPad.Down == ButtonState.Pressed)
        {
            players[_playerIndex].DPadDown = GamePadButtonState.HELD;
        }
        //PRESSED
        else if (_previous.DPad.Down == ButtonState.Released && _current.DPad.Down == ButtonState.Pressed)
        {
            players[_playerIndex].DPadDown = GamePadButtonState.PRESSED;
        }
        //INACTIVE
        else
        {
            players[_playerIndex].DPadDown = GamePadButtonState.INACTIVE;
        }
        #endregion
        #region DPAD LEFT
        //RELEASED
        if (_previous.DPad.Left == ButtonState.Pressed && _current.DPad.Left == ButtonState.Released)
        {
            players[_playerIndex].DPadLeft = GamePadButtonState.RELEASED;
        }
        //HELD
        else if (_previous.DPad.Left == ButtonState.Pressed && _current.DPad.Left == ButtonState.Pressed)
        {
            players[_playerIndex].DPadLeft = GamePadButtonState.HELD;
        }
        //PRESSED
        else if (_previous.DPad.Left == ButtonState.Released && _current.DPad.Left == ButtonState.Pressed)
        {
            players[_playerIndex].DPadLeft = GamePadButtonState.PRESSED;
        }
        //INACTIVE
        else
        {
            players[_playerIndex].DPadLeft = GamePadButtonState.INACTIVE;
        }
        #endregion

        //analog sticks !REMEMBER that angles are funky (UP is 90° RIGHT = 0°, DOWN = -90°, and LEFT = 180°)
        #region LEFT ANALOG STICK
        //respect deadzones
        if (_current.ThumbSticks.Left.X < -analogStickDeadZone ||
            _current.ThumbSticks.Left.X > analogStickDeadZone ||
            _current.ThumbSticks.Left.Y < -analogStickDeadZone ||
            _current.ThumbSticks.Left.Y > analogStickDeadZone)
        {
            //store value of x and y, along with the angle (UP is 90° RIGHT = 0°, DOWN = -90°, and LEFT = 180°)
            players[_playerIndex].LeftAnalogStick = new Vector2(_current.ThumbSticks.Left.X, _current.ThumbSticks.Left.Y);
            players[_playerIndex].LeftAnalogStickAngle = Mathf.Atan2(_current.ThumbSticks.Left.Y, _current.ThumbSticks.Left.X) * Mathf.Rad2Deg;
        }
        #endregion

        //analog sticks !REMEMBER that angles are funky (UP is 90° RIGHT = 0°, DOWN = -90°, and LEFT = 180°)
        #region RIGHT ANALOG STICK
        //respect deadzones
        if (_current.ThumbSticks.Right.X < -analogStickDeadZone ||
            _current.ThumbSticks.Right.X > analogStickDeadZone ||
            _current.ThumbSticks.Right.Y < -analogStickDeadZone ||
            _current.ThumbSticks.Right.Y > analogStickDeadZone)
        {
            //store value of x and y, along with the angle (UP is 90° RIGHT = 0°, DOWN = -90°, and LEFT = 180°)
            players[_playerIndex].RightAnalogStick = new Vector2(_current.ThumbSticks.Right.X, _current.ThumbSticks.Right.Y);
            players[_playerIndex].RightAnalogStickAngle = Mathf.Atan2(_current.ThumbSticks.Right.Y, _current.ThumbSticks.Right.X) * Mathf.Rad2Deg;
        }
        #endregion
    }


    #endregion
}