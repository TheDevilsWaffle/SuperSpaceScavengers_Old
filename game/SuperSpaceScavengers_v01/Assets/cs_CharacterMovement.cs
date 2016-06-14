/*////////////////////////////////////////////////////////////////////////
//SCRIPT: cs_CharacterMovement.cs
//AUTHOR: Travis Moore
//COPYRIGHT: © 2016 DigiPen Institute of Technology, All Rights Reserved
////////////////////////////////////////////////////////////////////////*/

#pragma warning disable 0168 // variable declared but not used.
#pragma warning disable 0219 // variable assigned but not used.
#pragma warning disable 0414 // private field assigned but not used.

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class cs_CharacterMovement : MonoBehaviour
{
    //attributes
    public float WalkSpeed = 3f;
    public float RunSpeed = 9f;
    public float JumpSpeed = 500f;
    public bool HasAirControl = false;
    public bool FacingRight = true;
    public Vector2 WallClingGravity = new Vector2(0f, 1f);

    //ground
    [SerializeField]
    private LayerMask LayerThatIsGround;
    private Transform GroundCheck;
    private bool IsGrounded = false;
    private bool IsCurrentlyJumping = false;
    float GroundedRadius = 0.2f;

    //components
    private Animator Animator;
    private Rigidbody Rigidbody;
    private MyInput CurrentInput;

}