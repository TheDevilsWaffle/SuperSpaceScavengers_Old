﻿///////////////////////////////////////////////////////////////////////////////////////////////////
//AUTHOR — Travis Moore
//SCRIPT — Health.cs
///////////////////////////////////////////////////////////////////////////////////////////////////

#pragma warning disable 0169
#pragma warning disable 0649
#pragma warning disable 0108
#pragma warning disable 0414

using UnityEngine;
//using UnityEngine.UI;
using System.Collections;
//using System.Collections.Generic;

#region EVENTS
public class EVENT_OBJECT_HEALTH_INCREASED : GameEvent
{
    GameObject go;
    int hp;
    float percentage;
    int amount;
    public EVENT_OBJECT_HEALTH_INCREASED(GameObject _go, int _hp, float _percentage, int _amount)
    {
        go = _go;
        hp = _hp;
        percentage = _percentage;
        amount = _amount;
    }
}
public class EVENT_OBJECT_HEALTH_DECREASED : GameEvent
{
    GameObject go;
    int hp;
    float percentage;
    int amount;
    public EVENT_OBJECT_HEALTH_DECREASED(GameObject _go, int _hp, float _percentage, int _amount)
    {
        go = _go;
        hp = _hp;
        percentage = _percentage;
        amount = _amount;
    }
}
#endregion

public class Health : MonoBehaviour
{
    #region FIELDS
    [Range(0f, 1f)]
    [SerializeField]
    float percentage;
    [SerializeField]
    int max_hp;
    public int MaxHP
    {
        private set { max_hp = value; }
        get { return max_hp; }
    }
    int hp;
    public int HP
    {
        private set { hp = value; }
        get { return hp; }
    }
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


        //initial values

    }
    ///////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>
    /// Awake
    /// </summary>
    ///////////////////////////////////////////////////////////////////////////////////////////////
    void Awake()
    {
        if(max_hp <= 0)
        {
            Debug.LogError(gameObject + " needs max_hp set to a value > zero!");
        }

        SetHealthPercentage(percentage);

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
        //Events.instance.AddListener<event>(function);
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


    #if true
        UpdateTesting();
    #endif
    }
    #endregion

    #region PUBLIC METHODS
    ///////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>
    /// IncreaseHP — add to hp, report the amount gained
    /// </summary>
    ///////////////////////////////////////////////////////////////////////////////////////////////
    public void IncreaseHP(int _amount)
    {
        //check if we're overhealing
        int _difference = CheckAgainstMaxHP(_amount);

        //if there is a difference, heal to max, report the difference
        if(_difference > 0)
        {
            HP = MaxHP;
            percentage = (float)((float)HP / (float)MaxHP);
            Events.instance.Raise(new EVENT_OBJECT_HEALTH_INCREASED(gameObject, HP, percentage, (_amount - _difference)));
        }
        //else heal as normal
        else
        {
            HP += _amount;
            percentage = (float)((float)HP / (float)MaxHP);
            Events.instance.Raise(new EVENT_OBJECT_HEALTH_INCREASED(gameObject, HP, percentage, _amount));
        }
    }
    ///////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>
    /// DecreaseHP — subtract from hp, report the amount lost
    /// </summary>
    ///////////////////////////////////////////////////////////////////////////////////////////////
    public void DecreaseHP(int _amount)
    {
        HP -= _amount;
        
        //if we still are alive, report the decrease
        if (HP > 0)
        {
            percentage = (float)((float)HP / (float)MaxHP);
            Events.instance.Raise(new EVENT_OBJECT_HEALTH_DECREASED(gameObject, HP, percentage, _amount));
        }
        //else, not alive, correct health and report death
        else
        {
            HP = 0;
            percentage = (float)((float)HP / (float)MaxHP);
            Events.instance.Raise(new EVENT_OBJECT_HEALTH_DECREASED(gameObject, HP, percentage, _amount));
        }
    }
    ///////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>
    /// SetHealthPercentage — set hp based on percentage of MaxHP
    /// </summary>
    ///////////////////////////////////////////////////////////////////////////////////////////////
    public void SetHealthPercentage(float _percent)
    {
        //convert to int, store amount to add/heal
        int _amount = (int)Mathf.Ceil(MaxHP * _percent);
        if(HP < _amount)
        {
            IncreaseHP(_amount - HP);
        }
        else
        {
            DecreaseHP(HP - _amount);
        }
    }
    #endregion

    #region PRIVATE METHODS
    ///////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>
    /// CheckAgainstMaxHP — make sure we are not overhealing the object
    /// </summary>
    ///////////////////////////////////////////////////////////////////////////////////////////////
    int CheckAgainstMaxHP(int _amount)
    {
        //check if we're overhealing
        int _tempHP = HP + _amount;
        if(_tempHP > MaxHP)
        {
            //return the difference
            return _tempHP - MaxHP;
        }
        else
        {
            return 0;
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
        //remove listeners
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
            DecreaseHP(5);
        }
        //Keypad 1
        if(Input.GetKeyDown(KeyCode.Keypad1))
        {
            IncreaseHP(7);
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