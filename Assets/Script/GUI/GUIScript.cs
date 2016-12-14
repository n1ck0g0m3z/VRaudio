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
    public string room;
    [SerializeField]private string file;
    [SerializeField]public string token;
    public GameObject canvas;
    public GameObject panel;

    void Awake ()
    {
        if (Instance == null)
        {
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
        file = "";
        token = "";
        Back();
    }

    public void OkButton()
    {
        canvas.transform.Find("Error").gameObject.SetActive(false);
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
                panel.transform.Find("File").gameObject.SetActive(true);
                break;
            case 1:
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
        openDialog.Filter = "music files (*.mp3;*.wav)|*.MP3;*.WAV|All files (*.*)|*.*";
        openDialog.Title = "Select some music you want to listen to during this Game session.";
        openDialog.Multiselect = true;
        string[] result = null;
        if (openDialog.ShowDialog() == DialogResult.OK)
        {
            result = openDialog.FileNames;
        }
        if (openDialog.FileName == string.Empty)
        {
            result = null;
        }
        openDialog = null;
    }
}
