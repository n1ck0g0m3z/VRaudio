using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;
using System.Runtime.InteropServices;
using System.Windows.Forms;

public class GUIScript : MonoBehaviour {

    public static GUIScript Instance;

    public string username;
    public string password;
    [SerializeField]public string room;
    [SerializeField]private string file;
    [SerializeField]public string token;
    [SerializeField]public string net;
    [SerializeField]public int seat;
    public GameObject canvas;
    public GameObject panel;
	[SerializeField]private bool create;
    private Socket socket;

    void Awake ()
    {
        if (Instance == null)
        {
            create = false;
            panel = canvas.transform.Find("SignIn").gameObject;
            panel.SetActive(true);
            DontDestroyOnLoad(gameObject);
            Instance = this;
        } else if (Instance != this) {
            Instance.backMenu();
            Destroy(gameObject);
        }
    }

	public void Join ()
    {
        room = GameObject.Find("RoomField").GetComponent<InputField>().text.ToString();
        if (create)
        {
            string uri = "http://"+net+":4000/api/room";
            StartCoroutine(CreateRoom(uri));
			create = false;
        }else
        {
            string uri2 = "http://" + net + ":4000/api/room-entry";
            StartCoroutine(JoinRoom(uri2));
        }
    }

    public void SignIn()
    {
        username = GameObject.Find("UserField").GetComponent<InputField>().text.ToString();
        password = GameObject.Find("PwdField").GetComponent<InputField>().text.ToString();
        WWWForm form = new WWWForm();
        form.AddField("user_name",username);
        form.AddField("password",password);
        WWW www = new WWW("http://" + net + ":4000/api/login", form);
        StartCoroutine(LogIn(www));
    }

    public void SignUp()
    {
        panel.SetActive(false);
        panel = canvas.transform.Find("SignUp").gameObject;
        panel.SetActive(true);
    }

    public void RegisterUser()
    {
        username = GameObject.Find("UserField").GetComponent<InputField>().text.ToString();
        password = GameObject.Find("PwdField").GetComponent<InputField>().text.ToString();
        string uri = "http://" + net + ":4000/api/register";
        StartCoroutine(signUp(uri));
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

    IEnumerator signUp(string url)
    {
        WWWForm form = new WWWForm();
        form.AddField("user_name",username);
        form.AddField("password", password);
        WWW www = new WWW(url,form);
        yield return www;

        JSONObject json = new JSONObject(www.text);

        Debug.Log(json);
        if (json.getInt("result") == 1)
        {
            panel.SetActive(false);
            panel = canvas.transform.Find("Menu").gameObject;
            panel.SetActive(true);
        }
        else
        {
            canvas.transform.Find("Error").gameObject.SetActive(true);
        }
    }

    IEnumerator JoinRoom(string url)
    {
        WWWForm form = new WWWForm();
        form.AddField("token", token);
        form.AddField("room_name", room);
        WWW www = new WWW(url, form);
        yield return www;

        JSONObject json = new JSONObject(www.text);
        Debug.Log(json);

        if (json.getInt("result") == 1) {
            seat = json.getInt("seat_position");
            socket = GameObject.Find("UserController").GetComponent<Socket>();
            socket.enabled = true;
            SceneManager.LoadScene("Main");
            socket.startSocket();
        }
        else
        {
            canvas.transform.Find("Error").gameObject.SetActive(true);
        }
    }

    IEnumerator CreateRoom(string url)
    {
        WWWForm form = new WWWForm();
        form.AddField("token", token);
        form.AddField("room_name", room);
        WWW www = new WWW(url, form);
        yield return www;

        JSONObject json = new JSONObject(www.text);
        Debug.Log(json);

        if (json.getInt("result") == 1)
        {
            seat = json.getInt("seat_position");
            socket = GameObject.Find("UserController").GetComponent<Socket>();
            socket.enabled = true;
            SceneManager.LoadScene("Main");
            socket.startSocket();
        }
        else
        {
            canvas.transform.Find("Error").gameObject.SetActive(true);
        }
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
                create = false;
                panel.transform.Find("File").gameObject.SetActive(false);
                break;
			case 1:
				create = true;
				panel.transform.Find("File").gameObject.SetActive(true);
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
    
    public void backMenu()
    {
        canvas = GameObject.Find("Canvas");
        panel = canvas.transform.Find("Menu").gameObject;
        panel.SetActive(true);
    }
}
