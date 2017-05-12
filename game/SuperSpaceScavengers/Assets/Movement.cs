///////////////////////////////////////////////////////////////////////////////////////////////////
//AUTHOR — Travis Moore
//SCRIPT — Movement.cs
///////////////////////////////////////////////////////////////////////////////////////////////////

//#pragma warning disable 0169
//#pragma warning disable 0649
//#pragma warning disable 0108
//#pragma warning disable 0414

using UnityEngine;
using System.Collections;
using System;
//using System.Collections.Generic;
//using UnityEngine.UI;

#region ENUMS
//public enum EnumStatus
//{
//	
//};
#endregion

#region EVENTS
//public class EVENT_EXAMPLE : GameEvent
//{
//    public EVENT_EXAMPLE() { }
//}
#endregion

public class Movement : MonoBehaviour
{
    #region FIELDS
    [Header("MOVEMENT TYPE")]
    public bool isMovement2D;
    public bool isCameraRelative;
    public Transform targetCameraTransform;
    [HideInInspector]
    public bool movementEnabled = true;

    [Header("MODEL")]
    [SerializeField]
    GameObject character;
    [SerializeField]
    bool isSprite;
    SpriteRenderer sr;
    Transform tr;
    Rigidbody rb;
    

    [Header("VELOCITY")]
    [SerializeField]
    float speed = 10f;
    [SerializeField]
    AnimationCurve acceleration;

    [Header("ROTATION")]
    [SerializeField]
    bool rotateToDirection;
    public float rotationSpeed;
    [SerializeField]
    AnimationCurve rotationCurve;
    Quaternion inputRotation;

    [Header("GROUND")]
    [SerializeField]
    float groundCheckDistance = 1f;
    [SerializeField]
    Vector3 baseCornerOffset;
    [SerializeField]
    float maxSlopeAngle = 45f;
    [HideInInspector]
    public GameObject ground;
    int groundContacts = 0;
    Vector3 averageGroundNormal;

    [Header("GRAVITY")]
    public bool additionalGravity;
    public float gravity = 10f;
    public float groundGravityRatio = 0.1f;

    InputData leftStick;


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
        if(character != null)
        {
            tr = character.GetComponent<Transform>();
            rb = character.GetComponent<Rigidbody>();
        }
        if(isSprite)
        {
            sr = character.GetComponentInChildren<SpriteRenderer>();
        }
        //set/check initial values
        groundContacts = 0;

    }
    ///////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>
    /// Awake
    /// </summary>
    ///////////////////////////////////////////////////////////////////////////////////////////////
    void Awake()
    {
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
        leftStick = XBoxGamepadInput.gamepads[0].ls;
    }
    ///////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>
    /// SetSubscriptions
    /// </summary>
    ///////////////////////////////////////////////////////////////////////////////////////////////
    void SetSubscriptions()
    {

    }
    #endregion

    #region UPDATE
    ///////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>
    /// Update()
    /// </summary>
    ///////////////////////////////////////////////////////////////////////////////////////////////
    void FixedUpdate()
    {
        if(movementEnabled && this.gameObject != null)
        {
            //check the ground
            UpdateGroundContacts();
            if (rotateToDirection)
            {
                ApplyRotation();
            }
            ApplyMovement();

            if(additionalGravity)
            {
                ApplyAdditionalGravity();
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
    /// Check the ground by casting rays from the player base to the ground
    /// </summary>
    ///////////////////////////////////////////////////////////////////////////////////////////////
    void UpdateGroundContacts()
    {
        //reset
        groundContacts = 0;
        averageGroundNormal = Vector3.zero;

        //create 9 rays in a cube shape
        CastRayWithOffset(0, 1, 0);
        CastRayWithOffset(1, 1, 0);
        CastRayWithOffset(0, 1, 1);
        CastRayWithOffset(-1, 1, 0);
        CastRayWithOffset(0, 1, -1);
        CastRayWithOffset(1, 1, 1);
        CastRayWithOffset(-1, 1, 1);
        CastRayWithOffset(-1, 1, -1);
        CastRayWithOffset(1, 1, -1);

        //get the averageGroundNormal based on # of groundContacts
        averageGroundNormal /= groundContacts;

        //if there are no groundContacts, we're jumping, set ground to null
        if (groundContacts == 0)
        {
            averageGroundNormal = Vector3.up;
            ground = null;
        }
    }
    ///////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>
    /// casts a ray whose base is set by passed parameters
    /// </summary>
    /// <param name="_x"></param>
    /// <param name="_y"></param>
    /// <param name="_z"></param>
    ///////////////////////////////////////////////////////////////////////////////////////////////
    void CastRayWithOffset(int _x, int _y, int _z)
    {
        //apply the offset
        Vector3 _cornerOffset = baseCornerOffset;
        _cornerOffset.x *= _x;
        _cornerOffset.y *= _y;
        _cornerOffset.z *= _z;

        //setup the pos to draw a line, then draw it
        Vector3 _lineStart = this.transform.TransformPoint(_cornerOffset);
        Debug.DrawLine(_lineStart, _lineStart - (Vector3.up * groundCheckDistance), Color.green, 0, false);

        foreach (RaycastHit hitInfo in Physics.RaycastAll(_lineStart, -Vector3.up, groundCheckDistance))
        {
            if (hitInfo.collider.transform.root == this.transform)
                continue;

            if (hitInfo.collider != null)
                ground = hitInfo.collider.transform.root.gameObject;

            //print(Vector3.Angle(hitInfo.normal, Vector3.up));
            if (Vector3.Angle(hitInfo.normal, Vector3.up) < maxSlopeAngle)
            {
                ++groundContacts;
                averageGroundNormal += hitInfo.normal;
                //print("Ground Normal from hitInfo normal: " + hitInfo.normal);
                break;
            }
        }
    }
    ///////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>
    /// 
    /// </summary>
    ///////////////////////////////////////////////////////////////////////////////////////////////
    void ApplyRotation()
    {
        //get angle between where we face now and where input wants us to face
        float _angle = Quaternion.Angle(tr.rotation, inputRotation);
        //use the rotationCurve to get updatedAngle
        float _rotationCurveAngle = rotationCurve.Evaluate(_angle / 180);
        //apply rotation based on where we are now, where we want to go, at a speed that is determined
        //by the rotation speed, rotationCurve angle, and time
        tr.rotation = Quaternion.RotateTowards(tr.rotation,
                                               inputRotation,
                                               (rotationSpeed * 180 * _rotationCurveAngle * Time.deltaTime));
    }
    ///////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>
    /// applies additional gravity upon the player
    /// </summary>
    ///////////////////////////////////////////////////////////////////////////////////////////////
    void ApplyAdditionalGravity()
    {
        //on ground gravity
        if (groundContacts > 0)
        {
            rb.AddForce(new Vector3(0, -gravity * 10 * groundGravityRatio, 0) * Time.deltaTime * 60);
        }
        //in air gravity
        else
        {
            rb.AddForce(new Vector3(0, -gravity * 10, 0) * Time.deltaTime * 60);
        }
    }
    ///////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>
    /// applies additional gravity upon the player
    /// </summary>
    ///////////////////////////////////////////////////////////////////////////////////////////////
    void ApplyMovement()
    {
        Vector3 rawInput = new Vector3(leftStick.XYValues.x, leftStick.XYValues.y, 0f);
        //if we're 2D movement, adjust _input to match 2D gameplay (switch out z for y, zero out y)
        if (isMovement2D)
        {
            rawInput = new Vector3(leftStick.XYValues.x, 0f, leftStick.XYValues.y);
        }

        //new variable to store this input, don't want to change raw input
        Vector3 _movement = rawInput;
        //print("START! movement is set to initial input = " + leftStick);
        
        if(isSprite)
        {
            DetermineSpriteFacing(rawInput.x);
        }


        //starting magnitude
        float _inputMagnitude = 1f;

        //movement should be relative to the camera
        if (isCameraRelative && targetCameraTransform != null)
        {
            _inputMagnitude = Mathf.Clamp01(_movement.magnitude);
            _movement = targetCameraTransform.TransformDirection(_movement);

            //print("movement is set relative to camera = " + _movement);
        }

        _movement = Vector3.ProjectOnPlane(rawInput, Vector3.up);
        //print("movement is projected on a plane = " + _movement);

        //update inputRotation
        if (_movement != Vector3.zero)
            this.inputRotation = Quaternion.LookRotation(_movement, Vector3.up);


        _movement.Normalize();
        //print("movement is now normalized = " + _movement);
        _movement *= speed * _inputMagnitude;
        //print("movement is * moveSpeed(" + speed + ") and * inputMagnitude(" + _inputMagnitude + ") = " + _movement);

        //Inherit velocity from the thing under us
        if (ground != null)
        {
            //print (this.GroundObject);

            Rigidbody _groundRigidbody = ground.GetComponent<Rigidbody>();
            if (_groundRigidbody != null)
            {
                _movement += _groundRigidbody.velocity;
                //print("movement is inheriting from ground = " + _movement);
            }
        }

        Vector3 newVelocity = new Vector3(_movement.x, rb.velocity.y, _movement.z) * Time.deltaTime * 60;
        //print("newVelocity = " + newVelocity);
        rb.velocity = Vector3.Lerp(rb.velocity, newVelocity, acceleration.Evaluate(Time.deltaTime));
    }
    ///////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>
    /// assigns the latest gamepad input to leftStick
    /// </summary>
    /// <param name="_event"></param>
    ///////////////////////////////////////////////////////////////////////////////////////////////
    void UpdateInput(EVENT_GAMEPAD_P1 _event)
    {
        leftStick = _event.gamepad.ls;
    }
    ///////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>
    /// flips the sprite according to input's x value
    /// </summary>
    /// <param name="_x">negative == left, positive == right</param>
    ///////////////////////////////////////////////////////////////////////////////////////////////
    void DetermineSpriteFacing(float _x)
    {
        if(_x > 0f && sr.flipX)
        {
            sr.flipX = false;
        }
        else if(_x < 0f && !sr.flipX)
        {
            sr.flipX = true;
        }
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