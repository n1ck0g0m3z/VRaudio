using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GUIMiddleware : MonoBehaviour {
    protected GUIScript gui;
	// Use this for initialization
	void Start () {
        gui = (GUIScript)FindObjectOfType(typeof(GUIScript));
	}

    public void Join()
    {
        gui.Join();
    }

    public void SignIn()
    {
        gui.SignIn();
    }

    public void SignUp()
    {
        gui.SignUp();
    }

    public void RegisterUser()
    {
        gui.RegisterUser();
    }

    public void Back()
    {
        gui.Back();
    }

    public void SignOut()
    {
        gui.SignOut();
    }

    public void OkButton()
    {
        gui.OkButton();
    }

    public void selection(Dropdown dropdown)
    {
        gui.selection(dropdown);
    }

    public void Search()
    {
        gui.Search();
    }
}
