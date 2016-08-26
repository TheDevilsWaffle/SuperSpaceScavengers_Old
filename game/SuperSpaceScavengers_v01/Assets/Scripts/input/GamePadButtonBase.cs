///////////////////////////////////////////////////////////////////////////////////////////////////
//AUTHOR — Travis Moore
//SCRIPT — GamePadButtonBase.cs
//COPYRIGHT — © 2016 DigiPen Institute of Technology
///////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using XInputDotNetPure; // Required in C#

public class GamePadButtonBase : GamePadInput
{
    protected override void Start () { base.Start(); }
	protected override void Update () { base.Update(); }

    public virtual void ButtonFunctionality() { }


}
