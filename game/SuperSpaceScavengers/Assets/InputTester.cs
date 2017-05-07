///////////////////////////////////////////////////////////////////////////////////////////////////
//AUTHOR — Travis Moore
//SCRIPT — InputTester.cs
///////////////////////////////////////////////////////////////////////////////////////////////////

#pragma warning disable 0169
#pragma warning disable 0649
#pragma warning disable 0108
#pragma warning disable 0414

using UnityEngine;
using System.Collections;
//using System.Collections.Generic;
using UnityEngine.UI;

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

public class InputTester : MonoBehaviour
{
    #region FIELDS
    [Header("BUTTONS")]
    [SerializeField]
    RectTransform y;
    RectTransform y_icon;
    Text y_status;
    Text y_value;
    Text y_held;
    Text y_inactive;

    [SerializeField]
    RectTransform b;
    RectTransform b_icon;
    Text b_status;
    Text b_value;
    Text b_held;
    Text b_inactive;

    [SerializeField]
    RectTransform a;
    RectTransform a_icon;
    Text a_status;
    Text a_value;
    Text a_held;
    Text a_inactive;

    [SerializeField]
    RectTransform x;
    RectTransform x_icon;
    Text x_status;
    Text x_value;
    Text x_held;
    Text x_inactive;

    [SerializeField]
    RectTransform select;
    RectTransform select_icon;
    Text select_status;
    Text select_value;
    Text select_held;
    Text select_inactive;

    [SerializeField]
    RectTransform start;
    RectTransform start_icon;
    Text start_status;
    Text start_value;
    Text start_held;
    Text start_inactive;

    [Header("BUMPERS")]
    [SerializeField]
    RectTransform lb;
    RectTransform lb_icon;
    Text lb_status;
    Text lb_value;
    Text lb_held;
    Text lb_inactive;

    [SerializeField]
    RectTransform rb;
    RectTransform rb_icon;
    Text rb_status;
    Text rb_value;
    Text rb_held;
    Text rb_inactive;

    [Header("TRIGGERS")]
    [SerializeField]
    RectTransform lt;
    RectTransform lt_icon;
    Text lt_status;
    Text lt_value;
    Text lt_raw;
    Text lt_held;
    Text lt_inactive;

    [SerializeField]
    RectTransform rt;
    RectTransform rt_icon;
    Text rt_status;
    Text rt_value;
    Text rt_raw;
    Text rt_held;
    Text rt_inactive;
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
        if(y != null)
        {
            y_icon = y.transform.FindChild("Icon").GetComponent<RectTransform>();
            y_status = y.transform.FindChild("Data").GetChild(0).GetComponent<Text>();
            y_value = y.transform.FindChild("Data").GetChild(1).GetChild(1).GetComponent<Text>();
            y_held = y.transform.FindChild("Data").GetChild(2).GetChild(1).GetComponent<Text>();
            y_inactive = y.transform.FindChild("Data").GetChild(3).GetChild(1).GetComponent<Text>();
        }
        if (b != null)
        {
            b_icon = b.transform.FindChild("Icon").GetComponent<RectTransform>();
            b_status = b.transform.FindChild("Data").GetChild(0).GetComponent<Text>();
            b_value = b.transform.FindChild("Data").GetChild(1).GetChild(1).GetComponent<Text>();
            b_held = b.transform.FindChild("Data").GetChild(2).GetChild(1).GetComponent<Text>();
            b_inactive = b.transform.FindChild("Data").GetChild(3).GetChild(1).GetComponent<Text>();
        }
        if (a != null)
        {
            a_icon = a.transform.FindChild("Icon").GetComponent<RectTransform>();
            a_status = a.transform.FindChild("Data").GetChild(0).GetComponent<Text>();
            a_value = a.transform.FindChild("Data").GetChild(1).GetChild(1).GetComponent<Text>();
            a_held = a.transform.FindChild("Data").GetChild(2).GetChild(1).GetComponent<Text>();
            a_inactive = a.transform.FindChild("Data").GetChild(3).GetChild(1).GetComponent<Text>();
        }
        if (x != null)
        {
            x_icon = x.transform.FindChild("Icon").GetComponent<RectTransform>();
            x_status = x.transform.FindChild("Data").GetChild(0).GetComponent<Text>();
            x_value = x.transform.FindChild("Data").GetChild(1).GetChild(1).GetComponent<Text>();
            x_held = x.transform.FindChild("Data").GetChild(2).GetChild(1).GetComponent<Text>();
            x_inactive = x.transform.FindChild("Data").GetChild(3).GetChild(1).GetComponent<Text>();
        }
        if (select != null)
        {
            select_icon = select.transform.FindChild("Icon").GetComponent<RectTransform>();
            select_status = select.transform.FindChild("Data").GetChild(0).GetComponent<Text>();
            select_value = select.transform.FindChild("Data").GetChild(1).GetChild(1).GetComponent<Text>();
            select_held = select.transform.FindChild("Data").GetChild(2).GetChild(1).GetComponent<Text>();
            select_inactive = select.transform.FindChild("Data").GetChild(3).GetChild(1).GetComponent<Text>();
        }
        if (start != null)
        {
            start_icon = start.transform.FindChild("Icon").GetComponent<RectTransform>();
            start_status = start.transform.FindChild("Data").GetChild(0).GetComponent<Text>();
            start_value = start.transform.FindChild("Data").GetChild(1).GetChild(1).GetComponent<Text>();
            start_held = start.transform.FindChild("Data").GetChild(2).GetChild(1).GetComponent<Text>();
            start_inactive = start.transform.FindChild("Data").GetChild(3).GetChild(1).GetComponent<Text>();
        }
        if (lb != null)
        {
            lb_icon = lb.transform.FindChild("Icon").GetComponent<RectTransform>();
            lb_status = lb.transform.FindChild("Data").GetChild(0).GetComponent<Text>();
            lb_value = lb.transform.FindChild("Data").GetChild(1).GetChild(1).GetComponent<Text>();
            lb_held = lb.transform.FindChild("Data").GetChild(2).GetChild(1).GetComponent<Text>();
            lb_inactive = lb.transform.FindChild("Data").GetChild(3).GetChild(1).GetComponent<Text>();
        }
        if (rb != null)
        {
            rb_icon = rb.transform.FindChild("Icon").GetComponent<RectTransform>();
            rb_status = rb.transform.FindChild("Data").GetChild(0).GetComponent<Text>();
            rb_value = rb.transform.FindChild("Data").GetChild(1).GetChild(1).GetComponent<Text>();
            rb_held = rb.transform.FindChild("Data").GetChild(2).GetChild(1).GetComponent<Text>();
            rb_inactive = rb.transform.FindChild("Data").GetChild(3).GetChild(1).GetComponent<Text>();
        }
        if (lt != null)
        {
            lt_icon = lt.transform.FindChild("Icon").GetComponent<RectTransform>();
            lt_status = lt.transform.FindChild("Data").GetChild(0).GetComponent<Text>();
            lt_value = lt.transform.FindChild("Data").GetChild(1).GetChild(1).GetComponent<Text>();
            lt_raw = lt.transform.FindChild("Data").GetChild(2).GetChild(1).GetComponent<Text>();
            lt_held = lt.transform.FindChild("Data").GetChild(3).GetChild(1).GetComponent<Text>();
            lt_inactive = lt.transform.FindChild("Data").GetChild(4).GetChild(1).GetComponent<Text>();
        }
        if (rt != null)
        {
            rt_icon = rt.transform.FindChild("Icon").GetComponent<RectTransform>();
            rt_status = rt.transform.FindChild("Data").GetChild(0).GetComponent<Text>();
            rt_value = rt.transform.FindChild("Data").GetChild(1).GetChild(1).GetComponent<Text>();
            rt_raw = rt.transform.FindChild("Data").GetChild(2).GetChild(1).GetComponent<Text>();
            rt_held = rt.transform.FindChild("Data").GetChild(3).GetChild(1).GetComponent<Text>();
            rt_inactive = rt.transform.FindChild("Data").GetChild(4).GetChild(1).GetComponent<Text>();
        }
        //set/check initial values

    }
    ///////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>
    /// Awake
    /// </summary>
    ///////////////////////////////////////////////////////////////////////////////////////////////
    void Awake()
    {
        //listen to events
        SetSubscriptions();
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
        Events.instance.AddListener<EVENT_GAMEPAD_P1>(TestButtons);
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

    #endregion

    #region PRIVATE METHODS
    ///////////////////////////////////////////////////////////////////////////////////////////////
    void TestButtons(EVENT_GAMEPAD_P1 _event)
    {
        //y button
        y_status.text = _event.gamepad.y.Status.ToString();
        y_value.text = _event.gamepad.y.XYValues.x.ToString("F2");
        y_held.text = _event.gamepad.y.HeldDuration.ToString("F2");
        y_inactive.text = _event.gamepad.y.InactiveDuration.ToString("F2");
        //b button
        b_status.text = _event.gamepad.b.Status.ToString();
        b_value.text = _event.gamepad.b.XYValues.x.ToString("F2");
        b_held.text = _event.gamepad.b.HeldDuration.ToString("F2");
        b_inactive.text = _event.gamepad.b.InactiveDuration.ToString("F2");
        //a button
        a_status.text = _event.gamepad.a.Status.ToString();
        a_value.text = _event.gamepad.a.XYValues.x.ToString("F2");
        a_held.text = _event.gamepad.a.HeldDuration.ToString("F2");
        a_inactive.text = _event.gamepad.a.InactiveDuration.ToString("F2");
        //x button
        x_status.text = _event.gamepad.x.Status.ToString();
        x_value.text = _event.gamepad.x.XYValues.x.ToString("F2");
        x_held.text = _event.gamepad.x.HeldDuration.ToString("F2");
        x_inactive.text = _event.gamepad.x.InactiveDuration.ToString("F2");
        //select button
        select_status.text = _event.gamepad.select.Status.ToString();
        select_value.text = _event.gamepad.select.XYValues.x.ToString("F2");
        select_held.text = _event.gamepad.select.HeldDuration.ToString("F2");
        select_inactive.text = _event.gamepad.select.InactiveDuration.ToString("F2");
        //start button
        start_status.text = _event.gamepad.start.Status.ToString();
        start_value.text = _event.gamepad.start.XYValues.x.ToString("F2");
        start_held.text = _event.gamepad.start.HeldDuration.ToString("F2");
        start_inactive.text = _event.gamepad.start.InactiveDuration.ToString("F2");
        //lb
        lb_status.text = _event.gamepad.lb.Status.ToString();
        lb_value.text = _event.gamepad.lb.XYValues.x.ToString("F2");
        lb_held.text = _event.gamepad.lb.HeldDuration.ToString("F2");
        lb_inactive.text = _event.gamepad.lb.InactiveDuration.ToString("F2");
        //rb
        rb_status.text = _event.gamepad.rb.Status.ToString();
        rb_value.text = _event.gamepad.rb.XYValues.x.ToString("F2");
        rb_held.text = _event.gamepad.rb.HeldDuration.ToString("F2");
        rb_inactive.text = _event.gamepad.rb.InactiveDuration.ToString("F2");
        //lt
        lt_status.text = _event.gamepad.lt.Status.ToString();
        lt_value.text = _event.gamepad.lt.XYValues.x.ToString("F2");
        lt_raw.text = _event.gamepad.lt.XYRawValues.x.ToString("F2");
        lt_held.text = _event.gamepad.lt.HeldDuration.ToString("F2");
        lt_inactive.text = _event.gamepad.lt.InactiveDuration.ToString("F2");
        //rt
        rt_status.text = _event.gamepad.rt.Status.ToString();
        rt_value.text = _event.gamepad.rt.XYValues.x.ToString("F2");
        rt_raw.text = _event.gamepad.rt.XYRawValues.x.ToString("F2");
        rt_held.text = _event.gamepad.rt.HeldDuration.ToString("F2");
        rt_inactive.text = _event.gamepad.rt.InactiveDuration.ToString("F2");
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