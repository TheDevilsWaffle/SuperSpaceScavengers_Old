﻿///////////////////////////////////////////////////////////////////////////////////////////////////
//AUTHOR — Travis Moore
//SCRIPT — TileGeneration.cs
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

public class TileGeneration : MonoBehaviour
{
    #region FIELDS
    [Header("TILES")]
    [SerializeField]
    GameObject tile;
    [SerializeField]
    int amount;
    [SerializeField]
    Vector3 startPosition = new Vector3(10f, 10f, 10f);
    [SerializeField]
    Vector3 startRotation = new Vector3(90f, 0f, 0f);
    [SerializeField]
    float generationDelay = 0.2f;
    Vector3 nextPosition;
    Direction previousDirection;

    List<GameObject> tiles;
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
        nextPosition = startPosition;
        tiles = new List<GameObject> { };
    }
    ///////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>
    /// Awake
    /// </summary>
    ///////////////////////////////////////////////////////////////////////////////////////////////
    void Awake()
    {
        //SetSubscriptions();
    }
    ///////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>
    /// Start
    /// </summary>
    ///////////////////////////////////////////////////////////////////////////////////////////////
    void Start()
    {
        StartCoroutine(GenerateTiles());
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
    IEnumerator GenerateTiles()
    {
        if(tile != null)
        {
            Tile _previousTile = null;

            for (int i = 0; i < amount; ++i)
            {
                GameObject _tile = Instantiate(tile, nextPosition, Quaternion.identity);
                _tile.GetComponent<Transform>().rotation = Quaternion.Euler(startRotation);

                _tile.GetComponent<Tile>().Initialize(nextPosition, PowerStatus.POWERED);

                tiles.Add(_tile);

                if(_previousTile != null)
                {
                    print(previousDirection + ", " + _previousTile);
                    _tile.GetComponent<Tile>().SetNeighbor(previousDirection, _previousTile);
                    Debug.Log(_tile + "'s neighbor is: " + _tile.GetComponent<Tile>().GetNeighbor(previousDirection).gameObject.name);
                }
                _previousTile = _tile.GetComponent<Tile>();
                nextPosition = UpdateNextPosition();

                yield return new WaitForSeconds(generationDelay);
            }
        }
    }
    ///////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>
    /// function
    /// </summary>
    ///////////////////////////////////////////////////////////////////////////////////////////////
    Vector3 UpdateNextPosition()
    {
        Vector3 _shift = ChooseRandomDirection(Random.Range(0, 3));
        return nextPosition + _shift;
    }
    ///////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>
    /// function
    /// </summary>
    ///////////////////////////////////////////////////////////////////////////////////////////////
    Vector3 ChooseRandomDirection(int _direction)
    {
        switch (_direction)
        {
            case 0:
                previousDirection = Direction.SOUTH;
                if (DuplicateCheck(nextPosition + new Vector3(0, 0, 1)))
                {
                    return ChooseRandomDirection(Random.Range(0, 3));
                }
                else
                    return new Vector3(0, 0, 1);

            case 1:
                previousDirection = Direction.WEST;
                if (DuplicateCheck(nextPosition + new Vector3(1, 0, 0)))
                {
                    return ChooseRandomDirection(Random.Range(0, 3));
                }
                else
                    return new Vector3(1, 0, 0);

            case 2:
                previousDirection = Direction.NORTH;
                if (DuplicateCheck(nextPosition + new Vector3(0, 0, -1)))
                {
                    return ChooseRandomDirection(Random.Range(0, 3));
                }
                else
                    return new Vector3(0, 0, -1);

            case 3:
                previousDirection = Direction.EAST;
                if (DuplicateCheck(nextPosition + new Vector3(-1, 0, 0)))
                {
                    return ChooseRandomDirection(Random.Range(0, 3));
                }
                else
                    return new Vector3(-1, 0, 0);

            default:
                Debug.LogError("Random.Range(0,3) somehow returned a number out of range: " + _direction);
                return Vector3.zero;
        }
    }
    bool DuplicateCheck(Vector3 _pos)
    {
        foreach(GameObject _tile in tiles)
        {
            if (_tile.transform.position == _pos)
                return true;
        }
        return false;
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