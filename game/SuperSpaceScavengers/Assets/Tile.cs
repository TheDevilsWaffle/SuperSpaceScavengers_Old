﻿///////////////////////////////////////////////////////////////////////////////////////////////////
//AUTHOR — Travis Moore
//SCRIPT — Tile.cs
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
public enum Direction
{
	NORTH,
    EAST,
    SOUTH,
    WEST
};
#endregion

#region EVENTS
//public class EVENT_EXAMPLE : GameEvent
//{
//    public EVENT_EXAMPLE() { }
//}
#endregion

public class Tile : MonoBehaviour
{
    #region FIELDS
    [Header("NEIGHBORS")]
    Dictionary<Direction, Tile> neighbors;
    Tile north;
    Tile east;
    Tile south;
    Tile west;

    [Header("POWER")]
    [SerializeField]
    PowerStatus power;
    public PowerStatus Power
    {
        get { return power; }
    }

    [HideInInspector]
    Vector3 pos;
    public Vector3 Position
    {
        get { return pos; }
    }

    Transform tr;

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
        tr = GetComponent<Transform>();

        //initial values
        SetPosition(tr.position);

        
    }
    ///////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>
    /// Awake
    /// </summary>
    ///////////////////////////////////////////////////////////////////////////////////////////////
    void Awake()
    {
        tr = GetComponent<Transform>();
        neighbors = new Dictionary<Direction, Tile> { };
        //SetSubscriptions();
    }
    ///////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>
    /// Start
    /// </summary>
    ///////////////////////////////////////////////////////////////////////////////////////////////
    void Start()
    {
        //DiscoverNeighbors();
    }
    ///////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>
    /// SetSubscriptions
    /// </summary>
    ///////////////////////////////////////////////////////////////////////////////////////////////
    void SetSubscriptions()
    {
        //Events.instance.AddListener<>();
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
    /// 
    /// </summary>
    /// <param name="_pos"></param>
    /// <param name="_status"></param>
    ///////////////////////////////////////////////////////////////////////////////////////////////
    public void Initialize(Vector3 _pos, PowerStatus _status)
    {
        SetPosition(_pos);
        SetPower(_status);
    }
    ///////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>
    /// 
    /// </summary>
    /// <param name="_pos"></param>
    ///////////////////////////////////////////////////////////////////////////////////////////////
    public void SetPosition(Vector3 _pos)
    {
        pos = _pos;
        name = "Tile(" + pos.x + ", " + pos.y + ", " + pos.z + ")";
    }
    ///////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>
    /// 
    /// </summary>
    /// <param name="_direction"></param>
    /// <param name="_tile"></param>
    ///////////////////////////////////////////////////////////////////////////////////////////////
    public void SetNeighbor(Direction _direction, Tile _tile)
    {
        neighbors.Add(_direction, _tile);
        switch (_direction)
        {
            case Direction.NORTH:
                north = _tile;
                break;
            case Direction.EAST:
                east = _tile;
                break;
            case Direction.SOUTH:
                south = _tile;
                break;
            case Direction.WEST:
                west = _tile;
                break;
            default:
                break;
        }
    }
    ///////////////////////////////////////////////////////////////////////////////////////////////
    public void PlaceWalls(GameObject _wallPrefab)
    {
        foreach (KeyValuePair<Direction, Tile> _neighbor in neighbors)
        {
            if(_neighbor.Value == null)
            {
                GameObject _wall = Instantiate(_wallPrefab, tr.position, Quaternion.identity);
                Transform _wall_tr = _wall.GetComponent<Transform>();
                _wall_tr.parent = tr;

                //rotate walls based on direction
                switch (_neighbor.Key)
                {
                    case Direction.NORTH:
                        _wall_tr.localPosition += new Vector3(0, 0.5f, -0.5f);
                        _wall.gameObject.name = "Wall(" + _neighbor.Key.ToString() + ")";
                        break;

                    case Direction.EAST:
                        _wall_tr.localPosition += new Vector3(0.5f, 0, -0.5f);
                        _wall_tr.Rotate(new Vector3(0f, -90f, 0));
                        _wall.gameObject.name = "Wall(" + _neighbor.Key.ToString() + ")";
                        break;

                    case Direction.SOUTH:
                        _wall_tr.localPosition += new Vector3(0, -0.5f, -0.5f);
                        _wall.gameObject.name = "Wall(" + _neighbor.Key.ToString() + ")";
                        break;

                    case Direction.WEST:
                        _wall_tr.localPosition += new Vector3(-0.5f, 0, -0.5f);
                        _wall_tr.Rotate(new Vector3(0, -90, 0));
                        _wall.gameObject.name = "Wall(" + _neighbor.Key.ToString() + ")";

                        break;

                    default:
                        break;
                }
                
            }
        }
    }
    ///////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>
    /// 
    /// </summary>
    ///////////////////////////////////////////////////////////////////////////////////////////////
    public void PrintNeighbors()
    {
        foreach(KeyValuePair<Direction, Tile> _neighbor in neighbors)
        {
            if (_neighbor.Value != null)
            {
                print(_neighbor.Key + " is " + _neighbor.Value.gameObject.name);
            }
            else
            {
                print(_neighbor.Key + " is NULL");
            }
        }
    }
    ///////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>
    /// 
    /// </summary>
    /// <param name="_direction"></param>
    /// <returns></returns>
    ///////////////////////////////////////////////////////////////////////////////////////////////
    public Tile GetNeighbor(Direction _direction)
    {
        return neighbors[_direction];
    }
    ///////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>
    /// 
    /// </summary>
    /// <param name="_status"></param>
    ///////////////////////////////////////////////////////////////////////////////////////////////
    public void SetPower(PowerStatus _status)
    {
        power = _status;
    }
    ///////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>
    /// 
    /// </summary>
    ///////////////////////////////////////////////////////////////////////////////////////////////
    public void DiscoverNeighbors()
    {
        RaycastHit _northHit;
        RaycastHit _eastHit;
        RaycastHit _southHit;
        RaycastHit _westHit;
        Physics.Raycast(tr.position, Vector3.forward, out _northHit, 1f);
        //Debug.DrawRay(tr.position, Vector3.forward, Color.blue, 1f);

        Physics.Raycast(tr.position, Vector3.left, out _westHit, 1f);
        //Debug.DrawRay(tr.position, Vector3.left, Color.red, 1f);

        Physics.Raycast(tr.position, -Vector3.forward, out _southHit, 1f);
        //Debug.DrawRay(tr.position, -Vector3.forward, Color.green, 1f);

        Physics.Raycast(tr.position, -Vector3.left, out _eastHit, 1f);
        //Debug.DrawRay(tr.position, -Vector3.left, Color.yellow, 1f);


        if (_northHit.collider != null)
        {
            SetNeighbor(Direction.NORTH, _northHit.collider.gameObject.transform.root.GetComponent<Tile>());
        }
        else
        {
            SetNeighbor(Direction.NORTH, null);
        }

        if (_eastHit.collider != null)
        {
            SetNeighbor(Direction.EAST, _eastHit.collider.gameObject.transform.root.GetComponent<Tile>());
        }
        else
        {
            SetNeighbor(Direction.EAST, null);
        }

        if (_southHit.collider != null)
        {
            SetNeighbor(Direction.SOUTH, _southHit.collider.gameObject.transform.root.GetComponent<Tile>());
        }
        else
        {
            SetNeighbor(Direction.SOUTH, null);
        }

        if (_westHit.collider != null)
        {
            SetNeighbor(Direction.WEST, _westHit.collider.gameObject.transform.root.GetComponent<Tile>());
        }
        else
        {
            SetNeighbor(Direction.WEST, null);
        }
    }
    #endregion

    #region PRIVATE METHODS
    ///////////////////////////////////////////////////////////////////////////////////////////////

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