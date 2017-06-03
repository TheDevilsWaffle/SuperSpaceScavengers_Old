///////////////////////////////////////////////////////////////////////////////////////////////////
//AUTHOR — Travis Moore
//SCRIPT — ShootGun.cs
///////////////////////////////////////////////////////////////////////////////////////////////////

//#pragma warning disable 0169
//#pragma warning disable 0649
//#pragma warning disable 0108
//#pragma warning disable 0414

using UnityEngine;
using System.Collections;
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

public class ShootGun : InputActionBase
{
    #region FIELDS

    [SerializeField]
    Transform gun;
    [SerializeField]
    GameObject projectile;
    [SerializeField]
    float speed;
    [SerializeField]
    float shootCooldown;
    float timer = 0f;
    bool canShoot = true;

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
        timer = 0f;
        canShoot = true;
    }
    ///////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>
    /// Awake
    /// </summary>
    ///////////////////////////////////////////////////////////////////////////////////////////////
    protected override void Awake()
    {
        base.Awake();
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
    protected override void SetSubscriptions()
    {
        base.SetSubscriptions();
        //Events.instance.AddListener<>();
    }
    #endregion

    #region UPDATE
    ///////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>
    /// Update
    /// </summary>
    ///////////////////////////////////////////////////////////////////////////////////////////////
    void Update()
    {
        
        if(timer > shootCooldown)
        {
            canShoot = true;
        }
        else
        {
            timer += Time.deltaTime;
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
    void Shoot()
    {
        if(canShoot)
        {
            GameObject _projectile = Instantiate(projectile, gun.position, gun.rotation);
            //Debug.Log("Created " + _projectile.gameObject.name);
            _projectile.GetComponent<Projectile>().Initialize(speed, gun.right);
            _projectile.GetComponent<Projectile>().Fire();

            timer = 0f;
            canShoot = false;
        }
    }
    ///////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>
    /// OnReleased
    /// </summary>
    /// <param name="_input"></param>
    ///////////////////////////////////////////////////////////////////////////////////////////////
    protected override void OnReleased(InputData _input)
    {
        //print(_input.Name + " was released!");
    }
    ///////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>
    /// OnPressed
    /// </summary>
    /// <param name="_input"></param>
    ///////////////////////////////////////////////////////////////////////////////////////////////
    protected override void OnPressed(InputData _input)
    {
        //print(_input.Name + " was pressed!");
        Shoot();
    }
    ///////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>
    /// OnHeld
    /// </summary>
    /// <param name="_input"></param>
    ///////////////////////////////////////////////////////////////////////////////////////////////
    protected override void OnHeld(InputData _input)
    {
        //print(_input.Name + " is held!");
    }
    ///////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>
    /// NEVER USE THIS!
    /// </summary>
    /// <param name="_input"></param>
    ///////////////////////////////////////////////////////////////////////////////////////////////
    protected override void OnInactive(InputData _input)
    {
        //print(_input.Name + " is inactive!");
    }
    #endregion

    #region ONDESTORY
    ///////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>
    /// OnDestroy
    /// </summary>
    ///////////////////////////////////////////////////////////////////////////////////////////////
    protected override void OnDestroy()
    {
        base.OnDestroy();

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
        if (Input.GetKeyDown(KeyCode.Keypad0))
        {

        }
        //Keypad 1
        if (Input.GetKeyDown(KeyCode.Keypad1))
        {

        }
        //Keypad 2
        if (Input.GetKeyDown(KeyCode.Keypad2))
        {

        }
        //Keypad 3
        if (Input.GetKeyDown(KeyCode.Keypad3))
        {

        }
        //Keypad 4
        if (Input.GetKeyDown(KeyCode.Keypad4))
        {

        }
        //Keypad 5
        if (Input.GetKeyDown(KeyCode.Keypad5))
        {

        }
        //Keypad 6
        if (Input.GetKeyDown(KeyCode.Keypad6))
        {

        }
    }
    #endregion
}