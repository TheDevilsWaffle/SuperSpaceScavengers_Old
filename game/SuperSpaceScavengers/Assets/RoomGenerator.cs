﻿///////////////////////////////////////////////////////////////////////////////////////////////////
//AUTHOR — Travis Moore
//SCRIPT — RoomGenerator.cs
///////////////////////////////////////////////////////////////////////////////////////////////////

#pragma warning disable 0169
#pragma warning disable 0649
#pragma warning disable 0108
#pragma warning disable 0414

using UnityEngine;
//using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

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

public class RoomGenerator : MonoBehaviour
{
    #region FIELDS
    [Header("SIZE")]
    [SerializeField]
    Vector3 startingPosition = new Vector3(10, 10, 10);
    float y;
    [SerializeField]
    int x = 100;
    [SerializeField]
    int z = 100;

    [Header("ROOMS")]
    List<GameObject> rooms;
    [SerializeField]
    GameObject room;
    [SerializeField]
    int amount = 50;
    [SerializeField]
    int attempts = 5;
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
        y = startingPosition.y;
    }
    ///////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>
    /// Awake
    /// </summary>
    ///////////////////////////////////////////////////////////////////////////////////////////////
    void Awake()
    {
        rooms = new List<GameObject> { };
        //SetSubscriptions();
    }
    ///////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>
    /// Start
    /// </summary>
    ///////////////////////////////////////////////////////////////////////////////////////////////
    void Start()
    {
        GenerateRooms();
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


    #if false
        UpdateTesting();
    #endif
    }
    #endregion

    #region PUBLIC METHODS
    ///////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>
    /// function
    /// </summary>
    ///////////////////////////////////////////////////////////////////////////////////////////////

    #endregion

    #region PRIVATE METHODS
    ///////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>
    /// function
    /// </summary>
    ///////////////////////////////////////////////////////////////////////////////////////////////
    void GenerateRooms()
    {
        for (int i = 0; i < amount; ++i)
        {
            Vector3 _position = RandomLocation();
            AttemptToPlaceRoom(_position, i);
        }
        RandomLocation();
    }
    Vector3 RandomLocation()
    {
        return new Vector3(Random.Range(startingPosition.x, x), y, Random.Range(startingPosition.z, z));
    }
    void AttemptToPlaceRoom(Vector3 _position, int _i)
    {
        GameObject _room = Instantiate(room, _position, Quaternion.identity);

        Debug.Log(_room.name + _i + " created @ pos("+_position+")");

        //check overlap
        foreach(GameObject room in rooms)
        {
            if(room != null)
            {
                if(room.transform.GetChild(0).GetComponent<MeshCollider>().bounds.Intersects(_room.transform.GetChild(0).GetComponent<MeshCollider>().bounds))
                {
                    Debug.Log(room.name + " collides with " + _room + "! Destroying " + _room);
                    
                    Destroy(_room);
                }
            }
        }
        if(_room != null)
        {
            rooms.Add(_room);
            _room.name = "Room " + rooms.Count;
            Debug.Log(_room.name + " doesn't collide with anything, adding it to the list!");
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