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

public class GamePadInput : MonoBehaviour
{
    #region FIELDS

    [Header("PLAYERS")]
    [Range(1, 4)]
    public uint player = 1;

    bool playerIndexSet = false;
    PlayerIndex playerIndex;
    GamePadState state;
    GamePadState prevState;

    public GamePadButtonBase AButton;

    #endregion

    #region INITIALIZATION

    protected virtual void Start()
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

    protected virtual void Update()
    {
        //update the state
        prevState = state;
        state = GamePad.GetState(playerIndex);

        CheckGamePadButtons(prevState, state);

    }

    #endregion

    #region METHODS

    void CheckGamePadButtons(GamePadState _previous, GamePadState _current)
    {
        if(_previous.Buttons.A == ButtonState.Released && _current.Buttons.A == ButtonState.Pressed)
        {
            AButton.ButtonFunctionality();
        }
    }


    #endregion
}