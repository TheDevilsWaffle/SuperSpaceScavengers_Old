/*////////////////////////////////////////////////////////////////////////
//SCRIPT: cs_PlayerInput.cs
//AUTHOR: Travis Moore
////////////////////////////////////////////////////////////////////////*/

#pragma warning disable 0168 // variable declared but not used.
#pragma warning disable 0219 // variable assigned but not used.
#pragma warning disable 0414 // private field assigned but not used.

using UnityEngine;
using System.Collections;
using XInputDotNetPure; // Required in C#

#region STRUCTS

public struct CurrentInput
{
    public Vector2 ThumbstickInput;
}

#endregion

public class cs_PlayerInput : MonoBehaviour
{
    #region PROPERTIES

    [Header("PLAYER")]
    [SerializeField]
    [Range(0, 3)]
    public int PlayerNumber = 0;


    private PlayerIndex Player;
    private GamePadState CurrentState;
    private GamePadState PreviousState;
    public CurrentInput CurrentInput;
    private Vector2 CurrentThumbstickInput;

    #endregion

    #region INITIALIZE

    /*////////////////////////////////////////////////////////////////////
    //Start()
    ////////////////////////////////////////////////////////////////////*/
    void Start()
    {
        //set PlayerIndex = PlayerNumber
        this.Player = (PlayerIndex)this.PlayerNumber;
    }

    #endregion

    #region UPDATE

    /*////////////////////////////////////////////////////////////////////
    //Update()
    ////////////////////////////////////////////////////////////////////*/
    void Update()
    {
        //update the gamepad states every update
        this.UpdateGamepadStates(this.Player);


        this.UpdateThumbstickInput(this.CurrentState);


        this.UpdatePlayerInput();
    }

    #endregion

    #region GAMEPAD UPDATES

    /*////////////////////////////////////////////////////////////////////
    //UpdateGamepadStates(PlayerIndex)
    ////////////////////////////////////////////////////////////////////*/
    void UpdateGamepadStates(PlayerIndex player_)
    {
        this.PreviousState = this.CurrentState;
        this.CurrentState = GamePad.GetState(player_);
    }

    /*////////////////////////////////////////////////////////////////////
    //UpdateThumbstickInput(GamePadState,)
    ////////////////////////////////////////////////////////////////////*/
    void UpdateThumbstickInput(GamePadState current_)
    {
        //GAMEPAD SUPPORT
        this.CurrentThumbstickInput = new Vector2(current_.ThumbSticks.Left.X, 
                                                  current_.ThumbSticks.Left.Y);
    }

    /*////////////////////////////////////////////////////////////////////
    //FUNCTION: UpdateDialogueButton()
    ////////////////////////////////////////////////////////////////////*/
    void UpdateDialogueButton(GamePadState current_, GamePadState previous_)
    {
        //pressing A
        if (current_.Buttons.A == ButtonState.Pressed 
            && previous_.Buttons.A == ButtonState.Released)
        {
            print("Gamepad A was pressed");
        }
    }

    #endregion

    #region UPDATE PLAYER INPUT

    /*////////////////////////////////////////////////////////////////////
    //FUNCTION: UpdatePlayerInput()
    ////////////////////////////////////////////////////////////////////*/
    void UpdatePlayerInput()
    {
        this.CurrentInput = new CurrentInput()
        {
            ThumbstickInput = this.CurrentThumbstickInput
        };
    }

    #endregion

}
