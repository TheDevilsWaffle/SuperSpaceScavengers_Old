///////////////////////////////////////////////////////////////////////////////////////////////////
//AUTHOR — Travis Moore
//SCRIPT — XBoxGamepadInput.cs
///////////////////////////////////////////////////////////////////////////////////////////////////

//#pragma warning disable 0169
//#pragma warning disable 0649
//#pragma warning disable 0108
//#pragma warning disable 0414

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using XInputDotNetPure;

#region ENUMS
public enum XBoxButtons
{
    Y, B, A, X,
    SELECT, START,
    LT, RT, LB, RB,
    DP_UP, DP_RIGHT, DP_DOWN, DP_LEFT,
    LS, RS, L3, R3
};
#endregion

#region EVENTS
//public class EVENT_EXAMPLE : GameEvent
//{
//    public EVENT_EXAMPLE() { }
//}
#endregion

public class XBoxGamepadInput : MonoBehaviour
{
    #region FIELDS
    [Header("ENABLE/DISABLE")]
    public bool isEnabled = true;

    [Header("PLAYER")]
    [Range(1, 4)]
    [SerializeField]
    public static int playerCount = 1;

    [Header("DEAD ZONES")]
    [Range(0, 1)]
    [SerializeField]
    float triggerDeadZone = 0.2f;
    [Range(0, 1)]
    [SerializeField]
    float analogStickDeadZone = 0.2f;

    [Header("MAX")]
    [SerializeField]
    float maxHeldDuration = 10f;
    [SerializeField]
    float maxInactiveDuration = 10f;
    [SerializeField]
    int maxButtonsRemembered = 10;

    GamePadState currentState;
    GamePadState previousState;
    [HideInInspector]
    public static List<XBoxGamepadData> gamepads;
    [HideInInspector]
    public static Queue<XBoxButtons> combo;
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
        gamepads = new List<XBoxGamepadData>();
    }
    ///////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>
    /// Awake
    /// </summary>
    ///////////////////////////////////////////////////////////////////////////////////////////////
    void Awake()
    {
        if (isEnabled)
        {
            //popluate list of players based on numberOfPlayers
            for (int i = 0; i < playerCount; ++i)
            {
                GamePadState _testState = GamePad.GetState((PlayerIndex)i);
                if (_testState.IsConnected)
                {
                    gamepads.Add(new XBoxGamepadData());
                }
            }
        }

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
        //gamepad enabled? go through the update loop
        if (isEnabled)
        {
            for (int i = 0; i < playerCount; ++i)
            {
                //first test to make sure there's a controller there to update
                GamePadState _testState = GamePad.GetState((PlayerIndex)i);
                if (_testState.IsConnected)
                {
                    //update the previous and currentstate
                    previousState = currentState;
                    currentState = GamePad.GetState((PlayerIndex)i);

                    //check the gamepad buttons
                    
                    UpdateDPad(i, previousState, currentState);
                    UpdateSticks(i, previousState, currentState);
                    UpdateButtons(i, previousState, currentState);
                    UpdateBumpers(i, previousState, currentState);
                    UpdateTriggers(i, previousState, currentState);
                }
                else
                {
                    Debug.LogWarning("WARNING! Player(" + i + ") no longer exists? ");
                }
            }
        }

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
    /// <summary>
    /// Checks the INACTIVE, PRESSED, HELD, and RELEASED status of buttons
    /// </summary>
    /// <param name="_previous">last frame GamePad Input</param>
    /// <param name="_current">current frame GamePad Input</param>
    ////////////////////////////////////////////////////////////////////////////////////////////////
    void CheckButtons(int _index, GamePadState _previous, GamePadState _current)
    {
        #region Y BUTTON
        //RELEASED
        if (_previous.Buttons.Y == ButtonState.Pressed && _current.Buttons.Y == ButtonState.Released)
        {
            gamepads[_index].y.SetXYValue(0f, 0f);

            gamepads[_index].y.SetStatus(InputStatus.RELEASED);
            gamepads[_index].y.SetHeldDuration(0f);
            gamepads[_index].y.SetInactiveDuration(Time.deltaTime);
        }
        //HELD
        else if (_previous.Buttons.Y == ButtonState.Pressed && _current.Buttons.Y == ButtonState.Pressed)
        {
            gamepads[_index].y.SetStatus(InputStatus.HELD);
            gamepads[_index].y.SetHeldDuration(Time.deltaTime);
        }
        //PRESSED
        else if (_previous.Buttons.Y == ButtonState.Released && _current.Buttons.Y == ButtonState.Pressed)
        {
            gamepads[_index].y.SetXYValue(1f, 1f);

            gamepads[_index].y.SetStatus(InputStatus.PRESSED);
            gamepads[_index].y.SetHeldDuration(Time.deltaTime);
            gamepads[_index].y.SetInactiveDuration(0f);
        }
        //INACTIVE
        else
        {
            gamepads[_index].y.SetXYValue(0f, 0f);

            gamepads[_index].y.SetStatus(InputStatus.INACTIVE);
            gamepads[_index].y.SetInactiveDuration(Time.deltaTime);
        }
        #endregion
    }
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