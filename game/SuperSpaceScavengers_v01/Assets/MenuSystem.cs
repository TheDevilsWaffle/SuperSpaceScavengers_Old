using UnityEngine;
using System.Collections;

public class MenuSystem : MonoBehaviour
{
    public ButtonBase currentlySelectedButton;
	// Use this for initialization
	void Start ()
    {
        if (currentlySelectedButton != null)
            currentlySelectedButton.OnHover();
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}
}
