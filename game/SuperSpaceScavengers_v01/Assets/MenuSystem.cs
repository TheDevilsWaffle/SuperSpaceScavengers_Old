///////////////////////////////////////////////////////////////////////////////////////////////////
//AUTHOR — Travis Moore
//SCRIPT — MenuSystem.cs
//COPYRIGHT — © 2016 DigiPen Institute of Technology
///////////////////////////////////////////////////////////////////////////////////////////////////

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

#region ENUMS

#endregion

public class MenuSystem : MonoBehaviour
{
    #region FIELDS
    [Header("FIRST MENU")]
    public Menu firstMenu;
    float delayBeforeLoad = 0.25f;
    GamePadInputData p1;
    Menu currentMenu;
    string previousMenu;
    ButtonBase currentButton;
    Stack<Menu> menuStack;
    float menuInputDelay = 0.25f;
    float timer = 0f;
    float leftAnalogStickThreshold = 0.85f;



    #endregion

    #region INITIALIZATION
    ///////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>
    /// Awake()
    /// </summary>
    ///////////////////////////////////////////////////////////////////////////////////////////////
    void Awake()
    {
        //set previous menu to blank
        previousMenu = " ";
        //set the timer
        timer = 0f;

        //create the stack
        menuStack = new Stack<Menu>();

        //add the firstMenu
        if (firstMenu == null)
            Debug.LogError("firstMenu is NULL! Please designate a first menu for the menu system.");
    }

    ///////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>
    /// Start()
    /// </summary>
    ///////////////////////////////////////////////////////////////////////////////////////////////
    void Start()
    {
        currentMenu = firstMenu;
        menuStack.Push(firstMenu);
        //activate firstMenu in case it is inactive
        StartCoroutine(LoadNewMenu(firstMenu));

        //subscribe to events
        //Events.instance.AddListener<Event_GamePadInput_Player1>(RespondToGamePadInput);
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
        //get latest input
        p1 = GamePadInput.players[0];

        //add to the timer
        timer += Time.deltaTime;

        RespondToGamePadButtonInput();
        //only respond to menu input if we're above the menuInputDelay threshold
        if (timer > menuInputDelay)
        {
            RespondToGamePadDirectionalInput();
        }
    }
    #endregion

    #region METHODS
    ///////////////////////////////////////////////////////////////////////////////////////////////

    ///////////////////////////////////////////////////////////////////////////////////////////////
    public IEnumerator LoadNewMenu(Menu _menu)
    {
        yield return new WaitForSeconds(delayBeforeLoad);

        //disable the last currentMenu
        if (currentMenu != null)
        {
            currentMenu.GetComponent<Canvas>().enabled = false;
        }

        //if we're not pushing in the last menu we were on, add a new menu to the stack
        if (_menu.name != previousMenu && menuStack.Count >= 0)
        {
            previousMenu = currentMenu.name;
            menuStack.Push(_menu);
        }
        //otherwise, pop out the current menu to go to the last one
        else
        {
            previousMenu = currentMenu.name;
            menuStack.Pop();
        }
        //set this menu to currentMenu and enable it
        currentMenu = menuStack.Peek();

        //enable
        currentMenu.GetComponent<Canvas>().enabled = true;

        //assign currentButton
        currentButton = currentMenu.firstButtonToHover;

        print("new current menu = " + currentMenu.name + " and new previous menu = " + previousMenu);
        print("stack size is currently " + menuStack.Count);
    }

    /// <summary>
    /// 
    /// </summary>
    void RespondToGamePadDirectionalInput()
    {
        #region DPADS
        if (p1.DPadUp == GamePadButtonState.PRESSED  ||
            p1.DPadUp == GamePadButtonState.HELD && 
            currentButton.up != null)
        {
            currentButton.Inactive();
            currentButton = currentButton.up;
            currentButton.Hover();
            timer = 0f;
        }
        else if (p1.DPadRight == GamePadButtonState.PRESSED ||
                 p1.DPadRight == GamePadButtonState.HELD && 
                 currentButton.right != null)
        {
            currentButton.Inactive();
            currentButton = currentButton.right;
            currentButton.Hover();
            timer = 0f;
        }
        else if (p1.DPadDown == GamePadButtonState.PRESSED ||
                 p1.DPadDown == GamePadButtonState.HELD && 
                 currentButton.down != null)
        {
            currentButton.Inactive();
            currentButton = currentButton.down;
            currentButton.Hover();
            timer = 0f;
        }
        else if (p1.DPadLeft == GamePadButtonState.PRESSED ||
                 p1.DPadLeft == GamePadButtonState.HELD && 
                 currentButton.left != null)
        {
            currentButton.Inactive();
            currentButton = currentButton.left;
            currentButton.Hover();
            timer = 0f;
        }
        #endregion
        #region LEFT ANALOG STICK
        if (p1.LeftAnalogStick.y > leftAnalogStickThreshold && currentButton.up != null)
        {
            currentButton.Inactive();
            currentButton = currentButton.up;
            currentButton.Hover();
            timer = 0f;
        }
        else if (p1.LeftAnalogStick.x > leftAnalogStickThreshold && currentButton.right != null)
        {
            currentButton.Inactive();
            currentButton = currentButton.right;
            currentButton.Hover();
            timer = 0f;
        }
        else if (p1.LeftAnalogStick.y < -leftAnalogStickThreshold && currentButton.down != null)
        {
            currentButton.Inactive();
            currentButton = currentButton.down;
            currentButton.Hover();
            timer = 0f;
        }
        else if (p1.LeftAnalogStick.x < -leftAnalogStickThreshold && currentButton.left != null)
        {
            currentButton.Inactive();
            currentButton = currentButton.left;
            currentButton.Hover();
            timer = 0f;
        }
        #endregion
    }

    /// <summary>
    /// 
    /// </summary>
    void RespondToGamePadButtonInput()
    {
        if (currentButton != null)
        {
            #region A
            if (p1.A == GamePadButtonState.RELEASED)
            {
                currentButton.Hover();
            }
            else if (p1.A == GamePadButtonState.PRESSED && currentButton.currentState != MenuButtonState.DISABLED)
            {
                currentButton.Active();
            }
            else if (p1.A == GamePadButtonState.PRESSED && currentButton.currentState == MenuButtonState.DISABLED)
            {
                currentButton.Disabled();
            }
            #endregion
            #region B
            if (p1.B == GamePadButtonState.RELEASED)
            {
                //something
            }

            else if (p1.B == GamePadButtonState.PRESSED)
            {
                //something
            }
            #endregion
        }
    }
    #endregion
}
