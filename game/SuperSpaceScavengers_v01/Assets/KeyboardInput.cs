using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum KeyboardKeyStatus
{
    INACTIVE, HELD, PRESSED, RELEASED
}

public class KeyboardInput : MonoBehaviour
{
    #region STRUCTS

    public struct KeyboardKeyInput
    {
        KeyboardKeyStatus up;
        KeyboardKeyStatus right;
        KeyboardKeyStatus down;
        KeyboardKeyStatus left;
        KeyboardKeyStatus y;
        KeyboardKeyStatus b;
        KeyboardKeyStatus a;
        KeyboardKeyStatus x;
        KeyboardKeyStatus l1;
        KeyboardKeyStatus l2;
        KeyboardKeyStatus l3;
        KeyboardKeyStatus r1;
        KeyboardKeyStatus r2;
        KeyboardKeyStatus r3;
        KeyboardKeyStatus select;
        KeyboardKeyStatus start;
    }

    #endregion

    #region FIELDS

    [Header("Keyboard Controls")]
    [Header("Movement/Directions")]
    public KeyCode up;
    public KeyCode right;
    public KeyCode down;
    public KeyCode left;
    [Header("Standard Buttons")]
    public KeyCode y;
    public KeyCode b;
    public KeyCode a;
    public KeyCode x;
    [Header("Shoulder Buttons")]
    public KeyCode l1;
    public KeyCode l2;
    public KeyCode r1;
    public KeyCode r2;
    [Header("Analog Stick Buttons")]
    public KeyCode l3;
    public KeyCode r3;
    [Header("Misc")]
    public KeyCode select;
    public KeyCode start;


    #endregion

    private List<KeyCode> keys;

    #region INITIALIZATION

    void Awake()
    {

    }

    // Use this for initialization
    void Start ()
    {
        //create keys list
        keys = new List<KeyCode>();

        //check for assigned keys and store them in keys
        AddAssignedKeys();
    }

    #endregion

    /// <summary>
    /// Adds only the assigned buttons to the keys list
    /// </summary>
    void AddAssignedKeys()
    {
        //checking movement keys
        if (up != KeyCode.None)
            keys.Add(up);
        if (right != KeyCode.None)
            keys.Add(right);
        if (down != KeyCode.None)
            keys.Add(down);
        if (left != KeyCode.None)
            keys.Add(left);

        //checking standard button/keys
        if (y != KeyCode.None)
            keys.Add(y);
        if (b != KeyCode.None)
            keys.Add(b);
        if (a != KeyCode.None)
            keys.Add(a);
        if (x != KeyCode.None)
            keys.Add(x);

        //checking shoulder button/keys
        if (l1 != KeyCode.None)
            keys.Add(l1);
        if (l2 != KeyCode.None)
            keys.Add(l2);
        if (r1 != KeyCode.None)
            keys.Add(r1);
        if (r2 != KeyCode.None)
            keys.Add(r2);

        //checking analog button/keys
        if (l3 != KeyCode.None)
            keys.Add(l3);
        if (r3 != KeyCode.None)
            keys.Add(r3);

        //checking misc button/keys
        if (select != KeyCode.None)
            keys.Add(select);
        if (start != KeyCode.None)
            keys.Add(start);

        print("the contents of keys are: ");
        foreach(KeyCode key in keys)
        {
            print(key + ", ");
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
        UpdateKeyboardInput();
	}

    void UpdateKeyboardInput()
    {
    }

}
