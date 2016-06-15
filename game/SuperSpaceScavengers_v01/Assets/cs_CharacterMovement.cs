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
    #region PROPERTIES
    //references
    private GameObject Model;
    private Rigidbody RBody;
    private CapsuleCollider CCollider;
    private cs_PlayerInput PInput;
    private CurrentInput CInput;

    //attributes
    public float WalkSpeed = 3f;
    public float RunSpeed = 9f;
    public float JumpSpeed = 500f;
    public bool HasAirControl = false;
    public Vector2 WallClingGravity = new Vector2(0f, 1f);

    //ground
    [SerializeField]
    private LayerMask LayerThatIsGround;
    private Transform GroundCheck;
    private bool IsGrounded = false;
    private bool IsCurrentlyJumping = false;
    float GroundedRadius = 0.2f;
    float GroundCheckDistance = 0.1f;
    Vector3 GroundNormal;

    //components
    private Animator Animator;
    private Rigidbody Rigidbody;

    #endregion

    #region INITIALIZATION

    /*////////////////////////////////////////////////////////////////////
    //Awake()
    ////////////////////////////////////////////////////////////////////*/
    void Awake()
    {
        //get references
        PInput = GetComponent<cs_PlayerInput>();
        CInput = PInput.CurrentInput;
        Model = transform.Find("Model").gameObject;
        RBody = Model.GetComponent<Rigidbody>();
        CCollider = Model.GetComponent<CapsuleCollider>();
    }

    /*////////////////////////////////////////////////////////////////////
    //Start()
    ////////////////////////////////////////////////////////////////////*/
    void Start()
    {

    }

    #endregion

    #region UPDATE

    /*////////////////////////////////////////////////////////////////////
    //FUNCTION: FixedUpdate() <-- better physics
    ////////////////////////////////////////////////////////////////////*/
    void FixedUpdate()
    {
        //first things first, get the most current input
        CInput = PInput.CurrentInput;

        //check to make sure the character is grounded
        this.CheckIfGrounded();

        //update the movement of this character
        this.UpdateMovement(CInput.ThumbstickInput);

        //update jumping
        //this.UpdateJumping(this.CurrentInput.JumpInput);
    }

    #endregion

    #region X_FUNC

    /*////////////////////////////////////////////////////////////////////
    //CheckIfGrounded()
    ////////////////////////////////////////////////////////////////////*/
    void CheckIfGrounded()
    {
        RaycastHit HitInfo;
        Debug.DrawLine((transform.position + (Vector3.up * 0.1f)),
                       (transform.position + (Vector3.up * 0.1f)) + (Vector3.down * GroundCheckDistance));

        if(Physics.Raycast(transform.position + (Vector3.up * 0.1f), Vector3.down, out HitInfo, GroundCheckDistance))
        {
            GroundNormal = HitInfo.normal;
            IsGrounded = true;
        }
        else
        {
            GroundNormal = Vector3.up;
            IsGrounded = false;
        }
    }

    /*////////////////////////////////////////////////////////////////////
    //UpdateMovement()
    ////////////////////////////////////////////////////////////////////*/
    void UpdateMovement(Vector2 moveInput_)
    {
        //print(moveInput_);

        Vector3 finalVelocity = new Vector3((moveInput_.x * WalkSpeed),
                                            0f,
                                            (moveInput_.y * WalkSpeed));

        RBody.velocity = finalVelocity;
    }

    /*////////////////////////////////////////////////////////////////////
    //UpdateJumping()
    ////////////////////////////////////////////////////////////////////*/
    void UpdateJumping()
    {

    }

    /*////////////////////////////////////////////////////////////////////
    //X_FUNC4()
    ////////////////////////////////////////////////////////////////////*/
    void X_FUNC4()
    {

    }

    /*////////////////////////////////////////////////////////////////////
    //X_FUNC5()
    ////////////////////////////////////////////////////////////////////*/
    void X_FUNC5()
    {

    }

    /*////////////////////////////////////////////////////////////////////
    //X_FUNC6()
    ////////////////////////////////////////////////////////////////////*/
    void X_FUNC6()
    {

    }

    /*////////////////////////////////////////////////////////////////////
    //X_FUNC7()
    ////////////////////////////////////////////////////////////////////*/
    void X_FUNC7()
    {

    }

    /*////////////////////////////////////////////////////////////////////
    //X_FUNC8()
    ////////////////////////////////////////////////////////////////////*/
    void X_FUNC8()
    {

    }

    /*////////////////////////////////////////////////////////////////////
    //X_FUNC9()
    ////////////////////////////////////////////////////////////////////*/
    void X_FUNC9()
    {

    }

    #endregion

}