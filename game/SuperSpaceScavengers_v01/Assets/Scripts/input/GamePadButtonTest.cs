///////////////////////////////////////////////////////////////////////////////////////////////////
//AUTHOR — Travis Moore
//SCRIPT — GamePadButtonTest.cs
//COPYRIGHT — © 2016 DigiPen Institute of Technology
///////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using XInputDotNetPure; // Required in C#

public class GamePadButtonTest : GamePadButtonBase
{
    protected override void Start() { base.Start(); }
    protected override void Update() { base.Update(); }


    public override void ButtonFunctionality()
    {
        print("poops");
    }
}
