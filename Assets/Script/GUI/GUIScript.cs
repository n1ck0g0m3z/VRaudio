﻿using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;
using System.Runtime.InteropServices;
using System.Windows.Forms;

public class GUIScript : MonoBehaviour {

    public static GUIScript Instance;

    public string username;
    public string password;
    public string room;
    [SerializeField]private string file;
    [SerializeField]public string token;
    public GameObject canvas;
    public GameObject panel;
    private bool create;

    void Awake ()
    {
        if (Instance == null)
        {
            create = true;
            panel = canvas.transform.Find("SignIn").gameObject;
            panel.SetActive(true);
            DontDestroyOnLoad(gameObject);
            Instance = this;
        } else if (Instance != this) {
            Destroy(gameObject);
        }
    }

	public void Join ()
    {
        room = GameObject.Find("RoomField").GetComponent<InputField>().text.ToString();
        GameObject.Find("UserController").GetComponent<Socket>().enabled = true;
        if (create)
        {
            string uri = "http://192.168.200.203:4000/api/room";
            StartCoroutine(CreateRoom(uri));
        }else
        {
            string uri2 = "http://192.168.200.203:4000/api/room-entry";
            StartCoroutine(JoinRoom(uri2));
        }
        SceneManager.LoadScene("Main");
    }

    public void SignIn()
    {
        username = GameObject.Find("UserField").GetComponent<InputField>().text.ToString();
        password = GameObject.Find("PwdField").GetComponent<InputField>().text.ToString();
        WWWForm form = new WWWForm();
        form.AddField("user_name",username);
        form.AddField("password",password);
        WWW www = new WWW("http://192.168.200.203:4000/api/login", form);
        StartCoroutine(LogIn(www));
    }

    public void SignUp()
    {
        panel.SetActive(false);
        panel = canvas.transform.Find("SignUp").gameObject;
        panel.SetActive(true);
    }

    public void Back()
    {
        panel.SetActive(false);
        panel = canvas.transform.Find("SignIn").gameObject;
        panel.SetActive(true);
    }

    public void SignOut()
    {
        username = "";
        password = "";
        room = "";
        file = null;
        token = "";
        Back();
    }

    public void OkButton()
    {
        canvas.transform.Find("Error").gameObject.SetActive(false);
    }
	
    IEnumerator JoinRoom(string url)
    {
        WWWForm form = new WWWForm();
        form.AddField("token", token);
        form.AddField("room_id", 1);
        WWW www = new WWW(url, form);
        yield return www;

        /*JSONObject json = new JSONObject(www.text);
        Debug.Log(json);*/
    }

    IEnumerator CreateRoom(string url)
    {
        WWWForm form = new WWWForm();
        form.AddField("token", token);
        form.AddField("room_name", room);
        form.AddField("document_id", 1);
        WWW www = new WWW(url, form);
        yield return www;

        JSONObject json = new JSONObject(www.text);
        Debug.Log(json);
    }

    IEnumerator LogIn(WWW www)
    {
        yield return www;

        if (!string.IsNullOrEmpty(www.error))
        {
            Debug.Log(www.error);
            yield break;
        }
        JSONObject json = new JSONObject(www.text);

        token = json.getString("token");

        if (token != "")
        {
            panel.SetActive(false);
            panel = canvas.transform.Find("Menu").gameObject;
            panel.SetActive(true);
        }else
        {
            canvas.transform.Find("Error").gameObject.SetActive(true);
        }

        Debug.Log(json);
    }

    public void selection(Dropdown dropdown)
    {
        switch (dropdown.value)
        {
            case 0:
                create = true;
                panel.transform.Find("File").gameObject.SetActive(true);
                break;
            case 1:
                create = false;
                panel.transform.Find("File").gameObject.SetActive(false);
                break;
        }
    }

    [DllImport("user32.dll")]
    private static extern void OpenFileDialog(); //in your case : OpenFileDialog
    private static OpenFileDialog openDialog;
    public void Search()
    {
        openDialog = new OpenFileDialog();
        openDialog.InitialDirectory = UnityEngine.Application.dataPath;
        openDialog.Filter = "music files (*.mp4;*.pptx)|*.MP4;*.PPTX|All files (*.*)|*.*";
        openDialog.Title = "Select your video or pptx document";
        openDialog.Multiselect = true;
        if (openDialog.ShowDialog() == DialogResult.OK)
        {
            file = openDialog.FileName;
            GameObject.Find("FileField").GetComponent<InputField>().text = file;
        }
        if (openDialog.FileName == string.Empty)
        {
            file = null;
        }
        openDialog = null;
    }
}
